using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.broadcast_transaction;
using BeeSharp.ApiComponents.Condenser.Serialization;
using BeeSharp.Auth.ECKeyManagement.KeyProcessing;

namespace BeeSharp.Auth
{
    public interface ITransactionBuilder
    {
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
        Task<CondenserApiBroadcastTransaction> CreateTransaction(
            ISerializableOperation[] operations,
            IEnumerable<EcdsaPrivateKey> signingKeys,
            DateTime expiration,
            ExtensionModel[]? extensions = null);
    }
}