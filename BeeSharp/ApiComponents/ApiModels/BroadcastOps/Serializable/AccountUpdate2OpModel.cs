using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public class AccountUpdate2OpModel
    {
        public AccountUpdate2OpModel(string account,
            PostingJsonMetadataResponseModel postingJsonMetadata,
            JsonMetadataResponseModel? jsonMetadata = null,
            object[]? extensions = null)
        {
            Account = account;
            PostingJsonMetadata = postingJsonMetadata;
            JsonMetadata = jsonMetadata ?? new JsonMetadataResponseModel("");
            Extensions = extensions ?? Array.Empty<object>();
        }

        [JsonPropertyName("account")] public string Account { get; }

        [JsonPropertyName("json_metadata")] public JsonMetadataResponseModel JsonMetadata { get; }

        [JsonPropertyName("posting_json_metadata")]
        public PostingJsonMetadataResponseModel PostingJsonMetadata { get; }

        [JsonPropertyName("extensions")] public object[] Extensions { get; }
    }
}