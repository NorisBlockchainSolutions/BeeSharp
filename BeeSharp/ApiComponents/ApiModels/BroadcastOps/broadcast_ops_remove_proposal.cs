using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace remove_proposal
    {
        [BroadcastOp("remove_proposal")]
        public class BroadcastOpRemoveProposalModel : BroadcastOperation
        {
            public BroadcastOpRemoveProposalModel(string creator, NumberOrStringModel[] proposalIds)
            {
                Creator = creator;
                ProposalIds = proposalIds;
            }

            [JsonPropertyName("creator")] public string Creator { get; }

            [JsonPropertyName("proposal_ids")] public NumberOrStringModel[] ProposalIds { get; }
        }
    }
}