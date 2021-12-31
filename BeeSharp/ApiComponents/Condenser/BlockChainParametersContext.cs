namespace BeeSharp.ApiComponents.Condenser
{
    /// <summary>
    ///     Contains parameters for interaction with the blockchain.
    /// </summary>
    public readonly struct BlockChainParametersContext
    {
        // Prefix for public keys
        public string ChainPrefix { get; }

        // Prefix for private keys
        public string WifPrefix { get; }

        public BlockChainParametersContext(string wifPrefix, string chainPrefix)
        {
            ChainPrefix = chainPrefix;
            WifPrefix = wifPrefix;
        }
    }
}