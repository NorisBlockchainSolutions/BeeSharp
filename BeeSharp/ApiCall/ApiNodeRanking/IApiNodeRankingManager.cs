using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiNodeRanking
{
    public interface IApiNodeRankingManager
    {
        Task RunInitialApiNodeRankingAsync();
        ISortedIDictionary<long, string> GetCurrentTimedApiNodes();
        Task UpdateApiNodeRankingAsync();
        public Task RemoveUrlFromCurrentRankingAsync(string url);
    }
}