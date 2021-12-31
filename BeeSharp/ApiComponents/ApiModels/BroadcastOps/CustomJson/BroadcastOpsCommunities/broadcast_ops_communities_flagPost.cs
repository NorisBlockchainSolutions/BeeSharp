using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace flagPost
    {
        [CustomJsonOpListOp("flagPost")]
        public class CustomJsonCommunityOpFlagPostModel : CustomJsonOperation
        {
            /// <summary>
            ///     Used by guests to suggest a post for the review queue. It's up to the community to define what
            ///     constitutes flagging.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="account">Name of the account whose post should be flagged.</param>
            /// <param name="permLink">The permLink to the post that should be flagged.</param>
            /// <param name="notes">Additional notes.</param>
            public CustomJsonCommunityOpFlagPostModel(string community, string account, string permLink, string notes)
            {
                Community = community;
                Account = account;
                PermLink = permLink;
                Notes = notes;
            }

            [JsonPropertyName("community")] public string Community { get; }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            [JsonPropertyName("notes")] public string Notes { get; }
        }
    }
}