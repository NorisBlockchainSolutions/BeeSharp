using System.Diagnostics;
using BeeSharp.ApiCall.ApiUrlForSingleRequest.MaximumAllowedLatency;

namespace BeeSharp.root
{
    public class StopwatchFactory : IStopwatchFactory
    {
        public Stopwatch Create()
        {
            return new();
        }
    }
}