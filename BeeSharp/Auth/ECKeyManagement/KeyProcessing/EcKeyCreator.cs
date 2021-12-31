using BeeSharp.Auth.Provider;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public class EcKeyCreator : IEcKeyCreator
    {
        private readonly ECDomainParameters _domainParameters;
        private readonly SecureRandom _secureRandom;

        public EcKeyCreator(IDomainParametersProvider domainParametersProvider,
            ISecureRandomProvider secureRandomProvider)
        {
            _domainParameters = domainParametersProvider.Get();
            _secureRandom = secureRandomProvider.Get();
        }

        /// <summary>
        ///     Create a new ECDSA keypair using the global secureRandom and configured domain parameters.
        /// </summary>
        /// <returns>The keypair.</returns>
        public AsymmetricCipherKeyPair CreateKeyPair()
        {
            var keyParams = new ECKeyGenerationParameters(_domainParameters, _secureRandom);

            var generator = new ECKeyPairGenerator("ECDSA");
            generator.Init(keyParams);

            // a private key needs to have a length of 256bit/32byte (keys are usually derived by SHA256(SHA512(bk)))
            // where bk = brainKey + " " + sequence (sequence for consecutive keys)
            AsymmetricCipherKeyPair keyPair;
            do
            {
                keyPair = generator.GenerateKeyPair()!;
            } while (((ECPrivateKeyParameters) keyPair!.Private!)!.D!.ToByteArray()!.Length != 32);

            return keyPair;
        }
    }
}