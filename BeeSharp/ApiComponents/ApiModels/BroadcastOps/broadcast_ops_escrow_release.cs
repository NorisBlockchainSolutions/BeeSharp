using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace escrow_release
    {
        [BroadcastOp("escrow_release")]
        public class BroadcastOpEscrowReleaseModel : BroadcastOperation
        {
            /// <summary>
            ///     Usable by sender, receiver or agent, if they have permission.
            ///     No dispute and escrow has not expired: Either party can release funds to the other.
            ///     No dispute and escrow expired: Either party can release funds to either party.
            ///     Dispute, regardless of expiration: Agent can release funds to either party.
            /// </summary>
            /// <param name="from">The sending account.</param>
            /// <param name="to">The receiving account.</param>
            /// <param name="agent">The agent account for the escrow.</param>
            /// <param name="who">The account that sends it approval.</param>
            /// <param name="escrowId">The id of the escrow to approve.</param>
            /// <param name="receiver">The receiver of the fund.</param>
            /// <param name="hbdAmount">The amount of HBD.</param>
            /// <param name="hiveAmount">The amount of HIVE.</param>
            public BroadcastOpEscrowReleaseModel(string from, string to, string agent, string who, string receiver,
                NumberOrStringModel escrowId, FeeModelOrStringModel hbdAmount, FeeModelOrStringModel hiveAmount)
            {
                From = from;
                To = to;
                Agent = agent;
                Who = who;
                Receiver = receiver;
                EscrowId = escrowId;
                HbdAmount = hbdAmount;
                HiveAmount = hiveAmount;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("agent")] public string Agent { get; }

            [JsonPropertyName("who")] public string Who { get; }

            [JsonPropertyName("receiver")] public string Receiver { get; }

            [JsonPropertyName("escrow_id")] public NumberOrStringModel EscrowId { get; }

            [JsonPropertyName("hbd_amount")] public FeeModelOrStringModel HbdAmount { get; }

            [JsonPropertyName("hive_amount")] public FeeModelOrStringModel HiveAmount { get; }
        }
    }
}