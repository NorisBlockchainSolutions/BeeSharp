using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace unmutePost
    {
        [CustomJsonOpListOp("unmutePost")]
        public class CustomJsonCommunityOpUnmutePostModel : CustomJsonOperation
        {
            /// <summary>
            ///     Unmute a post. Requires mod or higher.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="account">Account whose post to unmute.</param>
            /// <param name="permLink">PermLink to the post to unmute.</param>
            /// <param name="notes">Additional notes.</param>
            public CustomJsonCommunityOpUnmutePostModel(string community, string account, string permLink, string notes)
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