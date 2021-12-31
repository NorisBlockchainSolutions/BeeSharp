using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace account_create
    {
        [BroadcastOp("account_create")]
        public class BroadcastOpAccountCreateModel : BroadcastOperation
        {
            [JsonConstructor]
            public BroadcastOpAccountCreateModel(FeeModelOrStringModel fee, string creator, string newAccountName,
                AccountKeyModel owner, AccountKeyModel active, AccountKeyModel posting, string memoKey,
                JsonMetadataResponseModel jsonMetadata)
            {
                Fee = fee;
                Creator = creator;
                NewAccountName = newAccountName;
                Owner = owner;
                Active = active;
                Posting = posting;
                MemoKey = memoKey;
                JsonMetadata = jsonMetadata;
            }

            [JsonPropertyName("fee")] public FeeModelOrStringModel Fee { get; }

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