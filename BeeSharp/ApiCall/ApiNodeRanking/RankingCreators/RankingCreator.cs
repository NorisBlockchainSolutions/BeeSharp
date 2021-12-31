using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators
{
    public abstract class RankingCreator
    {
        private readonly IApiNodePerformanceTester _apiNodePerformanceTester;
        private readonly IListFactory<Task> _listFactory;

        protected RankingCreator(IApiNodePerformanceTester apiNodePerformanceTester, IListFactory<Task> listFactory)
        {
            _apiNodePerformanceTester = apiNodePerformanceTester;
            _listFactory = listFactory;
        }

        /// <summary>
        ///     Initialize the apiNode performance tests.
        /// </summary>
        /// <returns>The list of apiNode performance test tasks.</returns>
        /// <exception cref="ArgumentException">Thrown when apiNodeUrls is invalid/empty.</exception>
        protected IList<Task> CreateApiNodeRankingTasks(ISortedIDictionary<long, string> apiNodeUrlList,
            string[] apiNodeUrls, ushort timeout)
        {
            if (apiNodeUrls == null || apiNodeUrls.Length == 0)
                throw new ArgumentException("Cannot create api node ranking without api nodes!", nameof(apiNodeUrls));

            // Test performance of each node
            var result = _listFactory.Create();
            foreach (var apiNodeUrl in apiNodeUrls)
                result.Add(_apiNodePerformanceTester.TestNodePerformanceAsync(apiNodeUrlList, apiNodeUrl, timeout));

            return result;
        }
    }
}