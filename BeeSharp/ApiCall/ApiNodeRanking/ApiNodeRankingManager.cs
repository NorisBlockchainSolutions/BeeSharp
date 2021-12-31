using System;
using System.Linq;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;
using BeeSharp.ApiCall.ApiNodeRanking.RankingCreators;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiCall.ApiNodeRanking
{
    public class ApiNodeRankingManager : IApiNodeRankingManager
    {
        private readonly string[] _apiNodeUrls;
        private readonly IAwaitFirstCreator _initialNodeRankingCreator;
        private readonly IAwaitAllCreator _nodeRankingCreator;
        private readonly ISortedIDictionaryFactory<long, string> _sortedIDictionaryFactory;
        private readonly ushort _timeout;
        private ISortedIDictionary<long, string> _currentTimedApiNodes;
        private ISortedIDictionary<long, string> _oldTimedApiNodes;

        private readonly IThreadSafeExecution _timedApiNodesLock;

        private Task? _remainingTasks;

        public ApiNodeRankingManager(IAwaitAllCreator nodeRankingCreator,
            IAwaitFirstCreator initialNodeRankingCreator,
            ISortedIDictionaryFactory<long, string> sortedIDictionaryFactory,
            IThreadSafeExecutionFactory threadSafeExecutionFactory,
            ApiNodeRankingManagerContext apiNodeRankingManagerContext)
        {
            _nodeRankingCreator = nodeRankingCreator;
            _initialNodeRankingCreator = initialNodeRankingCreator;
            _sortedIDictionaryFactory = sortedIDictionaryFactory;
            _timedApiNodesLock = threadSafeExecutionFactory.Create();

            _currentTimedApiNodes = _sortedIDictionaryFactory.Create();
            _oldTimedApiNodes = _sortedIDictionaryFactory.Create();

            if (apiNodeRankingManagerContext.ApiNodeUrls == null)
                throw new ArgumentException("Cannot initialize without initialized context",
                    nameof(apiNodeRankingManagerContext));

            (_apiNodeUrls, _timeout) = apiNodeRankingManagerContext;

            _remainingTasks = null;
        }

        public async Task RunInitialApiNodeRankingAsync()
        {
            await _timedApiNodesLock.RunAsynchronousFunctionAwaitAsync(async () =>
            {
                _remainingTasks = await _initialNodeRankingCreator.CreateApiNodeRankingAsync(_currentTimedApiNodes,
                    _apiNodeUrls, _timeout);
            });
        }

        public ISortedIDictionary<long, string> GetCurrentTimedApiNodes()
        {
            if (_currentTimedApiNodes.Count > 0) return _currentTimedApiNodes;

            if (_oldTimedApiNodes.Count == 0)
            {
                throw new OutOfNodesException();
            }

            return _oldTimedApiNodes;
        }

        /// <summary>
        ///     Update the api node ranking.
        /// </summary>
        /// <exception cref="ClassInstantiationException">Thrown when the initial node ranking is still running.</exception>
        public async Task UpdateApiNodeRankingAsync()
        {
            await _timedApiNodesLock.RunAsynchronousFunctionAwaitAsync(async () =>
            {
                // Since remainingTasks is a Promise task, only WaitingForActivation has to be checked
                if (_remainingTasks is {Status: TaskStatus.WaitingForActivation})
                    throw new ClassInstantiationException(
                        "Cannot update api node ranking while still initializing!");

                BackupApiNode();
                await _nodeRankingCreator.CreateApiNodeRankingAsync(_currentTimedApiNodes, _apiNodeUrls, _timeout);
                // Clear old node list to prevent its further usage in GetCurrentTimedApiNodes()
                _oldTimedApiNodes = _sortedIDictionaryFactory.Create();
            });
        }

        private void BackupApiNode()
        {
            _oldTimedApiNodes = _currentTimedApiNodes;
            _currentTimedApiNodes = _sortedIDictionaryFactory.Create();
        }

        /// <summary>
        /// Remove an url from the current ranking. It will be re-evaluated on the next re-ranking run.
        /// </summary>
        /// <param name="url">The url to remove.</param>
        public async Task RemoveUrlFromCurrentRankingAsync(string url)
        {
            await _timedApiNodesLock.RunAsynchronousFunctionAwaitAsync(async () =>
            {
                // Skip if array is empty
                if (_currentTimedApiNodes.Count == 0)
                    throw new OutOfNodesException($"Cannot remove node {url} from empty ranking!");
                var key = _currentTimedApiNodes
                    .Where(pair => pair.Value == url)
                    .Select(pair => pair.Key).First();
                await _currentTimedApiNodes.RemoveAsync(key);
            });
        }
    }
}