using BeeSharp.Auth.ECKeyManagement.KeyProcessing;

namespace BeeSharp.Auth.Signatures
{
    public interface ISignatureCreator
    {
        /// <summary>
        ///     Create a signature to a serialized transaction.
        /// </summary>
        /// <param name="message">The serialized transaction.</param>
        /// <param name="privateKey">The private user key to create the signature with.</param>
        /// <returns>The signature as hex string.</returns>
        string CreateSignature(byte[] message,
            EcdsaPrivateKey privateKey);
    }
}