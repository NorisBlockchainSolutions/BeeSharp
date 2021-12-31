using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace unpinPost
    {
        [CustomJsonOpListOp("unpinPost")]
        public class CustomJsonCommunityOpUnpinPostModel : CustomJsonOperation
        {
            /// <summary>
            ///     Removes a post from the top of the community homepage. Requires mod or higher.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="account">Account whose post is unpinned.</param>
            /// <param name="permLink">PermLink to the post that is unpinned.</param>
            public CustomJsonCommunityOpUnpinPostModel(string community, string account, string permLink)
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