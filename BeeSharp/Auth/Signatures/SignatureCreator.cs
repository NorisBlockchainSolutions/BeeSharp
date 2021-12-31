using System;
using BeeSharp.Auth.ECKeyManagement;
using BeeSharp.Auth.ECKeyManagement.KeyProcessing;
using BeeSharp.root.Exceptions;

namespace BeeSharp.Auth.Signatures
{
    public class SignatureCreator : ISignatureCreator
    {
        private readonly string _chainId;
        private readonly IDigestCalculator _digestCalculator;
        private readonly IDigestSignatureCreator _digestSignatureCreator;
        private readonly IRecoveryParameterCreator _recoveryParameterCreator;
        private readonly ISignatureEncoder _signatureEncoder;

        public SignatureCreator(IDigestCalculator digestCalculator,
            IRecoveryParameterCreator recoveryParameterCreator,
            IDigestSignatureCreator digestSignatureCreator,
            ISignatureEncoder signatureEncoder,
            SignatureCreationContext context)
        {
            _digestCalculator = digestCalculator;
            _recoveryParameterCreator = recoveryParameterCreator;
            _chainId = context.ChainId;
            _digestSignatureCreator = digestSignatureCreator;
            _signatureEncoder = signatureEncoder;
        }

        /// <summary>
        ///     Create a signature to a serialized transaction.
        /// </summary>
        /// <param name="message">The serialized transaction.</param>
        /// <param name="privateKey">The private user key to create the signature with.</param>
        /// <returns>The signature as hex string.</returns>
        /// <exception cref="MathException">
        ///     Thrown when no valid recovery parameter can be calculated for the public
        ///     key. Most likely the private key is invalid.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the signature is invalid or a calculation fails. Most likely
        ///     the private key is invalid.
        /// </exception>
        public string CreateSignature(byte[] message,
            EcdsaPrivateKey privateKey)
        {
            // Instead of signing the message, its digest is signed.
            var digest = _digestCalculator.CreateDigest(message, _chainId);

            var signature = _digestSignatureCreator.SignDigest(digest, privateKey.GetPrivateKey());

            // extract the recovery parameter
            var publicKey = privateKey.GetPublicKey();
            var recoveryParameter = _recoveryParameterCreator.GetPublicKeyRecoveryParameter(
                digest, signature, publicKey.GetPublicKey());

            // Add additional protocol information
            // Add compressed information (4) and compact information (27)
            recoveryParameter = recoveryParameter + 4 + 27;

            // Concatenate r + s
            var signatureConcatenated =
                _signatureEncoder.SigRawEncodeString(signature.Item1, signature.Item2,
                    publicKey.GetPublicKey().Parameters!.N!);

            // RegisterNew hex value
            var result = BitConverter.ToString(signatureConcatenated).Replace("-", "").ToLower();

            // Add recovery parameter as little endian unsigned char (byte-size 1) at the beginning of the signature
            return $"{recoveryParameter.ToString("X2").ToLower()}{result}";
        }
    }
}