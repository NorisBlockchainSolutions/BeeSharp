using System.Linq;
using BeeSharp.root;
using Org.BouncyCastle.Crypto.Digests;

namespace BeeSharp.Auth.ECKeyManagement
{
    public class DigestCalculator : IDigestCalculator
    {
        private readonly IHexUtils _hexUtils;

        public DigestCalculator(IHexUtils hexUtils)
        {
            _hexUtils = hexUtils;
        }

        /// <summary>
        ///     Create a SHA256-Digest of the data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The sha256-digest.</returns>
        public byte[] CreateDigest(byte[] data)
        {
            var digest = new Sha256Digest();

            digest.BlockUpdate(data, 0, data.Length);

            var result = new byte[digest.GetDigestSize()];
            digest.DoFinal(result, 0);
            return result;
        }

        /// <summary>
        ///     Create a SHA256-Digest of the transaction data and the chainId.
        /// </summary>
        /// <param name="transactionData">The transaction data.</param>
        /// <param name="chainId">The chain id as hex string.</param>
        /// <returns>The sha256-digest.</returns>
        public byte[] CreateDigest(byte[] transactionData, string chainId)
        {
            // RegisterNew chainId + transactionData concatenation
            var concat = _hexUtils.HexStringToByteArray(chainId).Concat(transactionData).ToArray();

            return CreateDigest(concat);
        }
    }
}