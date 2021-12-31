using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public class EcdsaPublicKeyFactory : IEcdsaPublicKeyFactory
    {
        private readonly IPublicKeyTransformer _publicKeyTransformer;

        public EcdsaPublicKeyFactory(IPublicKeyTransformer publicKeyTransformer)
        {
            _publicKeyTransformer = publicKeyTransformer;
        }

        public EcdsaPublicKey Create(string base58EncodedPublicKey)
        {
            return new(_publicKeyTransformer, base58EncodedPublicKey);
        }

        public EcdsaPublicKey Create(ECPublicKeyParameters publicKeyParameters)
        {
            return new(_publicKeyTransformer, publicKeyParameters);
        }
    }
}