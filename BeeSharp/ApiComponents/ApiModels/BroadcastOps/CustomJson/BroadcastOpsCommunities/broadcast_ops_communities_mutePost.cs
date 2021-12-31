using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace mutePost
    {
        [CustomJsonOpListOp("mutePost")]
        public class CustomJsonCommunityOpMutePostModel : CustomJsonOperation
        {
            /// <summary>
            ///     Mute a post. Can be a topic or a comment. Requires mod or higher.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="account">Account that created the topic/comment.</param>
            /// <param name="permLink">PermLink to the comment to mute.</param>
            /// <param name="notes">Additional notes.</param>
            public CustomJsonCommunityOpMutePostModel(string community, string account, string permLink, string notes)
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