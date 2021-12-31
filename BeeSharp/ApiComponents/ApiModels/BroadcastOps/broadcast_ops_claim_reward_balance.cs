using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace claim_reward_balance
    {
        [BroadcastOp("claim_reward_balance")]
        public class BroadcastOpClaimRewardBalanceModel : BroadcastOperation
        {
            public BroadcastOpClaimRewardBalanceModel(string account, string rewardHive, string rewardHbd,
                string rewardVests)
            {
                Account = account;
                RewardHive = rewardHive;
                RewardHbd = rewardHbd;
                RewardVests = rewardVests;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("reward_hive")] public string RewardHive { get; }

            [JsonPropertyName("reward_hbd")] public string RewardHbd { get; }

            [JsonPropertyName("reward_vests")] public string RewardVests { get; }
        }
    }
}