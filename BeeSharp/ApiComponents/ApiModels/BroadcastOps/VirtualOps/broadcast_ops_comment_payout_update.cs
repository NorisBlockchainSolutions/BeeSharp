using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace comment_payout_update
    {
        [VirtualBroadcastOp("comment_payout_update")]
        public class BroadcastVirtualOpCommentPayoutUpdateModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpCommentPayoutUpdateModel(string author, string permLink)
            {
                Author = author;
                PermLink = permLink;
            }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }
        }
    }
}