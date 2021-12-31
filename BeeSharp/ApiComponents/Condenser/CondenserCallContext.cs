namespace BeeSharp.ApiComponents.Condenser
{
    public readonly struct CondenserCallContext
    {
        /// <summary>
        /// This parameter controls, how many nodes are tried to get a successful response (non-error-code) from a
        /// request, until giving up.
        /// </summary>
        public ushort MaxRequestRetries { get; }

        public CondenserCallContext(ushort maxRequestRetries)
        {
            MaxRequestRetries = maxRequestRetries;
        }

        public void Deconstruct(out ushort maxRequestRetries)
        {
            maxRequestRetries = MaxRequestRetries;
        }
    }
}