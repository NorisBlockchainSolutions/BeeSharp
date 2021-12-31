namespace BeeSharp.Auth.ECKeyManagement
{
    public interface IDigestCalculator
    {
        /// <summary>
        ///     Create a SHA256-Digest of the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The sha256-digest.</returns>
        public byte[] CreateDigest(byte[] data);

        /// <summary>
        ///     Create a SHA256-Digest of the transaction data and the chainId.
        /// </summary>
        /// <param name="transactionData">The transaction data.</param>
        /// <param name="chainId">The chain id.</param>
        /// <returns>The sha256-digest.</returns>
        byte[] CreateDigest(byte[] transactionData, string chainId);
    }
}