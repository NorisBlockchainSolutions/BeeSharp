using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace return_vesting_delegation
    {
        [VirtualBroadcastOp("return_vesting_delegation")]
        public class BroadcastVirtualOpReturnVestingDelegationModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpReturnVestingDelegationModel(string account, string vestingShares)
            {
                Account = account;
                VestingShares = vestingShares;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("vesting_shares")] public string VestingShares { get; }
        }
    }
}