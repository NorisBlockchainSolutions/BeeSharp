using System;

namespace BeeSharp.ApiCall.ApiNodeRanking
{
    public readonly struct ApiNodeRankingManagerContext
    {
        /// <summary>
        /// List of all trusted ApiNode urls.
        /// </summary>
        public string[] ApiNodeUrls { get; }
        
        /// <summary>
        /// How long has each node to respond until a timeout occurs.
        /// Unlike WebRequestTimeout, this timeout is specifically for NodeRanking requests.
        /// </summary>
        public ushort NodeRankingTimeout { get; }

        public ApiNodeRankingManagerContext(string[] apiNodeUrls, ushort nodeRankingTimeout)
        {
            if (apiNodeUrls.Length == 0)
                throw new ArgumentException("Cannot create context without apiNodeUrls!", nameof(apiNodeUrls));

            ApiNodeUrls = apiNodeUrls;
            NodeRankingTimeout = nodeRankingTimeout;
        }

        public void Deconstruct(out string[] apiNodeUrls, out ushort timeout)
        {
            apiNodeUrls = ApiNodeUrls;
            timeout = NodeRankingTimeout;
        }
    }
}