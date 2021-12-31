using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace transfer_to_savings
    {
        [BroadcastOp("transfer_to_savings")]
        public class BroadcastOpTransferToSavingsModel : BroadcastOperation
        {
            /// <summary>
            ///     Places HIVE or HBD in saving balances.
            ///     Funds can be withdrawn from these balances after a three day delay.
            /// </summary>
            /// <param name="from">Account sending funds.</param>
            /// <param name="to">Account receiving funds.</param>
            /// <param name="amount">Amount of funds.</param>
            /// <param name="memo">Additional memo.</param>
            public BroadcastOpTransferToSavingsModel(string from, string to, FeeModelOrStringModel amount, string memo)
            {
                From = from;
                To = to;
                Amount = amount;
                Memo = memo;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("amount")] public FeeModelOrStringModel Amount { get; }

            [JsonPropertyName("memo")] public string Memo { get; }
        }
    }
}