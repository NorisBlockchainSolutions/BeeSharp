using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace delegate_vesting_shares
    {
        [BroadcastOp("delegate_vesting_shares")]
        public class BroadcastOpDelegateVestingSharesModel : BroadcastOperation
        {
            /// <summary>
            ///     Delegate vesting shares to another account. Transfers content voting rights and RC to the receiving
            ///     account (VESTS still owned by delegator).
            ///     Removal of a VEST delegation results in inaccessible of said VESTS for a week, before returning them to
            ///     the delegator.
            /// </summary>
            /// <param name="delegator">The account that delegates VESTS.</param>
            /// <param name="delegatee">The account that receives the VEST delegation.</param>
            /// <param name="vestingShares">The amount of VESTS to delegate.</param>
            public BroadcastOpDelegateVestingSharesModel(string delegator, string delegatee, string vestingShares)
            {
                Delegator = delegator;
                Delegatee = delegatee;
                VestingShares = vestingShares;
            }

            [JsonPropertyName("delegator")] public string Delegator { get; }

            [JsonPropertyName("delegatee")] public string Delegatee { get; }

            [JsonPropertyName("vesting_shares")] public string VestingShares { get; }
        }
    }
}