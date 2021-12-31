using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace sps_fund
    {
        [VirtualBroadcastOp("sps_fund")]
        public class BroadcastVirtualOpSpsFundModel : VirtualBroadcastOperation
        {
            /// <summary>
            ///     Created once per maintenance interval to document how much HBD was added to the treasury from inflation
            ///     in that maintenance interval (i.e to track the funding of the DHF).
            /// </summary>
            public BroadcastVirtualOpSpsFundModel(string additionalFunds)
            {
                AdditionalFunds = additionalFunds;
            }

            [JsonPropertyName("additional_funds")] public string AdditionalFunds { get; }
        }
    }
}