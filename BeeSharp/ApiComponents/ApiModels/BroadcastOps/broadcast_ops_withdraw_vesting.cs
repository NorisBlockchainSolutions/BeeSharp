using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace withdraw_vesting
    {
        [BroadcastOp("withdraw_vesting")]
        public class BroadcastOpWithdrawVestingModel : BroadcastOperation
        {
            /// <summary>
            ///     Unstake/Power-down. Withdraw vesting shares (VESTS) and convert them to HIVE.
            ///     Vesting shares are withdrawn at vestingShares/13 per week for 13 weeks starting one week after this
            ///     operation is included in the blockchain.
            /// </summary>
            /// <param name="account">Account that withdraws VESTS.</param>
            /// <param name="vestingShares">Amount of VESTS to withdraw in (hive-)percent.</param>
            public BroadcastOpWithdrawVestingModel(string account, FeeModelOrStringModel vestingShares)
            {
                Account = account;
                VestingShares = vestingShares;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("vesting_shares")] public FeeModelOrStringModel VestingShares { get; }
        }
    }
}