using System;
using System.Diagnostics;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.ApiCall.ApiUrlForSingleRequest.MaximumAllowedLatency
{
    public class MaxApiNodeLatencyManager : IMaxApiNodeLatencyManager
    {
        private readonly ushort _apiNodeMaxLatencyIncreasePerRequest;
        private readonly Stopwatch _timeSinceRequest;
        private readonly long _timeSinceRequestStopwatchLimit;
        private long _maxApiNodeLatency;

        public MaxApiNodeLatencyManager(IStopwatchFactory stopwatchFactory, MaxApiNodeLatencyContext context)
        {
            _timeSinceRequest = stopwatchFactory.Create();

            if (context.SingleRequestMeasuringLimit == 0 && context.SingleRequestMaxLatencyIncrease == 0)
                throw new ArgumentException("Cannot instantiate without instantiated context!",
                    nameof(context));

            (_timeSinceRequestStopwatchLimit, _apiNodeMaxLatencyIncreasePerRequest) = context;
        }

        /// <summary>
        /// Calculate the maximum api node latency by measuring the amount of requests in a timeframe..
        /// </summary>
        /// <param name="timedApiNodeUrls">The timed api node urls from which the maximum api node latency is
        /// calculated.</param>
        /// <returns>The maximum api node latency.</returns>
        /// <exception cref="ArgumentException">Thrown when timedApiNodeUrls is empty or null.</exception>
        public long GetMaxApiNodeLatency(ISortedIDictionary<long, string> timedApiNodeUrls)
        {
            if (timedApiNodeUrls == null || timedApiNodeUrls.Count == 0)
                throw new ArgumentException("Cannot get latency of empty dictionary!", nameof(timedApiNodeUrls));

            if (_timeSinceRequest.ElapsedMilliseconds > _timeSinceRequestStopwatchLimit)
            {
                // Reset stopwatch
                _timeSinceRequest.Stop();
                _timeSinceRequest.Reset();
            }

            if (!_timeSinceRequest.IsRunning)
            {
                _timeSinceRequest.Start();

                // Reset maxApiNodeLatency
                _maxApiNodeLatency = timedApiNodeUrls.First().Key;
                return _maxApiNodeLatency;
            }

            _maxApiNodeLatency += _apiNodeMaxLatencyIncreasePerRequest;
            return _maxApiNodeLatency;
        }
    }
}