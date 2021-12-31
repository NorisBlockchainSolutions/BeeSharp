using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace fill_transfer_from_savings
    {
        [VirtualBroadcastOp("fill_transfer_from_savings")]
        public class BroadcastVirtualOpFillTransferFromSavingsModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpFillTransferFromSavingsModel(string from, string to, string amount,
                NumberOrStringModel requestId, string memo)
            {
                From = from;
                To = to;
                Amount = amount;
                RequestId = requestId;
                Memo = memo;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("amount")] public string Amount { get; }

            [JsonPropertyName("request_id")] public NumberOrStringModel RequestId { get; }

            [JsonPropertyName("memo")] public string Memo { get; }
        }
    }
}