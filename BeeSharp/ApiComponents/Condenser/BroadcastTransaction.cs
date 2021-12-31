using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.ApiComponents.Condenser.Serialization;
using BeeSharp.Auth;
using BeeSharp.Auth.ECKeyManagement.KeyProcessing;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiComponents.Condenser
{
    public class BroadcastTransaction : IBroadcastTransaction
    {
        private readonly ICondenserCall _condenser;
        private readonly ITransactionBuilder _transactionBuilder;

        public BroadcastTransaction(ICondenserCall condenser, ITransactionBuilder transactionBuilder)
        {
            _condenser = condenser;
            _transactionBuilder = transactionBuilder;
        }

        /// <summary>
        ///     Broadcast a transaction to the blockchain.
        /// </summary>
        /// <param name="operations">The operations.</param>
        /// <param name="signingKeys">The private keys to create signatures with.</param>
        /// <param name="extensions">Extensions to the transaction (default none).</param>
        /// <param name="expirationInSeconds">
        ///     The time until the transaction expires in seconds (default 30 seconds).
        /// </param>
        /// <returns>Awaitable.</returns>
        /// <exception cref="MathException">
        ///     Thrown when no valid recovery parameter can be calculated for the public
        ///     key. Most likely the private key is invalid.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     Thrown when the signature is invalid or a calculation fails. Most likely
        ///     the private key is invalid.
        /// </exception>
        public async Task<CondenserApiResponse<object>> CondenserApiBroadcastTransaction(
            ISerializableOperation[] operations,
            IEnumerable<EcdsaPrivateKey> signingKeys,
            ExtensionModel[]? extensions = null,
            uint expirationInSeconds = 30)
        {
            var expiration = DateTime.UtcNow.AddSeconds(expirationInSeconds);
            var transaction = await _transactionBuilder.CreateTransaction(
                operations,
                signingKeys,
                expiration,
                extensions);

            var response = await _condenser.GetRawCondenserApiCallAsync(transaction);
            return response;
        }
    }
}