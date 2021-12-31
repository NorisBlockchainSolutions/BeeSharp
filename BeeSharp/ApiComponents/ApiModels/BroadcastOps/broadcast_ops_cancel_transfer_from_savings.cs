using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace cancel_transfer_from_savings
    {
        [BroadcastOp("cancel_transfer_from_savings")]
        public class BroadcastOpCancelTransferFromSavingsModel : BroadcastOperation
        {
            public BroadcastOpCancelTransferFromSavingsModel(string from, NumberOrStringModel requestId)
            {
                From = from;
                RequestId = requestId;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("request_id")] public NumberOrStringModel RequestId { get; }
        }
    }
}