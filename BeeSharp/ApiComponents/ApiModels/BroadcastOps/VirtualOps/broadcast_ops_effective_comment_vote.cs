using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace effective_comment_vote
    {
        [VirtualBroadcastOp("effective_comment_vote")]
        public class BroadcastVirtualOpsEffectiveCommentVoteModel : VirtualBroadcastOperation
        {
            /// <summary>
            ///     Required by hivemind to index estimated pending_payout from a given vote.
            /// </summary>
            /// <param name="voter">Account that placed the vote.</param>
            /// <param name="author">Author of the comment.</param>
            /// <param name="permLink">PermLink to the comment.</param>
            /// <param name="weight">Voting weight.</param>
            /// <param name="rShares">Amount of rshares.</param>
            /// <param name="totalVoteWeight">Total vote weight.</param>
            /// <param name="pendingPayout">Pending payout.</param>
            public BroadcastVirtualOpsEffectiveCommentVoteModel(string voter, string author, string permLink,
                NumberOrStringModel weight, string rShares, NumberOrStringModel totalVoteWeight,
                FeeModelOrStringModel pendingPayout)
            {
                Voter = voter;
                Author = author;
                PermLink = permLink;
                Weight = weight;
                RShares = rShares;
                TotalVoteWeight = totalVoteWeight;
                PendingPayout = pendingPayout;
            }

            [JsonPropertyName("voter")] public string Voter { get; }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            [JsonPropertyName("weight")] public NumberOrStringModel Weight { get; }

            [JsonPropertyName("rshares")] public string RShares { get; }

            [JsonPropertyName("total_vote_weight")]
            public NumberOrStringModel TotalVoteWeight { get; }

            [JsonPropertyName("pending_payout")] public FeeModelOrStringModel PendingPayout { get; }
        }
    }
}