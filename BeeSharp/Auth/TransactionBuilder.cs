using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.broadcast_transaction;
using BeeSharp.ApiComponents.Condenser;
using BeeSharp.ApiComponents.Condenser.Serialization;
using BeeSharp.Auth.ECKeyManagement.KeyProcessing;
using BeeSharp.Auth.Signatures;
using BeeSharp.root.Exceptions;

namespace BeeSharp.Auth
{
    public class TransactionBuilder : ITransactionBuilder
    {
        private readonly IRefBlockParameterProvider _refBlockParameterProvider;
        private readonly ISignatureCreator _signatureCreator;
        private readonly ITransactionSerializer _transactionSerializer;

        public TransactionBuilder(ISignatureCreator signatureCreator, ITransactionSerializer transactionSerializer,
            IRefBlockParameterProvider refBlockParameterProvider)
        {
            _signatureCreator = signatureCreator;
            _transactionSerializer = transactionSerializer;
            _refBlockParameterProvider = refBlockParameterProvider;
        }

        /// <summary>
        ///     Create a new transaction with signatures.
        /// </summary>
        /// <param name="operations">The operations.</param>
        /// <param name="signingKeys">The private keys to create signatures with.</param>
        /// <param name="expiration">
        ///     The time the transaction expires (default 30 seconds). Can be up to an hour delay.
        /// </param>
        /// <param name="extensions">Extensions to the transaction (default none).</param>
        /// <returns>The transaction object.</returns>
        /// <exception cref="MathException">
        ///     Thrown when no valid recovery parameter can be calculated for the public
        ///     key. Most likely the private key is invalid.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the signature is invalid or a calculation fails. Most likely
        ///     the private key is invalid.
        /// </exception>
        public async Task<CondenserApiBroadcastTransaction> CreateTransaction(
            ISerializableOperation[] operations,
            IEnumerable<EcdsaPrivateKey> signingKeys,
            DateTime expiration,
            ExtensionModel[]? extensions = null)
        {
            var (refBlockNum, refBlockPrefix) = await _refBlockParameterProvider.GetRefBlockParams();

            var serialized = _transactionSerializer.GetSerializedTransaction(refBlockNum, refBlockPrefix,
                expiration, operations, extensions);

            var signatures = new List<string>();
            foreach (var signingKey in signingKeys)
                signatures.Add(_signatureCreator.CreateSignature(serialized, signingKey));

            return new CondenserApiBroadcastTransaction(
                refBlockNum, refBlockPrefix, expiration,
                operations, signatures.ToArray(), extensions
            );
        }
    }
}