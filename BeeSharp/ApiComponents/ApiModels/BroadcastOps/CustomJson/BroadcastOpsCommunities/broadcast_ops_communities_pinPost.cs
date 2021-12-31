using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace pinPost
    {
        [CustomJsonOpListOp("pinPost")]
        public class CustomJsonCommunityOpPinPostModel : CustomJsonOperation
        {
            /// <summary>
            ///     Stickies a post to the top of the community homepage. If multiple posts are stickied, the newest ones
            ///     are shown first. Requires mod or higher.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="account">Account that created the post.</param>
            /// <param name="permLink">PermLink to the post.</param>
            public CustomJsonCommunityOpPinPostModel(string community, string account, string permLink)
            {
                Community = community;
                Account = account;
                PermLink = permLink;
            }

            [JsonPropertyName("community")] public string Community { get; }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }
        }
    }
}