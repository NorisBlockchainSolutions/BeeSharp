using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace escrow_transfer
    {
        [BroadcastOp("escrow_transfer")]
        public class BroadcastOpEscrowTransferModel : BroadcastOperation
        {
            /// <summary>
            ///     Create an escrow transfer.
            ///     Allows an account to send money contigently to another individual.
            ///     The funds leave the from account and go into a temporary balance where they are held until from releases
            ///     it to or to refunds it to from.
            ///     After the escrow has been approved by all parties, any party can raise a dispute, in which case the
            ///     fund division between the to/from account is up to the agent.
            ///     The agent is paid a fee on approval of all parties. It is up to the agent to determine the fee.
            ///     Escrow transactions are uniquely identified by From and EscrowId. EscrowId is defined by the sender.
            /// </summary>
            /// <param name="from">The sending account.</param>
            /// <param name="to">The receiving account.</param>
            /// <param name="hbdAmount">The amount of HBD.</param>
            /// <param name="hiveAmount">The amount of HIVE.</param>
            /// <param name="escrowId">The id of the escrow.</param>
            /// <param name="agent">The agent account for the escrow.</param>
            /// <param name="fee">The fee the agent receives.</param>
            /// <param name="jsonMeta">Additional json meta.</param>
            /// <param name="ratificationDeadline">
            ///     The deadline, after which the escrow must be approved by all
            ///     parties to be valid.
            /// </param>
            /// <param name="escrowExpiration">The deadline, after which the escrow expires.</param>
            public BroadcastOpEscrowTransferModel(string from, string to, FeeModelOrStringModel hbdAmount,
                FeeModelOrStringModel hiveAmount, NumberOrStringModel escrowId, string agent, FeeModelOrStringModel fee,
                string jsonMeta, DateTime ratificationDeadline, DateTime escrowExpiration)
            {
                From = from;
                To = to;
                HbdAmount = hbdAmount;
                HiveAmount = hiveAmount;
                EscrowId = escrowId;
                Agent = agent;
                Fee = fee;
                JsonMeta = jsonMeta;
                RatificationDeadline = ratificationDeadline;
                EscrowExpiration = escrowExpiration;
            }

            [JsonPropertyName("from")] public string From { get; }

            [JsonPropertyName("to")] public string To { get; }

            [JsonPropertyName("hbd_amount")] public FeeModelOrStringModel HbdAmount { get; }

            [JsonPropertyName("hive_amount")] public FeeModelOrStringModel HiveAmount { get; }

            [JsonPropertyName("escrow_id")] public NumberOrStringModel EscrowId { get; }

            [JsonPropertyName("agent")] public string Agent { get; }

            [JsonPropertyName("fee")] public FeeModelOrStringModel Fee { get; }

            [JsonPropertyName("json_meta")] public string JsonMeta { get; }

            [JsonPropertyName("ratification_deadline")]
            public DateTime RatificationDeadline { get; }

            [JsonPropertyName("escrow_expiration")]
            public DateTime EscrowExpiration { get; }
        }
    }
}