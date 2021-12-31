using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public interface IEcdsaPrivateKeyFactory
    {
        EcdsaPrivateKey Create(string privateKeyWif);
        EcdsaPrivateKey Create(ECPrivateKeyParameters privateKey);
        public EcdsaPrivateKey Create();
    }
}