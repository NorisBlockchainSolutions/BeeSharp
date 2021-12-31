using Org.BouncyCastle.Math;

namespace BeeSharp.Auth.Signatures
{
    public interface ISignatureEncoder
    {
        /// <summary>
        ///     Encode the signature to raw format
        /// </summary>
        /// <param name="r">First parameter of the signature.</param>
        /// <param name="s">Second parameter of the signature.</param>
        /// <param name="order">Order of the curve over which the signature was computed.</param>
        /// <returns>Raw encoding of the ECDSA signature</returns>
        byte[] SigRawEncodeString(BigInteger r, BigInteger s, BigInteger order);
    }
}