using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace shutdown_witness
    {
        [VirtualBroadcastOp("shutdown_witness")]
        public class BroadcastVirtualOpShutdownWitnessModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpShutdownWitnessModel(string owner)
            {
                Owner = owner;
            }

            [JsonPropertyName("owner")] public string Owner { get; }
        }
    }
}