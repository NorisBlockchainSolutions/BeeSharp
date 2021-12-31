using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace comment
    {
        [BroadcastOp("comment")]
        public class BroadcastOpCommentModel : BroadcastOperation, ISerializableOperation
        {
            /// <summary>
            ///     Create/Update a post/comment
            /// </summary>
            /// <param name="parentAuthor">
            ///     The author that the comment is being submitted to.
            ///     When posting a new blog, this is an empty string.
            /// </param>
            /// <param name="parentPermLink">
            ///     The post the comment is being submitted to.
            ///     When posting a new blog, this is an empty string.
            /// </param>
            /// <param name="author">Accountname of the author of the post/comment</param>
            /// <param name="permLink">
            ///     The unique string identifier for the post, linked to the author of the post
            ///     Is only unique to the author (different authors can have the same identifier)!
            ///     If the permLink is not unique (e.g. already used by the author) it will be treated as an update.
            ///     Updates can either be done by replacing the entire body, or py patching with diff-match-patch.
            /// </param>
            /// <param name="title">Human readable title of the post. Often blank when commenting.</param>
            /// <param name="body">Body of the post/comment.</param>
            /// <param name="jsonMetadataModel"></param>
            public BroadcastOpCommentModel(string parentAuthor, string parentPermLink, string author, string permLink,
                string title, string body, JsonMetadataResponseModel jsonMetadataModel)
            {
                ParentAuthor = parentAuthor;
                ParentPermLink = parentPermLink;
                Author = author;
                PermLink = permLink;
                Title = title;
                Body = body;
                JsonMetadataModel = jsonMetadataModel;
            }

            /// <summary>
            ///     The author that the comment is being submitted to.
            ///     When posting a new blog, this is an empty string.
            /// </summary>
            [JsonPropertyName("parent_author")]
            public string ParentAuthor { get; }

            /// <summary>
            ///     The post the comment is being submitted to.
            ///     When posting a new blog, this is an empty string.
            /// </summary>
            [JsonPropertyName("parent_permlink")]
            public string ParentPermLink { get; }

            /// <summary>
            ///     Accountname of the author of the post/comment
            /// </summary>
            [JsonPropertyName("author")]
            public string Author { get; }

            /// <summary>
            ///     The unique string identifier for the post, linked to the author of the post
            ///     Is only unique to the author (different authors can have the same identifier)!
            ///     If the permLink is not unique (e.g. already used by the author) it will be treated as an update.
            ///     Updates can either be done by replacing the entire body, or py patching with diff-match-patch.
            /// </summary>
            [JsonPropertyName("permlink")]
            public string PermLink { get; }

            /// <summary>
            ///     Human readable title of the post. Often blank when commenting.
            /// </summary>
            // Since UTF8-Bytesize per character varies (between 1-4 bytes) the exact limit cannot be determined
            // Errors by the API can therefore still occur, even if the check below passes!
            [StringLength(256)]
            [JsonPropertyName("title")]
            public string Title { get; }

            /// <summary>
            ///     Body of the post/comment
            /// </summary>
            [NotNull]
            [JsonPropertyName("body")]
            public string Body { get; }

            [JsonPropertyName("json_metadata")] public JsonMetadataResponseModel JsonMetadataModel { get; }

            public HivedOperationId GetOperationId()
            {
                return HivedOperationId.comment;
            }

            public string GetOperationName()
            {
                return "comment";
            }

            public object GetOperationModel()
            {
                return this;
            }

            public byte[] SerializeOperation()
            {
                var result = new MemoryStream();
                var writer = new BinaryWriter(result, Encoding.UTF8);
                writer.Write(ParentAuthor);
                writer.Write(ParentPermLink);
                writer.Write(Author);
                writer.Write(PermLink);
                writer.Write(Title);
                writer.Write(Body);
                // Only rawResponse serialization is currently supported!
                writer.Write(JsonMetadataModel.RawResponse);

                return result.ToArray();
            }
        }
    }
}