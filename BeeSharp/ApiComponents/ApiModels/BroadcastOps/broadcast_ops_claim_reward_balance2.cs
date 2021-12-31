using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace claim_reward_balance2
    {
        [BroadcastOp("claim_reward_balance2")]
        public class BroadcastOpClaimRewardBalance2Model : BroadcastOperation
        {
            /// <summary>
            ///     Differs to the original operation by having an extension field and a container of tokens that will be
            ///     rewarded to an account.
            /// </summary>
            /// <param name="account">The account that claims reward balance.</param>
            /// <param name="rewardTokens">The tokens to claim.</param>
            /// <param name="extensions">Extensions.</param>
            public BroadcastOpClaimRewardBalance2Model(string account, FeeModelOrStringModel[] rewardTokens,
                ExtensionModel[]? extensions = null)
            {
                Account = account;
                RewardTokens = rewardTokens;
                Extensions = extensions ?? Array.Empty<ExtensionModel>();
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("reward_tokens")] public FeeModelOrStringModel[] RewardTokens { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }
    }
}