namespace BeeSharp.ApiCall
{
    public readonly struct ApiCallContext
    {
        /// <summary>
        /// This parameter controls, how many nodes are tried on a network connection timeout, until giving up.
        /// </summary>
        public ushort MaxConnectionRetries { get; }
        
        /// <summary>
        /// This parameter controls, how long each nodes has to respond until a timeout occurs.
        /// Unlike NodeRankingTimeout, this timeout is used for regular web requests.
        /// </summary>
        public ushort WebRequestTimeout { get; }

        public ApiCallContext(ushort maxConnectionRetries, ushort webRequestTimeout)
        {
            MaxConnectionRetries = maxConnectionRetries;
            WebRequestTimeout = webRequestTimeout;
        }

        public void Deconstruct(out ushort maxConnectionRetries, out ushort nodeRankingTimeout)
        {
            maxConnectionRetries = MaxConnectionRetries;
            nodeRankingTimeout = WebRequestTimeout;
        }
    }
}