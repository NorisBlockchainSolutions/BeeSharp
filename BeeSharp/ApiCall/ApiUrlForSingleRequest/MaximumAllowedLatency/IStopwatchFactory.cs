using System.Diagnostics;

namespace BeeSharp.ApiCall.ApiUrlForSingleRequest.MaximumAllowedLatency
{
    public interface IStopwatchFactory
    {
        public Stopwatch Create();
    }
}