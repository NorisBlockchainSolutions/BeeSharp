using System;
using System.Linq;
using Org.BouncyCastle.Math;

namespace BeeSharp.Auth.Signatures
{
    // Based on ecdsa/util.py
    /// Version 0.17.0
    public class SignatureEncoder : ISignatureEncoder
    {
        /// <summary>
        ///     Encode the signature to raw format
        /// </summary>
        /// <param name="r">First parameter of the signature.</param>
        /// <param name="s">Second parameter of the signature.</param>
        /// <param name="order">Order of the curve over which the signature was computed.</param>
        /// <returns>Raw encoding of the ECDSA signature</returns>
        /// <exception cref="ArgumentException">Thrown when the signature is invalid.</exception>
        public byte[] SigRawEncodeString(BigInteger r, BigInteger s, BigInteger order)
        {
            var orderLength = order.ToByteArrayUnsigned()!.Length;
            var rStr = NumberToString(r, orderLength);
            var sStr = NumberToString(s, orderLength);

            return rStr!.Concat(sStr!).ToArray();
        }

        private static byte[] NumberToString(BigInteger number, int orderLength)
        {
            var result = number.ToByteArray();
            if (result is null || result.Length != orderLength)
                throw new ArgumentException("Invalid signature: invalid length!", nameof(number));
            return result;
        }
    }
}