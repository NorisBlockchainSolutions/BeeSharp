using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace unsubscribe
    {
        [CustomJsonOpListOp("unsubscribe")]
        public class CustomJsonCommunityOpUnsubscribeModel : CustomJsonOperation
        {
            /// <summary>
            ///     Allows an user to signify they no longer want this community shown on their personal trending feed or to
            ///     be shown in their navigation menu.
            /// </summary>
            /// <param name="community">PostId of the community to unsubscribe from.</param>
            public CustomJsonCommunityOpUnsubscribeModel(string community)
            {
                Community = community;
            }

            [JsonPropertyName("community")] public string Community { get; }
        }
    }
}