using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public interface IPrivateKeyTransformer
    {
        /// <summary>
        ///     Returns a private key from its base58Str (string) representation.
        /// </summary>
        /// <param name="wif">The private key to transform.</param>
        /// <returns>The private key as usable ECPrivateKey.</returns>
        ECPrivateKeyParameters GetPrivateKeyFromWif(string wif);

        string GetWifFromPrivateKey(ECPrivateKeyParameters privateKey);

        /// <summary>
        ///     Returns a public key from its private key.
        /// </summary>
        /// <param name="privateKey">The private key to calculate the public key from.</param>
        /// <returns>The public key as usable ECPublicKey.</returns>
        ECPublicKeyParameters GetPublicKeyFromPrivateKey(ECPrivateKeyParameters privateKey);
    }
}