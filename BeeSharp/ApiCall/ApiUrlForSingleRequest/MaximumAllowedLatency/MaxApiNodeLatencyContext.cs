namespace BeeSharp.ApiCall.ApiUrlForSingleRequest.MaximumAllowedLatency
{
    public readonly struct MaxApiNodeLatencyContext
    {
        public long SingleRequestMeasuringLimit { get; }
        public ushort SingleRequestMaxLatencyIncrease { get; }

        public MaxApiNodeLatencyContext(long singleRequestMeasuringLimit, ushort singleRequestMaxLatencyIncrease)
        {
            SingleRequestMeasuringLimit = singleRequestMeasuringLimit;
            SingleRequestMaxLatencyIncrease = singleRequestMaxLatencyIncrease;
        }

        public void Deconstruct(out long singleRequestMeasuringLimit, out ushort singleRequestMaxLatencyIncrease)
        {
            singleRequestMeasuringLimit = SingleRequestMeasuringLimit;
            singleRequestMaxLatencyIncrease = SingleRequestMaxLatencyIncrease;
        }
    }
}