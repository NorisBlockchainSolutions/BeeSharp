using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace account_update
    {
        [BroadcastOp("account_update2")]
        public class BroadcastOpAccountUpdate2Model : BroadcastOperation
        {
            [JsonPropertyName("account")] public string Account { get; }

            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("json_metadata")]
            public JsonMetadataResponseModel? JsonMetadata { get; }

            [JsonPropertyName("posting_json_metadata")]
            public PostingJsonMetadataResponseModel PostingJsonMetadata { get; }
            
            [JsonPropertyName("extensions")] public object[]? Extensions { get; }
            
            public BroadcastOpAccountUpdate2Model(string account, JsonMetadataResponseModel? jsonMetadata,
                PostingJsonMetadataResponseModel postingJsonMetadata, object[]? extensions)
            {
                Account = account;
                JsonMetadata = jsonMetadata;
                PostingJsonMetadata = postingJsonMetadata;
                Extensions = extensions;
            }
        }
    }
}