using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;

namespace BeeSharp.Auth.Signatures
{
    public interface IRecoveryParameterCreator
    {
        /// <summary>
        ///     Create the public key recovery parameter to a signature, so the backend knows which public key to use.
        /// </summary>
        /// <param name="digest">The digest that is signed.</param>
        /// <param name="signature">The signature of the digest.</param>
        /// <param name="publicKey">The public key of the user key.</param>
        /// <returns></returns>
        public int GetPublicKeyRecoveryParameter(byte[] digest, (BigInteger, BigInteger) signature,
            ECPublicKeyParameters publicKey);
    }
}