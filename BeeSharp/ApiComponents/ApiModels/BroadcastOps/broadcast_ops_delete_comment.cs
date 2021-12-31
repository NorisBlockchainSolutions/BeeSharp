using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace delete_comment
    {
        [BroadcastOp("delete_comment")]
        public class BroadcastOpDeleteCommentModel : BroadcastOperation
        {
            public BroadcastOpDeleteCommentModel(string author, string permLink)
            {
                Author = author;
                PermLink = permLink;
            }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }
        }
    }
}