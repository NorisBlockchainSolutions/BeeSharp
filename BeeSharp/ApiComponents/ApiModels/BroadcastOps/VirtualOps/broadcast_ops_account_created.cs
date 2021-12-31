using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace account_created
    {
        [VirtualBroadcastOp("account_created")]
        public class BroadcastVirtualOpAccountCreatedModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpAccountCreatedModel(string newAccountName, string creator,
                string initialVestingShares, string initialDelegation)
            {
                NewAccountName = newAccountName;
                Creator = creator;
                InitialVestingShares = initialVestingShares;
                InitialDelegation = initialDelegation;
            }

            [JsonPropertyName("new_account_name")] public string NewAccountName { get; }

            [JsonPropertyName("creator")] public string Creator { get; }

            [JsonPropertyName("initial_vesting_shares")]
            public string InitialVestingShares { get; }

            [JsonPropertyName("initial_delegation")]
            public string InitialDelegation { get; }
        }
    }
}