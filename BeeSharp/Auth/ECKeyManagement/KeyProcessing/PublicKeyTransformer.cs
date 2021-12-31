using System;
using System.Linq;
using BeeSharp.Auth.Provider;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using SimpleBase;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public class PublicKeyTransformer : IPublicKeyTransformer
    {
        private readonly ChainParameterModel _chainParameterModel;
        private readonly IDomainParametersProvider _domainParametersProvider;

        public PublicKeyTransformer(IDomainParametersProvider domainParametersProvider,
            ChainParameterModel chainParameterModel)
        {
            _domainParametersProvider = domainParametersProvider;
            _chainParameterModel = chainParameterModel;
        }

        /// <summary>
        ///     Returns a public key from its base58 representation.
        /// </summary>
        /// <param name="base58Str">The base58 encoded string.</param>
        /// <returns>The public key.</returns>
        /// <exception cref="ArgumentException">Thrown when the base58Str is invalid.</exception>
        public ECPublicKeyParameters GetPublicKeyFromBase58(string base58Str)
        {
            if (!base58Str.StartsWith(_chainParameterModel.ChainPrefix))
                throw new ArgumentException("Invalid base58Str: does not contain chainPrefix!",
                    nameof(base58Str));

            // Remove prefix from string
            var rawString = base58Str.AsSpan()[_chainParameterModel.ChainPrefix.Length..];
            var rawKeyWithChecksum = Base58.Bitcoin.Decode(rawString).ToArray();

            var rawKey = rawKeyWithChecksum[..^4];

            var checksum = CreateChecksum(rawKey);
            if (!checksum.SequenceEqual(rawKeyWithChecksum[^4..]))
                throw new ArgumentException("Invalid base58Str: Invalid checksum!", nameof(base58Str));

            var q = _domainParametersProvider.Get().Curve!.DecodePoint(rawKey);

            return new ECPublicKeyParameters("ECDSA", q!, _domainParametersProvider.Get());
        }

        /// <summary>
        ///     Convert an ec public key to its base58Str representation.
        /// </summary>
        /// <param name="publicKey">The public key.</param>
        /// <returns>The base58Str public key.</returns>
        public string GetBase58StrFromPublicKey(ECPublicKeyParameters publicKey)
        {
            var rawKey = publicKey.Q!.GetEncoded(true);

            var checksum = CreateChecksum(rawKey!);
            rawKey = rawKey!.Concat(checksum).ToArray();

            var base58Key = Base58.Bitcoin.Encode(rawKey);

            // Add chainPrefix
            return $"{_chainParameterModel.ChainPrefix}{base58Key}";
        }

        /// <summary>
        ///     Create a checksum using ripeMD160Digest.
        /// </summary>
        /// <param name="rawKey">The key to create a checksum of.</param>
        /// <returns>The checksum.</returns>
        private byte[] CreateChecksum(byte[] rawKey)
        {
            // Create the digest 
            var ripemdDigestCreator = new RipeMD160Digest();
            ripemdDigestCreator.BlockUpdate(rawKey!, 0, rawKey!.Length);
            var digest = new byte[ripemdDigestCreator.GetDigestSize()];
            ripemdDigestCreator.DoFinal(digest, 0);

            // We only need the first four bytes
            var checksum = digest[..4];
            return checksum;
        }
    }
}