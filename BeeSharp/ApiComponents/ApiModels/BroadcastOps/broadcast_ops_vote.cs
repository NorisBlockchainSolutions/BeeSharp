using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace vote
    {
        [BroadcastOp("vote")]
        public class BroadcastOpVoteModel : BroadcastOperation, ISerializableOperation
        {
            /// <summary>
            ///     Vote on a post/comment.
            ///     An upvote can be cast from content creation to 6.5 days after.
            ///     A downvote can be cast from content creation to 7 days after.
            ///     Reputation rules:
            ///     - Must have non-negative reputation to effect another user's reputation.
            ///     - When downvoting, your reputation must be higher than the reputation of the downvoted user to affect
            ///     his reputation.
            /// </summary>
            /// <param name="voter">Account that votes.</param>
            /// <param name="author">Author of the post/comment that is voted on.</param>
            /// <param name="permLink">PermLink of the post/comment that is voted on.</param>
            /// <param name="weight">Vote-Weight in (hive-)percent.</param>
            public BroadcastOpVoteModel(string voter, string author, string permLink, short weight)
            {
                Voter = voter;
                Author = author;
                PermLink = permLink;
                Weight = weight;
            }

            [JsonPropertyName("voter")] public string Voter { get; }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            // Between 10,000 (+100%) and -10,000 (-100%)
            [JsonPropertyName("weight")] public short Weight { get; }

            public HivedOperationId GetOperationId()
            {
                return HivedOperationId.vote;
            }

            public string GetOperationName()
            {
                return "vote";
            }

            public object GetOperationModel()
            {
                return this;
            }

            public byte[] SerializeOperation()
            {
                var result = new MemoryStream();
                var writer = new BinaryWriter(result, Encoding.UTF8);
                writer.Write(Voter);
                writer.Write(Author);
                writer.Write(PermLink);
                writer.Write(Weight);

                return result.ToArray();
            }
        }
    }
}