using System;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;
using BeeSharp.ApiCall.ApiUrlForSingleRequest.MaximumAllowedLatency;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiCall.ApiUrlForSingleRequest
{
    public class SingleApiUrlHandler : ISingleApiUrlHandler
    {
        private readonly IMaxApiNodeLatencyManager _maxApiNodeLatencyManager;
        private readonly Random _rnd;

        public SingleApiUrlHandler(IMaxApiNodeLatencyManager maxApiNodeLatencyManager, IRandomProvider randomProvider)
        {
            _maxApiNodeLatencyManager = maxApiNodeLatencyManager;
            _rnd = randomProvider.Rnd;
        }

        /// <summary>
        ///     Get an api url for a single request with unknown context (unknown, whether other requests are made
        ///     and in which time).
        /// </summary>
        /// <returns>The api url.</returns>
        /// <exception cref="OutOfNodesException">Thrown when timedApiNodeUrls is empty.</exception>
        public async Task<string?> GetApiUrlAsync(ISortedIDictionary<long, string> timedApiNodeUrls)
        {
            if (timedApiNodeUrls is null || timedApiNodeUrls.Count == 0)
                throw new OutOfNodesException("Cannot get api url from empty list!");
            
            var localTimedApiNodeUrls = await timedApiNodeUrls.CloneAsync();
            if (localTimedApiNodeUrls is null || localTimedApiNodeUrls.Count == 0)
                throw new OutOfNodesException("Cannot get api url from empty list!");

            if (localTimedApiNodeUrls.Count == 1)
                // The list only contains one item (after initialization, or if only one url is used)
                return localTimedApiNodeUrls.First().Value;

            // Create local copy to prevent modification while operating
            var nodeListKeys = localTimedApiNodeUrls.GetKeys();

            var maxApiNodeLatency = _maxApiNodeLatencyManager.GetMaxApiNodeLatency(localTimedApiNodeUrls);

            // Check if second element is within allowed latency
            if (nodeListKeys[1] <= maxApiNodeLatency)
            {
                // Get last index that determines the range
                var index = localTimedApiNodeUrls.GetKeyIndexOfLastFittingKey(
                    n => n.Key <= maxApiNodeLatency
                );

                // inclusive lower, exclusive upper bound (therefore + 1)
                var latencyToUse = nodeListKeys[_rnd.Next(0, index + 1)];

                return localTimedApiNodeUrls[latencyToUse];
            }

            return localTimedApiNodeUrls.First().Value;
        }
    }
}