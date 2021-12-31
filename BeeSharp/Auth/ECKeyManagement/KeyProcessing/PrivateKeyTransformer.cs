using System;
using System.Linq;
using BeeSharp.Auth.Provider;
using BeeSharp.root.Helper;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using SimpleBase;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public class PrivateKeyTransformer : IPrivateKeyTransformer
    {
        private readonly ChainParameterModel _chainParameterModel;
        private readonly ECDomainParameters _domainParameters;

        public PrivateKeyTransformer(IDomainParametersProvider domainParametersProvider,
            ChainParameterModel chainParameterModel)
        {
            _chainParameterModel = chainParameterModel;
            _domainParameters = domainParametersProvider.Get();
        }

        /// <summary>
        ///     Returns a private key from its base58Str (string) representation.
        /// </summary>
        /// <param name="wif">The private key to transform.</param>
        /// <returns>The private key as usable ECPrivateKey.</returns>
        /// <exception cref="ArgumentException">Thrown when the wif cannot be decoded to a valid private key.</exception>
        public ECPrivateKeyParameters GetPrivateKeyFromWif(string wif)
        {
            var d = GetDFromWif(wif);
            return new ECPrivateKeyParameters("ECDSA", d, _domainParameters);
        }

        /// <summary>
        ///     Convert a private key to its wif representation.
        /// </summary>
        /// <param name="privateKey">The private key to use.</param>
        /// <returns>The wif representation of the private key.</returns>
        public string GetWifFromPrivateKey(ECPrivateKeyParameters privateKey)
        {
            var rawKey = privateKey.D!.ToByteArrayUnsigned();
            var rawPrefixedKey = ByteHelper.StringToByteArray(_chainParameterModel.WifPrefix)
                .Concat(rawKey!).ToArray();

            // create checksum (sha256 applied twice)
            var sha256DigestCreator = new Sha256Digest();
            sha256DigestCreator.BlockUpdate(rawPrefixedKey!, 0, rawPrefixedKey!.Length);
            var firstDigest = new byte[sha256DigestCreator.GetDigestSize()];
            sha256DigestCreator.DoFinal(firstDigest, 0);

            sha256DigestCreator.Reset();
            sha256DigestCreator.BlockUpdate(firstDigest, 0, firstDigest.Length);
            var secondDigest = new byte[sha256DigestCreator.GetDigestSize()];
            sha256DigestCreator.DoFinal(secondDigest, 0);

            // take first 4 bytes
            var checksum = secondDigest[..4];

            // build raw wif sequence from key + checksum
            var rawWif = rawPrefixedKey.Concat(checksum).ToArray();
            var wif = Base58.Bitcoin.Encode(rawWif);
            return wif;
        }

        /// <summary>
        ///     Returns a public key from its private key.
        /// </summary>
        /// <param name="privateKey">The private key to calculate the public key from.</param>
        /// <returns>The public key as usable ECPublicKey.</returns>
        /// <exception cref="ArgumentException">Thrown when the privateKey is invalid.</exception>
        public ECPublicKeyParameters GetPublicKeyFromPrivateKey(ECPrivateKeyParameters privateKey)
        {
            var q = _domainParameters.G!.Multiply(privateKey.D!);
            return new ECPublicKeyParameters("ECDSA", q!, _domainParameters);
        }

        /// <summary>
        ///     Calculate a privateKey D from a wif.
        /// </summary>
        /// <param name="wif">The private key as wif.</param>
        /// <returns>The privateKey D as BigInteger.</returns>
        /// <exception cref="ArgumentException">Thrown when wif is invalid.</exception>
        private BigInteger GetDFromWif(string wif)
        {
            var keyBuffer = Base58.Bitcoin.Decode(wif).ToArray();

            if (keyBuffer.Length < 5) throw new ArgumentException("Invalid wif: buffer is too small!");

            // Remove first and last four bytes
            var rawResult = new byte[keyBuffer.Length - 5];
            Array.Copy(keyBuffer, 1, rawResult, 0, rawResult.Length);

            // Create private-key from raw
            return new BigInteger(1, rawResult);
        }
    }
}