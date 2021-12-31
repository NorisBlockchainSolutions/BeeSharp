using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace setUserTitle
    {
        [CustomJsonOpListOp("setUserTitle")]
        public class CustomJsonCommunityOpSetUserTitleModel : CustomJsonOperation
        {
            /// <summary>
            ///     Set a title (badge) for a given account in a community. Requires mod or higher.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="account">Account whose title to set.</param>
            /// <param name="title">The title to set.</param>
            public CustomJsonCommunityOpSetUserTitleModel(string community, string account, string title)
            {
                Community = community;
                Account = account;
                Title = title;
            }

            [JsonPropertyName("community")] public string Community { get; }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("title")] public string Title { get; }
        }
    }
}