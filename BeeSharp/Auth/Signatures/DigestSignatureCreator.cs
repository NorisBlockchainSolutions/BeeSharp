using System.Linq;
using System.Security.Cryptography;
using BeeSharp.Auth.ECKeyManagement;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;

namespace BeeSharp.Auth.Signatures
{
    public class DigestSignatureCreator : IDigestSignatureCreator
    {
        private readonly IDigestCalculator _digestCalculator;

        public DigestSignatureCreator(IDigestCalculator digestCalculator)
        {
            _digestCalculator = digestCalculator;
        }

        /// <summary>
        ///     Sign a digest. returns r and s signature tuple.
        /// </summary>
        /// <param name="digest">The digest.</param>
        /// <param name="privateKey">The user's private key to sign with.</param>
        /// <returns>The signature as r and s signature tuple.</returns>
        /// <exception cref="CryptographicException"></exception>
        public (BigInteger, BigInteger) SignDigest(byte[] digest, ECPrivateKeyParameters privateKey)
        {
            // Use a deterministic k calculator
            // See RFC 6979
            var kCalculator = new MultiHMacDsaKCalculator(
                new Sha256Digest());

            // Initialize signer
            var signer = new ECDsaSigner(kCalculator);
            signer.Init(true, privateKey);

            // Since we do not know, if the signature will be canonical or not, we simply create signatures until one is.
            // Therefore, a counter needs to be added, or otherwise each run would result in the same signature.
            (BigInteger, BigInteger)? signature = null;
            byte counter = 0;
            do
            {
                counter += 1;

                // Add counter to create a new digest for each iteration.
                var kDigest = _digestCalculator.CreateDigest(
                    digest.Concat(new[] {counter}).ToArray()
                );
                // Initialize kCalculator with new digest
                kCalculator.Init2(privateKey.Parameters!.N!, privateKey.D!,
                    kDigest);

                // Contains r and s value of the signature
                // r: ephemeral key k * base point. k has to change for every signature!
                var signatureBigInt = signer.GenerateSignature(digest);

                // Determine if signature is canonical
                if (signatureBigInt is not null && signatureBigInt.Length == 2 &&
                    signatureBigInt[0]!.ToByteArray()!.Length == 32 &&
                    signatureBigInt[1]!.ToByteArray()!.Length == 32)
                    signature = (signatureBigInt[0], signatureBigInt[1]);
            } while (signature is null);

            return signature!.Value;
        }
    }
}