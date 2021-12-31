using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace curation_reward
    {
        [VirtualBroadcastOp("curation_reward")]
        public class BroadcastVirtualOpCurationRewardModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpCurationRewardModel(string curator, string reward, string author, string permLink)
            {
                Curator = curator;
                Reward = reward;
                Author = author;
                PermLink = permLink;
            }

            [JsonPropertyName("curator")] public string Curator { get; }

            [JsonPropertyName("reward")] public string Reward { get; }

            [JsonPropertyName("comment_author")] public string Author { get; }

            [JsonPropertyName("comment_permlink")] public string PermLink { get; }
        }
    }
}