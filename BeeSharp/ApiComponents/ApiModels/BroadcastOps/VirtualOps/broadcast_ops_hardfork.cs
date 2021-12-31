using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace hardfork
    {
        [VirtualBroadcastOp("hardfork")]
        public class BroadcastVirtualOpHardforkModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpHardforkModel(NumberOrStringModel hardforkId)
            {
                HardforkId = hardforkId;
            }

            [JsonPropertyName("hardfork_id")] public NumberOrStringModel HardforkId { get; }
        }
    }
}