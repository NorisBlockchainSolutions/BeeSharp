using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace decline_voting_rights
    {
        [BroadcastOp("decline_voting_rights")]
        public class BroadcastOpDeclineVotingRightsModel : BroadcastOperation
        {
            /// <summary>
            ///     Decline voting rights (content and witnesses) of the account after a 30 day delay.
            ///     ATTENTION: This action is irreversible and cannot be undone (after 30 days)!
            /// </summary>
            /// <param name="account">Name of the account whose voting rights to decline.</param>
            /// <param name="decline">Whether to decline the voting rights (true) or not (false).</param>
            public BroadcastOpDeclineVotingRightsModel(string account, bool decline)
            {
                Account = account;
                Decline = decline;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("decline")] public bool Decline { get; }
        }
    }
}