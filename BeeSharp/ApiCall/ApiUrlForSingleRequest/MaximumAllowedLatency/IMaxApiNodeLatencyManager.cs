using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiUrlForSingleRequest.MaximumAllowedLatency
{
    public interface IMaxApiNodeLatencyManager
    {
        public long GetMaxApiNodeLatency(ISortedIDictionary<long, string> timedApiNodeUrls);
    }
}