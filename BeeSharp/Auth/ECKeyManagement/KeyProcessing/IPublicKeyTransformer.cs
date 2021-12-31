using System;
using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public interface IPublicKeyTransformer
    {
        /// <summary>
        ///     Returns a public key from its base58 representation.
        /// </summary>
        /// <param name="base58Str">The base58 encoded string.</param>
        /// <returns>The public key.</returns>
        /// <exception cref="ArgumentException">Thrown when the base58Str is invalid.</exception>
        ECPublicKeyParameters GetPublicKeyFromBase58(string base58Str);

        /// <summary>
        ///     Convert an ec public key to its base58Str representation.
        /// </summary>
        /// <param name="publicKey">The public key.</param>
        /// <returns>The base58Str public key.</returns>
        string GetBase58StrFromPublicKey(ECPublicKeyParameters publicKey);
    }
}