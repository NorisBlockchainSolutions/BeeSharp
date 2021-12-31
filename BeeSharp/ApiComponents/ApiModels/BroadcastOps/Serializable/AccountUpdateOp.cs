﻿using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer;
using BeeSharp.ApiComponents.Condenser.Serialization;
using BeeSharp.Auth.ECKeyManagement.KeyProcessing;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public class AccountUpdateOp : ISerializableOperation
    {
        private readonly AccountUpdateOpModel _accountUpdateOpModel;
        private readonly AccountKeyElement _activeKey;
        private readonly EcdsaPublicKey _memoKey;
        private readonly AccountKeyElement _ownerKey;
        private readonly AccountKeyElement _postingKey;

        /// <summary>
        ///     Update an existing account.
        /// </summary>
        /// <param name="account">The name of the account.</param>
        /// <param name="ownerKey">The public owner key.</param>
        /// <param name="activeKey">The public active key.</param>
        /// <param name="postingKey">The public posting key.</param>
        /// <param name="memoKey">The public memo key.</param>
        /// <param name="jsonMetadata">Additional json metadata.</param>
        public AccountUpdateOp(string account,
            AccountKeyElement ownerKey, AccountKeyElement activeKey, AccountKeyElement postingKey,
            EcdsaPublicKey memoKey,
            JsonMetadataResponseModel? jsonMetadata = null)
        {
            _accountUpdateOpModel = new AccountUpdateOpModel(
                account,
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
        ///     Update an existing account.
        /// </summary>
        /// <param name="account">The name of the account.</param>
        /// <param name="ownerKey">The public owner key.</param>
        /// <param name="activeKey">The public active key.</param>
        /// <param name="postingKey">The public posting key.</param>
        /// <param name="memoKey">The public memo key.</param>
        /// <param name="jsonMetadata">Additional json metadata (optional).</param>
        public AccountUpdateOp(string account,
            EcdsaPublicKey ownerKey, EcdsaPublicKey activeKey, EcdsaPublicKey postingKey,
            EcdsaPublicKey memoKey,
            JsonMetadataResponseModel? jsonMetadata = null)
        {
            _accountUpdateOpModel = new AccountUpdateOpModel(
                account,
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

        public byte[] SerializeOperation()
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            writer.Write(_accountUpdateOpModel.Account);

            // Serialize keys
            result.Write(AccountKeyElementsSerializer.SerializeOptionalKeys(_ownerKey, _activeKey,
                _postingKey, _memoKey));

            writer.Write(_accountUpdateOpModel.JsonMetadata.RawResponse!);

            return result.ToArray();
        }

        public HivedOperationId GetOperationId()
        {
            return HivedOperationId.account_update;
        }

        public string GetOperationName()
        {
            return "account_update";
        }

        public object GetOperationModel()
        {
            return _accountUpdateOpModel;
        }
    }
}