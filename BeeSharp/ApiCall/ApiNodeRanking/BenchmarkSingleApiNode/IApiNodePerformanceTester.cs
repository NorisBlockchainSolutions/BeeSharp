using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode
{
    public interface IApiNodePerformanceTester
    {
        /// <summary>
        ///     Measure the performance of a single apiNode connection.
        ///     Adds the node to the list of tested apiNodes, if successful.
        /// </summary>
        /// <param name="urlList">The benchmarked list of apiNode urls.</param>
        /// <param name="nodeUrl">The url of the apiNode to check.</param>
        /// <param name="timeout">The webClient timeout.</param>
        /// <returns>The elapsed time in ms, or -1 if an error occurred.</returns>
        Task TestNodePerformanceAsync(ISortedIDictionary<long, string> urlList, string nodeUrl, ushort timeout);
    }
}