using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace interest
    {
        [VirtualBroadcastOp("interest")]
        public class BroadcastVirtualOpInterestModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpInterestModel(string owner, string interest)
            {
                Owner = owner;
                Interest = interest;
            }

            [JsonPropertyName("owner")] public string Owner { get; }

            [JsonPropertyName("interest")] public string Interest { get; }
        }
    }
}