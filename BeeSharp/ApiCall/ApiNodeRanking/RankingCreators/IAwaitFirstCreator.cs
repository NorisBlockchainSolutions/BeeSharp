using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators
{
    public interface IAwaitFirstCreator
    {
        /// <summary>
        ///     Update the internal ranking of all known apiNodes, sorted by elapsedTime.
        ///     Run remaining tasks after the first one completes in thread.
        /// </summary>
        /// <returns>Awaitable.</returns>
        Task<Task?> CreateApiNodeRankingAsync(ISortedIDictionary<long, string> apiNodeUrlList,
            string[] apiNodeUrls, ushort timeout);
    }
}