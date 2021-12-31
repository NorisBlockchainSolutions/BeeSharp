using System;
using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public class EcdsaPrivateKey
    {
        private readonly IPrivateKeyTransformer _privateKeyTransformer;
        private readonly IEcdsaPublicKeyFactory _publicKeyFactory;
        private ECPrivateKeyParameters? _privateKey;

        private string? _privateKeyWif;
        private EcdsaPublicKey? _publicKey;

        /// <summary>
        ///     Create a secp256k1 ecdsa privateKey
        /// </summary>
        /// <param name="privateKeyTransformer">The private key transformer.</param>
        /// <param name="publicKeyTransformer">The public key transformer.</param>
        /// <param name="privateKeyWif">The private key as wif string.</param>
        public EcdsaPrivateKey(IPrivateKeyTransformer privateKeyTransformer, IPublicKeyTransformer publicKeyTransformer,
            string privateKeyWif)
        {
            _privateKeyTransformer = privateKeyTransformer;
            _publicKeyFactory = new EcdsaPublicKeyFactory(publicKeyTransformer);

            _privateKeyWif = privateKeyWif;
            _privateKey = null;
            _publicKey = null;
        }

        /// <summary>
        ///     Create a secp256k1 ecdsa privateKey
        /// </summary>
        /// <param name="privateKeyTransformer">The private key transformer.</param>
        /// <param name="publicKeyTransformer">The public key transformer.</param>
        /// <param name="privateKey">The private key.</param>
        public EcdsaPrivateKey(IPrivateKeyTransformer privateKeyTransformer, IPublicKeyTransformer publicKeyTransformer,
            ECPrivateKeyParameters privateKey)
        {
            _privateKeyTransformer = privateKeyTransformer;
            _publicKeyFactory = new EcdsaPublicKeyFactory(publicKeyTransformer);

            _privateKey = privateKey;
            _privateKeyWif = null;
            _publicKey = null;
        }


        /// <summary>
        ///     Get the private key.
        /// </summary>
        /// <returns>The private key as usable ECPrivateKey.</returns>
        /// <exception cref="ArgumentException">
        ///     Thrown when the stored wif cannot be decoded to a valid private
        ///     key.
        /// </exception>
        public ECPrivateKeyParameters GetPrivateKey()
        {
            return _privateKey ??= _privateKeyTransformer.GetPrivateKeyFromWif(_privateKeyWif!);
        }

        /// <summary>
        ///     Get the private key in its wif representation.
        /// </summary>
        /// <returns>The wif representation of the private key.</returns>
        public string GetPrivateKeyWif()
        {
            return _privateKeyWif ??= _privateKeyTransformer.GetWifFromPrivateKey(_privateKey!);
        }

        /// <summary>
        ///     Returns a public key from its private key.
        /// </summary>
        /// <returns>The public key as usable ECPublicKey.</returns>
        /// <exception cref="ArgumentException">Thrown when the privateKey is invalid.</exception>
        public EcdsaPublicKey GetPublicKey()
        {
            return _publicKey ??= _publicKeyFactory.Create(
                _privateKeyTransformer.GetPublicKeyFromPrivateKey(GetPrivateKey())
            );
        }
    }
}