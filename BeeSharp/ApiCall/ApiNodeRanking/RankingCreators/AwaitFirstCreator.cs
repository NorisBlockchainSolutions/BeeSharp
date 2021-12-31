using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;
using BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators
{
    public class AwaitFirstCreator : RankingCreator, IAwaitFirstCreator
    {
        private readonly IAnySuccessfulTaskHandler _taskHandler;

        public AwaitFirstCreator(IApiNodePerformanceTester apiNodePerformanceTester, IListFactory<Task> listFactory,
            IAnySuccessfulTaskHandler taskHandler) : base(apiNodePerformanceTester, listFactory)
        {
            _taskHandler = taskHandler;
        }

        /// <summary>
        ///     Update the internal ranking of all known apiNodes, sorted by elapsedTime.
        ///     Run remaining tasks after the first one completes in thread.
        /// </summary>
        /// <returns>Awaitable.</returns>
        /// <exception cref="TimeoutException">Thrown when no apiNode can be reached.</exception>
        public async Task<Task?> CreateApiNodeRankingAsync(ISortedIDictionary<long, string> apiNodeUrlList,
            string[] apiNodeUrls, ushort timeout)
        {
            var runningTests = CreateApiNodeRankingTasks(apiNodeUrlList, apiNodeUrls, timeout);
            var result = await _taskHandler.AnySuccessfulTaskCompletedAsync(runningTests);

            if (!result) throw new TimeoutException("Cannot reach any apiNode!");

            if (runningTests.Any(test => test.Status == TaskStatus.Running ||
                                         test.Status == TaskStatus.WaitingForActivation ||
                                         test.Status == TaskStatus.WaitingToRun ||
                                         test.Status == TaskStatus.WaitingForChildrenToComplete))
            {
                // Continue other tasks in the background while returning
                // Create a promise task
                var remainingTasks = Task.WhenAll(runningTests);

                return remainingTasks;
            }

            return null;
        }
    }
}