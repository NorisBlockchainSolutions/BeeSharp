using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace transfer_from_savings
    {
        [BroadcastOp("transfer_from_savings")]
        public class BroadcastOpTransferFromSavingsModel : BroadcastOperation
        {
            public BroadcastOpTransferFromSavingsModel(string from, NumberOrStringModel requestId, string to,
                FeeModelOrStringModel amount, string memo)
            {
                From = from;
                RequestId = requestId;
                To = to;
                Amount = amount;
                Memo = memo;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("request_id")] public NumberOrStringModel RequestId { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("amount")] public FeeModelOrStringModel Amount { get; }

            [JsonPropertyName("memo")] public string Memo { get; }
        }
    }
}