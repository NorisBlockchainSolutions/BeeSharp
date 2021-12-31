using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace collateralized_convert
    {
        [BroadcastOp("collateralized_convert")]
        public class BroadcastOpsCollateralizedConvert : BroadcastOperation
        {
            [JsonPropertyName("owner")] public string Owner { get; }
            [JsonPropertyName("requestid")] public NumberOrStringModel RequestId { get; }
            [JsonPropertyName("amount")] public FeeModelOrStringModel Amount { get; }

            public BroadcastOpsCollateralizedConvert(string owner, NumberOrStringModel requestId,
                FeeModelOrStringModel amount)
            {
                Owner = owner;
                RequestId = requestId;
                Amount = amount;
            }
        }
    }
}