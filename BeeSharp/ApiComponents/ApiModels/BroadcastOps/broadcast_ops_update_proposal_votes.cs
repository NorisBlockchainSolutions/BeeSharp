using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace update_proposal_votes
    {
        [BroadcastOp("update_proposal_votes")]
        public class BroadcastOpUpdateProposalVotesModel : BroadcastOperation
        {
            public BroadcastOpUpdateProposalVotesModel(string voter, NumberOrStringModel[] proposalIds, bool approve)
            {
                Voter = voter;
                ProposalIds = proposalIds;
                Approve = approve;
            }

            [JsonPropertyName("voter")] public string Voter { get; }

            [JsonPropertyName("proposal_ids")] public NumberOrStringModel[] ProposalIds { get; }

            [JsonPropertyName("approve")] public bool Approve { get; }
        }
    }
}