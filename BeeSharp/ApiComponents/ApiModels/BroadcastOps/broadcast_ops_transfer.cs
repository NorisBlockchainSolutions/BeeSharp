using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace transfer
    {
        [BroadcastOp("transfer")]
        public class BroadcastOpTransferModel : BroadcastOperation
        {
            /// <summary>
            ///     Transfer assets from one account to another.
            ///     Transferring VESTS is not allowed.
            ///     Cannot transfer a negative amount.
            ///     Memo must be less than 2048 bytes and UTF-8
            /// </summary>
            /// <param name="from">Account that sends assets.</param>
            /// <param name="to">Account that receives the assets.</param>
            /// <param name="amount">The amount of assets to transfer.</param>
            /// <param name="memo">The (plain-text) memo. Encryption is up to a higher level protocol.</param>
            public BroadcastOpTransferModel(string from, string to, FeeModelOrStringModel amount, string memo = "")
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