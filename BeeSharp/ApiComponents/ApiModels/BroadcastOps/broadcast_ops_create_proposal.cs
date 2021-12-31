using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace create_proposal
    {
        [BroadcastOp("create_proposal")]
        public class BroadcastOpCreateProposalModel : BroadcastOperation
        {
            public BroadcastOpCreateProposalModel(string creator, string receiver, DateTime startDate, DateTime endDate,
                FeeModelOrStringModel dailyPay, string subject, string permLink)
            {
                Creator = creator;
                Receiver = receiver;
                StartDate = startDate;
                EndDate = endDate;
                DailyPay = dailyPay;
                Subject = subject;
                PermLink = permLink;
            }

            [JsonPropertyName("creator")] public string Creator { get; set; }

            [JsonPropertyName("receiver")] public string Receiver { get; set; }

            [JsonPropertyName("start_date")] public DateTime StartDate { get; set; }

            [JsonPropertyName("end_date")] public DateTime EndDate { get; set; }

            [JsonPropertyName("daily_pay")] public FeeModelOrStringModel DailyPay { get; set; }

            [JsonPropertyName("subject")] public string Subject { get; set; }

            [JsonPropertyName("permlink")] public string PermLink { get; set; }
        }
    }
}