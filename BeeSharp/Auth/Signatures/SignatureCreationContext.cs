namespace BeeSharp.Auth.Signatures
{
    public readonly struct SignatureCreationContext
    {
        // Length: 256 characters
        public string ChainId { get; }

        public SignatureCreationContext(string chainId)
        {
            ChainId = chainId;
        }
    }
}