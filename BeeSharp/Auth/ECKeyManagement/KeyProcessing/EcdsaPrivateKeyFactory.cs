using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    /// <summary>
    ///     This class is a factory to create ecdsaPrivateKeys.
    /// </summary>
    public class EcdsaPrivateKeyFactory : IEcdsaPrivateKeyFactory
    {
        private readonly IPrivateKeyTransformer _privateKeyTransformer;
        private readonly IPublicKeyTransformer _publicKeyTransformer;
        private readonly IEcKeyCreator _ecKeyCreator;

        public EcdsaPrivateKeyFactory(IPrivateKeyTransformer privateKeyTransformer,
            IPublicKeyTransformer publicKeyTransformer, IEcKeyCreator ecKeyCreator)
        {
            _privateKeyTransformer = privateKeyTransformer;
            _publicKeyTransformer = publicKeyTransformer;
            _ecKeyCreator = ecKeyCreator;
        }

        public EcdsaPrivateKey Create(string privateKeyWif)
        {
            return new(_privateKeyTransformer, _publicKeyTransformer, privateKeyWif);
        }

        public EcdsaPrivateKey Create(ECPrivateKeyParameters privateKey)
        {
            return new(_privateKeyTransformer, _publicKeyTransformer, privateKey);
        }

        public EcdsaPrivateKey Create()
        {
            var privateKey = _ecKeyCreator.CreateKeyPair().Private;
            return new(_privateKeyTransformer, _publicKeyTransformer, (ECPrivateKeyParameters)privateKey!);
        }
    }
}