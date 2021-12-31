using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators
{
    public interface IAwaitAllCreator
    {
        /// <summary>
        ///     Update the internal ranking of all known apiNodes, sorted by elapsedTime.
        /// </summary>
        /// <returns>Awaitable.</returns>
        Task CreateApiNodeRankingAsync(ISortedIDictionary<long, string> apiNodeUrlList,
            string[] apiNodeUrls, ushort timeout);
    }
}