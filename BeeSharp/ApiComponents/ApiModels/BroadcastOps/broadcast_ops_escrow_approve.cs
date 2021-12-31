using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace escrow_approve
    {
        [BroadcastOp("escrow_approve")]
        public class BroadcastOpEscrowApproveModel : BroadcastOperation
        {
            /// <summary>
            ///     The agent and the two accounts must approve an escrow transaction for it to be valid on the blockchain.
            ///     Once a party approves the escrow, they cannot revoke their approval.
            ///     Subsequent escrow approve operations, regardless of the approval, will be rejected.
            /// </summary>
            /// <param name="from">The sending account.</param>
            /// <param name="to">The receiving account.</param>
            /// <param name="agent">The agent account for the escrow.</param>
            /// <param name="who">The account that sends it approval.</param>
            /// <param name="escrowId">The id of the escrow to approve.</param>
            /// <param name="approve">Whether the account (who) approves (true) or not (false).</param>
            public BroadcastOpEscrowApproveModel(string from, string to, string agent, string who,
                NumberOrStringModel escrowId, bool approve)
            {
                From = from;
                To = to;
                Agent = agent;
                Who = who;
                EscrowId = escrowId;
                Approve = approve;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("agent")] public string Agent { get; }

            [JsonPropertyName("who")] public string Who { get; }

            [JsonPropertyName("escrow_id")] public NumberOrStringModel EscrowId { get; }

            [JsonPropertyName("approve")] public bool Approve { get; }
        }
    }
}