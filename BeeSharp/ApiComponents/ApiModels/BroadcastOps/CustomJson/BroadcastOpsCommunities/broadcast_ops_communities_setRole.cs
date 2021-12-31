using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace setRole
    {
        [CustomJsonOpListOp("setRole")]
        public class CustomJsonCommunityOpSetRoleModel : CustomJsonOperation
        {
            /// <summary>
            ///     Sets a role for a given account in a community.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="account">Account to set role for.</param>
            /// <param name="role">The role to set.</param>
            public CustomJsonCommunityOpSetRoleModel(string community, string account, string role)
            {
                Community = community;
                Account = account;
                Role = role;
            }

            [JsonPropertyName("community")] public string Community { get; }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("role")] public string Role { get; }
        }
    }
}