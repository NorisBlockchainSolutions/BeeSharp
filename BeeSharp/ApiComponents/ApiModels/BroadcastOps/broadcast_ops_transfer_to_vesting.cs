using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace transfer_to_vesting
    {
        [BroadcastOp("transfer_to_vesting")]
        public class BroadcastOpTransferToVestingModel : BroadcastOperation
        {
            /// <summary>
            ///     Power-up/stake HIVE. Converts HIVE into VESTS at the current exchange rate.
            /// </summary>
            /// <param name="from">Account that pays HIVE.</param>
            /// <param name="to">Account that receives VESTS.</param>
            /// <param name="amount">The amount of HIVE to convert to VESTS.</param>
            public BroadcastOpTransferToVestingModel(string from, string to, FeeModelOrStringModel amount)
            {
                From = from;
                To = to;
                Amount = amount;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("amount")] public FeeModelOrStringModel Amount { get; }
        }
    }
}