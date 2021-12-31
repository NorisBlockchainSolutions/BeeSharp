using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace comment_reward
    {
        [VirtualBroadcastOp("comment_reward")]
        public class BroadcastVirtualOpsCommentRewardModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpsCommentRewardModel(string author, string permLink, string payout)
            {
                Author = author;
                PermLink = permLink;
                Payout = payout;
            }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            [JsonPropertyName("payout")] public string Payout { get; }
        }
    }
}