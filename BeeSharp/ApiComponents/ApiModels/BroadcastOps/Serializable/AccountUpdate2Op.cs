using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public class AccountUpdate2Op : ISerializableOperation
    {
        private readonly AccountUpdate2OpModel _accountUpdate2OpModel;

        /// <summary>
        ///     Update an existing account.
        /// </summary>
        /// <param name="account">The name of the account.</param>
        /// <param name="postingJsonMetadata">Posting json metadata.</param>
        /// <param name="jsonMetadata">Additional json metadata.</param>
        /// <param name="extensions">Additional extensions.</param>
        public AccountUpdate2Op(string account, PostingJsonMetadataResponseModel postingJsonMetadata,
            JsonMetadataResponseModel? jsonMetadata = null,
            object[]? extensions = null)
        {
            _accountUpdate2OpModel = new AccountUpdate2OpModel(account, postingJsonMetadata, jsonMetadata, extensions);
        }

        public byte[] SerializeOperation()
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            writer.Write(_accountUpdate2OpModel!.Account);

            // Serialize keys
            result.Write(AccountKeyElementsSerializer.SerializeOptionalKeys(null, null,
                null, null, true));

            // Serialize metadata
            writer.Write(_accountUpdate2OpModel!.JsonMetadata.RawResponse!);
            writer.Write(Regex.Unescape(_accountUpdate2OpModel!.PostingJsonMetadata.RawResponse!));

            // Serialize extensions
            if (_accountUpdate2OpModel!.Extensions.Length == 0)
                writer.Write((byte) 0);
            else
                throw new NotImplementedException("Extension serializing is currently not supported!");

            return result.ToArray();
        }

        public HivedOperationId GetOperationId()
        {
            return HivedOperationId.account_update2;
        }

        public string GetOperationName()
        {
            return "account_update2";
        }

        public object GetOperationModel()
        {
            return _accountUpdate2OpModel;
        }
    }
}