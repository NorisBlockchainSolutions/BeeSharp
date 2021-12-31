using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public class AccountUpdateOpModel
    {
        public AccountUpdateOpModel(string account, AccountKeyModel owner, AccountKeyModel active,
            AccountKeyModel posting, string memoKey, JsonMetadataResponseModel jsonMetadata)
        {
            Account = account;
            Owner = owner;
            Active = active;
            Posting = posting;
            MemoKey = memoKey;
            JsonMetadata = jsonMetadata;
        }

        [JsonPropertyName("account")] public string Account { get; }

        [JsonPropertyName("owner")] public AccountKeyModel Owner { get; }

        [JsonPropertyName("active")] public AccountKeyModel Active { get; }

        [JsonPropertyName("posting")] public AccountKeyModel Posting { get; }

        [JsonPropertyName("memo_key")] public string MemoKey { get; }

        [JsonPropertyName("json_metadata")] public JsonMetadataResponseModel JsonMetadata { get; }
    }
}