using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace recurrent_transfer
    {
        [BroadcastOp("recurrent_transfer")]
        public class BroadcastOpRecurrentTransferModel : BroadcastOperation
        {
            [JsonPropertyName("from")] public string From { get; }
            [JsonPropertyName("to")] public string To { get; }
            [JsonPropertyName("amount")] public FeeModelOrStringModel Amount { get; }
            [JsonPropertyName("memo")] public string Memo { get; }
            [JsonPropertyName("recurrence")] public NumberOrStringModel Recurrence { get; }
            [JsonPropertyName("executions")] public NumberOrStringModel Executions { get; }
            [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
            [JsonPropertyName("extensions")] public object[]? Extensions { get; }

            /// <summary>
            /// The recurrent_transfer operation creates/updates/removes a recurrent transfer (transfers any liquid
            /// asset every fixed amount of time from one account to another). If amount is set to 0, the recurrent
            /// transfer is be deleted. If there is already a recurrent transfer matching from and to, the recurrent
            /// transfer is updated.
            /// </summary>
            public BroadcastOpRecurrentTransferModel(string @from, string to, FeeModelOrStringModel amount, string memo,
                NumberOrStringModel recurrence, NumberOrStringModel executions, object[]? extensions = null)
            {
                From = @from;
                To = to;
                Amount = amount;
                Memo = memo;
                Recurrence = recurrence;
                Executions = executions;
                Extensions = extensions;
            }
        }
    }
}