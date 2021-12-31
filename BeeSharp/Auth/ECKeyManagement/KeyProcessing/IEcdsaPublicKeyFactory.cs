using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public interface IEcdsaPublicKeyFactory
    {
        EcdsaPublicKey Create(string base58EncodedPublicKey);
        EcdsaPublicKey Create(ECPublicKeyParameters publicKeyParameters);
    }
}