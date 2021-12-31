using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_reward_fund
    {
        public class CondenserApiGetRewardFund : ICondenserApiCall<string, CondenserApiRewardFundInfoModel>
        {
            public CondenserApiGetRewardFund(string fundName)
            {
                QueryParametersJson = new[] {fundName};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_reward_fund";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiRewardFundInfoModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiRewardFundInfoModel
        {
            public CondenserApiRewardFundInfoModel(NumberOrStringModel id, string name, string rewardBalance,
                string recentClaims, DateTime lastUpdate, string contentConstant,
                NumberOrStringModel percentCurationRewards, NumberOrStringModel percentContentRewards,
                string authorRewardCurve, string curationRewardCurve)
            {
                Id = id;
                Name = name;
                RewardBalance = rewardBalance;
                RecentClaims = recentClaims;
                LastUpdate = lastUpdate;
                ContentConstant = contentConstant;
                PercentCurationRewards = percentCurationRewards;
                PercentContentRewards = percentContentRewards;
                AuthorRewardCurve = authorRewardCurve;
                CurationRewardCurve = curationRewardCurve;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("name")] public string Name { get; }

            [JsonPropertyName("reward_balance")] public string RewardBalance { get; }

            [JsonPropertyName("recent_claims")] public string RecentClaims { get; }

            [JsonPropertyName("last_update")] public DateTime LastUpdate { get; }

            [JsonPropertyName("content_constant")] public string ContentConstant { get; }

            [JsonPropertyName("percent_curation_rewards")]
            public NumberOrStringModel PercentCurationRewards { get; }

            [JsonPropertyName("percent_content_rewards")]
            public NumberOrStringModel PercentContentRewards { get; }

            [JsonPropertyName("author_reward_curve")]
            public string AuthorRewardCurve { get; }

            [JsonPropertyName("curation_reward_curve")]
            public string CurationRewardCurve { get; }
        }
    }
}