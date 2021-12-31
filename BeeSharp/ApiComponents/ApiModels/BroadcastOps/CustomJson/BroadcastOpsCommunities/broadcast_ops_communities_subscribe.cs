using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace subscribe
    {
        [CustomJsonOpListOp("subscribe")]
        public class CustomJsonCommunityOpSubscribeModel : CustomJsonOperation
        {
            /// <summary>
            ///     Allows a user to signify they want this community shown on their personal trending feed and to be shown
            ///     in their navigation menu.
            /// </summary>
            /// <param name="community">The community id to subscribe to.</param>
            public CustomJsonCommunityOpSubscribeModel(string community)
            {
                Community = community;
            }

            [JsonPropertyName("community")] public string Community { get; }
        }
    }
}