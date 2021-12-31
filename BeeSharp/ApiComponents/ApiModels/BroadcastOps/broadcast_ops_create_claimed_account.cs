using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace create_claimed_account
    {
        [BroadcastOp("create_claimed_account")]
        public class BroadcastOpCreateClaimedAccountModel : BroadcastOperation
        {
            /// <summary>
            ///     Create a new hive account using an account creation ticket.
            /// </summary>
            /// <param name="creator">The account creator.</param>
            /// <param name="newAccountName">Name of the new account.</param>
            /// <param name="owner">Owner-Key of the new account.</param>
            /// <param name="active">Active-Key of the new account.</param>
            /// <param name="posting">Posting-Key of the new account.</param>
            /// <param name="memoKey">Memo-Key of the new account.</param>
            /// <param name="jsonMetadata">Additional json metadata.</param>
            public BroadcastOpCreateClaimedAccountModel(string creator, string newAccountName, AccountKeyModel owner,
                AccountKeyModel active, AccountKeyModel posting, string memoKey, JsonMetadataResponseModel jsonMetadata)
            {
                Creator = creator;
                NewAccountName = newAccountName;
                Owner = owner;
                Active = active;
                Posting = posting;
                MemoKey = memoKey;
                JsonMetadata = jsonMetadata;
            }

            [JsonPropertyName("creator")] public string Creator { get; }

            [JsonPropertyName("new_account_name")] public string NewAccountName { get; }

            [JsonPropertyName("owner")] public AccountKeyModel Owner { get; }

            [JsonPropertyName("active")] public AccountKeyModel Active { get; }

            [JsonPropertyName("posting")] public AccountKeyModel Posting { get; }

            [JsonPropertyName("memo_key")] public string MemoKey { get; }

            [JsonPropertyName("json_metadata")] public JsonMetadataResponseModel JsonMetadata { get; }
        }
    }
}