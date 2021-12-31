using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace escrow_dispute
    {
        [BroadcastOp("escrow_dispute")]
        public class BroadcastOpEscrowDisputeModel : BroadcastOperation
        {
            /// <summary>
            ///     If either the sender or the receiver of an escrow payment has an issue, they can raise it for dispute.
            ///     Once a payment is in dispute, the agent has authority over who gets what.
            /// </summary>
            /// <param name="from">The sending account.</param>
            /// <param name="to">The receiving account.</param>
            /// <param name="agent">The agent account for the escrow.</param>
            /// <param name="who">The account that sends it dispute.</param>
            /// <param name="escrowId">The id of the escrow to dispute.</param>
            public BroadcastOpEscrowDisputeModel(string from, string to, string agent, string who,
                NumberOrStringModel escrowId)
            {
                From = from;
                To = to;
                Agent = agent;
                Who = who;
                EscrowId = escrowId;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("agent")] public string Agent { get; }

            [JsonPropertyName("who")] public string Who { get; }

            [JsonPropertyName("escrow_id")] public NumberOrStringModel EscrowId { get; }
        }
    }
}