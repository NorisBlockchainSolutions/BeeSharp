using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace consolidate_treasury_balance
    {
        [VirtualBroadcastOp("consolidate_treasury_balance")]
        public class BroadcastVirtualOpConsolidateTreasuryBalanceModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpConsolidateTreasuryBalanceModel(FeeModelOrStringModel[] totalMoved)
            {
                TotalMoved = totalMoved;
            }

            [JsonPropertyName("total_moved")] public FeeModelOrStringModel[] TotalMoved { get; }
        }
    }
}