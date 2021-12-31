using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace update_proposal
    {
        [BroadcastOp("update_proposal")]
        public class BroadcastOpUpdateProposalModel : BroadcastOperation
        {
            /// <summary>
            ///     Update a proposal.
            ///     Allows the creator to lower daily_pay but not to increase it,
            ///     change subject
            ///     and point to a new permLink.
            /// </summary>
            /// <param name="proposalId">PostId of the proposal.</param>
            /// <param name="creator">Creator of the proposal</param>
            /// <param name="dailyPay">Amount of daily pay.</param>
            /// <param name="subject">Subject of the proposal.</param>
            /// <param name="permLink">PermLink of the proposal.</param>
            public BroadcastOpUpdateProposalModel(NumberOrStringModel proposalId, string creator,
                FeeModelOrStringModel dailyPay, string subject, string permLink)
            {
                ProposalId = proposalId;
                Creator = creator;
                DailyPay = dailyPay;
                Subject = subject;
                PermLink = permLink;
            }

            [JsonPropertyName("proposal_id")] public NumberOrStringModel ProposalId { get; }

            [JsonPropertyName("creator")] public string Creator { get; }

            [JsonPropertyName("daily_pay")] public FeeModelOrStringModel DailyPay { get; }

            [JsonPropertyName("subject")] public string Subject { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }
        }
    }
}