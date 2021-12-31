using System.Security.Cryptography;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

namespace BeeSharp.Auth.Signatures
{
    public interface IDigestSignatureCreator
    {
        /// <summary>
        ///     Sign a digest. returns concatenated r + s signature values.
        /// </summary>
        /// <param name="digest"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        /// <exception cref="CryptographicException"></exception>
        public (BigInteger, BigInteger) SignDigest(byte[] digest, ECPrivateKeyParameters privateKey);
    }
}