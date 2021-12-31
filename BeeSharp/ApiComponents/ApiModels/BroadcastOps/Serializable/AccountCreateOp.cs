using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.account_create;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer;
using BeeSharp.ApiComponents.Condenser.Serialization;
using BeeSharp.Auth.ECKeyManagement.KeyProcessing;
using BeeSharp.Auth.Provider;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public class AccountCreateOp : ISerializableOperation
    {
        private readonly BroadcastOpAccountCreateModel _accountCreateModel;
        private readonly AccountKeyElement _activeKey;
        private readonly EcdsaPublicKey _memoKey;
        private readonly AccountKeyElement _ownerKey;
        private readonly AccountKeyElement _postingKey;

        /// <summary>
        ///     Create a new account.
        /// </summary>
        /// <param name="creator">The creator of the account.</param>
        /// <param name="newAccountName">The name of the new account.</param>
        /// <param name="ownerKey">The public owner key.</param>
        /// <param name="activeKey">The public active key.</param>
        /// <param name="postingKey">The public posting key.</param>
        /// <param name="memoKey">The public memo key.</param>
        /// <param name="accountCreationFee">
        ///     The fee that has to be paid for an account creation (this information is
        ///     usually retrieved from the api automatically).
        /// </param>
        /// <param name="jsonMetadata">Additional json metadata.</param>
        public AccountCreateOp(string creator, string newAccountName,
            AccountKeyElement ownerKey, AccountKeyElement activeKey, AccountKeyElement postingKey,
            EcdsaPublicKey memoKey,
            FeeModelOrStringModel? accountCreationFee = null,
            JsonMetadataResponseModel? jsonMetadata = null)
        {
            _accountCreateModel = new BroadcastOpAccountCreateModel(
                accountCreationFee ?? ChainParameterProvider.Get().AccountCreationFee,
                creator,
                newAccountName,
                new AccountKeyModel(new NumberOrStringModel(ownerKey.WeightThreshold),
                    ownerKey.GetAccountAuthsAsModels(),
                    ownerKey.GetAccountKeyAuthsAsModels()),
                new AccountKeyModel(new NumberOrStringModel(activeKey.WeightThreshold),
                    activeKey.GetAccountAuthsAsModels(),
                    activeKey.GetAccountKeyAuthsAsModels()),
                new AccountKeyModel(new NumberOrStringModel(postingKey.WeightThreshold),
                    postingKey.GetAccountAuthsAsModels(),
                    postingKey.GetAccountKeyAuthsAsModels()),
                memoKey.GetBase58Encoded(),
                jsonMetadata ?? new JsonMetadataResponseModel("")
            );

            // Store the keys separately for serialization
            _ownerKey = ownerKey;
            _activeKey = activeKey;
            _postingKey = postingKey;
            _memoKey = memoKey;
        }

        /// <summary>
        ///     Create a new account.
        /// </summary>
        /// <param name="creator">The creator of the account.</param>
        /// <param name="newAccountName">The name of the new account.</param>
        /// <param name="ownerKey">The public owner key.</param>
        /// <param name="activeKey">The public active key.</param>
        /// <param name="postingKey">The public posting key.</param>
        /// <param name="memoKey">The public memo key.</param>
        /// <param name="jsonMetadata">Additional json metadata (optional).</param>
        public AccountCreateOp(string creator, string newAccountName,
            EcdsaPublicKey ownerKey, EcdsaPublicKey activeKey, EcdsaPublicKey postingKey,
            EcdsaPublicKey memoKey,
            JsonMetadataResponseModel? jsonMetadata = null)
        {
            _accountCreateModel = new BroadcastOpAccountCreateModel(
                ChainParameterProvider.Get().AccountCreationFee,
                creator,
                newAccountName,
                new AccountKeyModel(new[] {ownerKey.GetBase58Encoded()}),
                new AccountKeyModel(new[] {activeKey.GetBase58Encoded()}),
                new AccountKeyModel(new[] {postingKey.GetBase58Encoded()}),
                memoKey.GetBase58Encoded(),
                jsonMetadata ?? new JsonMetadataResponseModel("")
            );

            // Store the keys separately for serialization
            _ownerKey = new AccountKeyElement(null, new[] {new KeyAuthElement(ownerKey, 1)});
            _activeKey = new AccountKeyElement(null, new[] {new KeyAuthElement(activeKey, 1)});
            _postingKey = new AccountKeyElement(null, new[] {new KeyAuthElement(postingKey, 1)});
            _memoKey = memoKey;
        }

        public HivedOperationId GetOperationId()
        {
            return HivedOperationId.account_create;
        }

        public string GetOperationName()
        {
            return "account_create";
        }

        public object GetOperationModel()
        {
            return _accountCreateModel;
        }

        public byte[] SerializeOperation()
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            result.Write(_accountCreateModel.Fee.SerializeOperation());
            writer.Write(_accountCreateModel.Creator);
            writer.Write(_accountCreateModel.NewAccountName);

            result.Write(AccountKeyElementsSerializer.SerializeOperation(_ownerKey,
                _activeKey, _postingKey, _memoKey));

            writer.Write(_accountCreateModel.JsonMetadata.RawResponse!);

            return result.ToArray();
        }
    }
}