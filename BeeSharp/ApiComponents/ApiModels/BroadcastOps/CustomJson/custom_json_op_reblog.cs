using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson
{
    namespace reblog
    {
        [CustomJsonOpId("reblog", typeof(ArrayShapedCustomJsonModel))]
        [CustomJsonOpListOp("reblog")]
        public class CustomJsonOpReblogModel : CustomJsonOperation
        {
            public CustomJsonOpReblogModel(string account, string author, string permLink)
            {
                Account = account;
                Author = author;
                PermLink = permLink;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }
        }
    }
}