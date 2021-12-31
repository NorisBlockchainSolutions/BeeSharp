using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiUrlForSingleRequest
{
    public interface ISingleApiUrlHandler
    {
        /// <summary>
        ///     Get an api url for a single request with unknown context (unknown, whether other requests are made
        ///     and in which time).
        /// </summary>
        /// <returns>The api url.</returns>
        Task<string?> GetApiUrlAsync(ISortedIDictionary<long, string> timedApiNodeUrls);
    }
}