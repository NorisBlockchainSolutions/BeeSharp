using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace delay_voting
    {
        [VirtualBroadcastOp("delayed_voting")]
        public class BroadcastVirtualOpsDelayedVotingModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpsDelayedVotingModel(string voter, NumberOrStringModel votes)
            {
                Voter = voter;
                Votes = votes;
            }

            [JsonPropertyName("voter")] public string Voter { get; }

            [JsonPropertyName("votes")] public NumberOrStringModel Votes { get; }
        }
    }
}