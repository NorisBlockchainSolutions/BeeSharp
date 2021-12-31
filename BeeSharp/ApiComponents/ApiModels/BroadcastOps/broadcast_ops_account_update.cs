using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace account_update
    {
        [BroadcastOp("account_update")]
        public class BroadcastOpAccountUpdateModel : BroadcastOperation
        {
            public BroadcastOpAccountUpdateModel(string account, AccountKeyModel owner, AccountKeyModel active,
                AccountKeyModel posting, string memoKey, JsonMetadataResponseModel jsonMetadata,
                PostingJsonMetadataResponseModel postingJsonMetadata)
            {
                Account = account;
                Owner = owner;
                Active = active;
                Posting = posting;
                MemoKey = memoKey;
                JsonMetadata = jsonMetadata;
                PostingJsonMetadata = postingJsonMetadata;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("owner")]
            public AccountKeyModel Owner { get; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("active")]
            public AccountKeyModel Active { get; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("posting")] public AccountKeyModel Posting { get; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("memo_key")]
            public string MemoKey { get; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("json_metadata")]
            public JsonMetadataResponseModel JsonMetadata { get; }

            [JsonPropertyName("posting_json_metadata")]
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            public PostingJsonMetadataResponseModel PostingJsonMetadata { get; }
        }
    }
}