using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    public class CondenserApiEscrowModel
    {
        public CondenserApiEscrowModel(NumberOrStringModel id, NumberOrStringModel escrowId, string from, string to,
            string agent, DateTime ratificationDeadline, DateTime escrowExpiration, string hbdBalance,
            string hiveBalance, string pendingFee, bool toApproved, bool agentApproved, bool disputed)
        {
            Id = id;
            EscrowId = escrowId;
            From = from;
            To = to;
            Agent = agent;
            RatificationDeadline = ratificationDeadline;
            EscrowExpiration = escrowExpiration;
            HbdBalance = hbdBalance;
            HiveBalance = hiveBalance;
            PendingFee = pendingFee;
            ToApproved = toApproved;
            AgentApproved = agentApproved;
            Disputed = disputed;
        }

        [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

        [JsonPropertyName("escrow_id")] public NumberOrStringModel EscrowId { get; }

        [JsonPropertyName("from")] public string From { get; }

        [JsonPropertyName("to")] public string To { get; }

        [JsonPropertyName("agent")] public string Agent { get; }

        [JsonPropertyName("ratification_deadline")]
        public DateTime RatificationDeadline { get; }

        [JsonPropertyName("escrow_expiration")]
        public DateTime EscrowExpiration { get; }

        [JsonPropertyName("hbd_balance")] public string HbdBalance { get; }

        [JsonPropertyName("hive_balance")] public string HiveBalance { get; }

        [JsonPropertyName("pending_fee")] public string PendingFee { get; }

        [JsonPropertyName("to_approved")] public bool ToApproved { get; }

        [JsonPropertyName("agent_approved")] public bool AgentApproved { get; }

        [JsonPropertyName("disputed")] public bool Disputed { get; }
    }
}