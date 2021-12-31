using System;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;
using BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators
{
    public class AwaitAllCreator : RankingCreator, IAwaitAllCreator
    {
        private readonly IThreadExceptionHandler _threadExceptionHandler;

        public AwaitAllCreator(IApiNodePerformanceTester apiNodePerformanceTester, IListFactory<Task> listFactory,
            IThreadExceptionHandler threadExceptionHandler)
            : base(apiNodePerformanceTester, listFactory)
        {
            _threadExceptionHandler = threadExceptionHandler;
        }

        /// <summary>
        ///     Update the internal ranking of all known apiNodes, sorted by elapsedTime.
        /// </summary>
        /// <returns>Awaitable.</returns>
        public async Task CreateApiNodeRankingAsync(ISortedIDictionary<long, string> apiNodeUrlList,
            string[] apiNodeUrls, ushort timeout)
        {
            try
            {
                var runningTests = CreateApiNodeRankingTasks(apiNodeUrlList, apiNodeUrls, timeout);
                await Task.WhenAll(runningTests);
            }
            catch (Exception e)
            {
                // Handle thread exception
                _threadExceptionHandler.Handle(e);
            }
        }
    }
}