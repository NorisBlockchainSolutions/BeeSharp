using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace comment_benefactor_reward
    {
        [VirtualBroadcastOp("comment_benefactor_reward")]
        public class BroadcastVirtualOpCommentBenefactorRewardModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpCommentBenefactorRewardModel(string benefactor, string author, string permLink,
                string reward)
            {
                Benefactor = benefactor;
                Author = author;
                PermLink = permLink;
                Reward = reward;
            }

            [JsonPropertyName("benefactor")] public string Benefactor { get; }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            [JsonPropertyName("reward")] public string Reward { get; }
        }
    }
}