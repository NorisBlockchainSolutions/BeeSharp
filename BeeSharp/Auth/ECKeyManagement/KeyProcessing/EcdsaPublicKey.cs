using System;
using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public class EcdsaPublicKey
    {
        private readonly IPublicKeyTransformer _publicKeyTransformer;
        private string? _base58Encoded;
        private ECPublicKeyParameters? _publicKey;

        /// <summary>
        ///     Create a secp256k1 ecdsa public key.
        /// </summary>
        /// <param name="publicKeyTransformer">The public key transformer.</param>
        /// <param name="publicKey">The public key parameters.</param>
        public EcdsaPublicKey(IPublicKeyTransformer publicKeyTransformer, ECPublicKeyParameters publicKey)
        {
            _publicKeyTransformer = publicKeyTransformer;
            _publicKey = publicKey;
            _base58Encoded = null!;
        }

        /// <summary>
        ///     Create a secp256k1 ecdsa public key.
        /// </summary>
        /// <param name="publicKeyTransformer">The public key transformer.</param>
        /// <param name="base58Encoded">The base58-encoded string.</param>
        public EcdsaPublicKey(IPublicKeyTransformer publicKeyTransformer, string base58Encoded)
        {
            _publicKeyTransformer = publicKeyTransformer;
            _base58Encoded = base58Encoded;
            _publicKey = null!;
        }

        /// <summary>
        ///     Returns the public key.
        /// </summary>
        /// <returns>The public key.</returns>
        /// <exception cref="ArgumentException">Thrown when the used base58Str is invalid.</exception>
        public ECPublicKeyParameters GetPublicKey()
        {
            return _publicKey ??= _publicKeyTransformer.GetPublicKeyFromBase58(_base58Encoded!);
        }

        /// <summary>
        ///     Returns the base58Str representation.
        /// </summary>
        /// <returns>The base58Str public key.</returns>
        public string GetBase58Encoded()
        {
            return _base58Encoded ??= _publicKeyTransformer.GetBase58StrFromPublicKey(_publicKey!);
        }

        /// <summary>
        ///     Returns the encoded public key.
        /// </summary>
        /// <returns>The encoded public key.</returns>
        /// <exception cref="ArgumentException">Thrown when the used base58Str is invalid.</exception>
        public byte[] GetEncodedKey()
        {
            return GetPublicKey()!.Q!.GetEncoded(true)!;
        }
    }
}