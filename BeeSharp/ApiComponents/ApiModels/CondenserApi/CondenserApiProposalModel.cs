using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    public class CondenserApiProposalModel
    {
        public CondenserApiProposalModel(NumberOrStringModel id, NumberOrStringModel proposalId, string creator,
            string receiver, DateTime startDate, DateTime endDate, string dailyPay, string subject, string permLink,
            string totalVotes, string status)
        {
            Id = id;
            ProposalId = proposalId;
            Creator = creator;
            Receiver = receiver;
            StartDate = startDate;
            EndDate = endDate;
            DailyPay = dailyPay;
            Subject = subject;
            PermLink = permLink;
            TotalVotes = totalVotes;
            Status = status;
        }

        [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

        [JsonPropertyName("proposal_id")] public NumberOrStringModel ProposalId { get; }

        [JsonPropertyName("creator")] public string Creator { get; }

        [JsonPropertyName("receiver")] public string Receiver { get; }

        [JsonPropertyName("start_date")] public DateTime StartDate { get; }

        [JsonPropertyName("end_date")] public DateTime EndDate { get; }

        [JsonPropertyName("daily_pay")] public string DailyPay { get; }

        [JsonPropertyName("subject")] public string Subject { get; }

        [JsonPropertyName("permlink")] public string PermLink { get; }

        [JsonPropertyName("total_votes")] public string TotalVotes { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("status")]
        public string Status { get; }
    }
}