using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace convert
    {
        [BroadcastOp("convert")]
        public class BroadcastOpConvertModel : BroadcastOperation
        {
            /// <summary>
            ///     Start a conversion from HBD to HIVE. Takes 3.5 Days.
            /// </summary>
            /// <param name="owner">The account who owns the HBD.</param>
            /// <param name="requestId">PostId of the request.</param>
            /// <param name="amount">The amount to convert.</param>
            public BroadcastOpConvertModel(string owner, NumberOrStringModel requestId, string amount)
            {
                Owner = owner;
                RequestId = requestId;
                Amount = amount;
            }

            [JsonPropertyName("owner")] public string Owner { get; }

            [JsonPropertyName("requestid")] public NumberOrStringModel RequestId { get; }

            [JsonPropertyName("amount")] public string Amount { get; }
        }
    }
}