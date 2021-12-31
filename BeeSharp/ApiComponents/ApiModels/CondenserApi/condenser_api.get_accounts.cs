using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_accounts
    {
        public class CondenserApiGetAccounts : ICondenserApiCall<string[], List<CondenserApiAccountModel>>
        {
            public CondenserApiGetAccounts(string[] accountNames)
            {
                QueryParametersJson = new[] {accountNames};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[][] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_accounts";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiAccountModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiAccountModel
        {
            /// <summary>
            ///     This constructor IS ONLY FOR USAGE BY JSONSERIALIZER!
            /// </summary>
            [JsonConstructor]
            [Obsolete("This constructor is ONLY FOR USAGE BY JSONSERIALIZER!", true)]
            public CondenserApiAccountModel()
            {
                // Since the default constructor contains more than 64 elements, it is not supported by System.Net.Json.
            }

            public CondenserApiAccountModel(NumberOrStringModel id, string name, AccountKeyModel owner,
                AccountKeyModel active,
                AccountKeyModel posting, string memoKey, JsonMetadataResponseModel jsonMetadata,
                PostingJsonMetadataResponseModel postingJsonMetadata, string proxy, DateTime lastOwnerUpdate,
                DateTime lastAccountUpdate, DateTime created, bool mined, string recoveryAccount,
                DateTime lastAccountRecovery, string resetAccount, NumberOrStringModel commentCount,
                NumberOrStringModel lifetimeVoteCount, NumberOrStringModel postCount, bool canVote,
                CondenserApiManaBarModel votingCondenserApiManaBar,
                CondenserApiManaBarModel downVoteCondenserApiManaBar, NumberOrStringModel votingPower,
                DateTime lastVoteTime, string balance, string savingsBalance, string hbdBalance, string hbdSeconds,
                DateTime hbdSecondsLastUpdate, DateTime hbdLastInterestPayment, string savingsHbdBalance,
                string savingsHbdSeconds, DateTime savingsHbdSecondsLastUpdate, DateTime savingsHbdLastInterestPayment,
                NumberOrStringModel savingsWithdrawRequests, string rewardHbdBalance, string rewardHiveBalance,
                string rewardVestingBalance, string rewardVestingHive, string vestingShares,
                string delegatedVestingShares, string receivedVestingShares, string vestingWithdrawRate,
                DateTime nextVestingWithdrawal, NumberOrStringModel withdrawn, NumberOrStringModel toWithdraw,
                NumberOrStringModel withdrawRoutes, NumberOrStringModel curationRewards,
                NumberOrStringModel postingRewards, NumberOrStringModel[] proxiedVsfVotes,
                NumberOrStringModel witnessesVotedFor, DateTime lastPost, DateTime lastRootPost,
                NumberOrStringModel postBandwidth, NumberOrStringModel pendingClaimedAccounts,
                DelayedVotesModel[] delayedVotes, string vestingBalance, NumberOrStringModel reputation,
                object[] transferHistory,
                object[] marketHistory, object[] postHistory, object[] voteHistory, object[] otherHistory,
                string[] witnessVotes, object[] tagsUsage, object[] guestBloggers)
            {
                Id = id;
                Name = name;
                Owner = owner;
                Active = active;
                Posting = posting;
                MemoKey = memoKey;
                JsonMetadata = jsonMetadata;
                PostingJsonMetadata = postingJsonMetadata;
                Proxy = proxy;
                LastOwnerUpdate = lastOwnerUpdate;
                LastAccountUpdate = lastAccountUpdate;
                Created = created;
                Mined = mined;
                RecoveryAccount = recoveryAccount;
                LastAccountRecovery = lastAccountRecovery;
                ResetAccount = resetAccount;
                CommentCount = commentCount;
                LifetimeVoteCount = lifetimeVoteCount;
                PostCount = postCount;
                CanVote = canVote;
                VotingCondenserApiManaBar = votingCondenserApiManaBar;
                DownVoteCondenserApiManaBar = downVoteCondenserApiManaBar;
                VotingPower = votingPower;
                LastVoteTime = lastVoteTime;
                Balance = balance;
                SavingsBalance = savingsBalance;
                HbdBalance = hbdBalance;
                HbdSeconds = hbdSeconds;
                HbdSecondsLastUpdate = hbdSecondsLastUpdate;
                HbdLastInterestPayment = hbdLastInterestPayment;
                SavingsHbdBalance = savingsHbdBalance;
                SavingsHbdSeconds = savingsHbdSeconds;
                SavingsHbdSecondsLastUpdate = savingsHbdSecondsLastUpdate;
                SavingsHbdLastInterestPayment = savingsHbdLastInterestPayment;
                SavingsWithdrawRequests = savingsWithdrawRequests;
                RewardHbdBalance = rewardHbdBalance;
                RewardHiveBalance = rewardHiveBalance;
                RewardVestingBalance = rewardVestingBalance;
                RewardVestingHive = rewardVestingHive;
                VestingShares = vestingShares;
                DelegatedVestingShares = delegatedVestingShares;
                ReceivedVestingShares = receivedVestingShares;
                VestingWithdrawRate = vestingWithdrawRate;
                NextVestingWithdrawal = nextVestingWithdrawal;
                Withdrawn = withdrawn;
                ToWithdraw = toWithdraw;
                WithdrawRoutes = withdrawRoutes;
                CurationRewards = curationRewards;
                PostingRewards = postingRewards;
                ProxiedVsfVotes = proxiedVsfVotes;
                WitnessesVotedFor = witnessesVotedFor;
                LastPost = lastPost;
                LastRootPost = lastRootPost;
                PostBandwidth = postBandwidth;
                PendingClaimedAccounts = pendingClaimedAccounts;
                DelayedVotes = delayedVotes;
                VestingBalance = vestingBalance;
                Reputation = reputation;
                TransferHistory = transferHistory;
                MarketHistory = marketHistory;
                PostHistory = postHistory;
                VoteHistory = voteHistory;
                OtherHistory = otherHistory;
                WitnessVotes = witnessVotes;
                TagsUsage = tagsUsage;
                GuestBloggers = guestBloggers;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; set; }

            [JsonPropertyName("name")] public string Name { get; set; }

            [JsonPropertyName("owner")] public AccountKeyModel Owner { get; set; }

            [JsonPropertyName("active")] public AccountKeyModel Active { get; set; }

            [JsonPropertyName("posting")] public AccountKeyModel Posting { get; set; }

            [JsonPropertyName("memo_key")] public string MemoKey { get; set; }

            [JsonPropertyName("json_metadata")] public JsonMetadataResponseModel JsonMetadata { get; set; }

            [JsonPropertyName("posting_json_metadata")]
            public PostingJsonMetadataResponseModel PostingJsonMetadata { get; set; }

            [JsonPropertyName("proxy")] public string Proxy { get; set; }

            [JsonPropertyName("last_owner_update")]
            public DateTime LastOwnerUpdate { get; set; }

            [JsonPropertyName("last_account_update")]
            public DateTime LastAccountUpdate { get; set; }

            [JsonPropertyName("created")] public DateTime Created { get; set; }

            [JsonPropertyName("mined")] public bool Mined { get; set; }

            [JsonPropertyName("recovery_account")] public string RecoveryAccount { get; set; }

            [JsonPropertyName("last_account_recovery")]
            public DateTime LastAccountRecovery { get; set; }

            [JsonPropertyName("reset_account")] public string ResetAccount { get; set; }

            [JsonPropertyName("comment_count")] public NumberOrStringModel CommentCount { get; set; }

            [JsonPropertyName("lifetime_vote_count")]
            public NumberOrStringModel LifetimeVoteCount { get; set; }

            [JsonPropertyName("post_count")] public NumberOrStringModel PostCount { get; set; }

            [JsonPropertyName("can_vote")] public bool CanVote { get; set; }

            [JsonPropertyName("voting_manabar")] public CondenserApiManaBarModel VotingCondenserApiManaBar { get; set; }

            [JsonPropertyName("downvote_manabar")]
            public CondenserApiManaBarModel DownVoteCondenserApiManaBar { get; set; }

            [JsonPropertyName("voting_power")] public NumberOrStringModel VotingPower { get; set; }

            [JsonPropertyName("last_vote_time")] public DateTime LastVoteTime { get; set; }

            [JsonPropertyName("balance")] public string Balance { get; set; }

            [JsonPropertyName("savings_balance")] public string SavingsBalance { get; set; }

            [JsonPropertyName("hbd_balance")] public string HbdBalance { get; set; }

            [JsonPropertyName("hbd_seconds")] public string HbdSeconds { get; set; }

            [JsonPropertyName("hbd_seconds_last_update")]
            public DateTime HbdSecondsLastUpdate { get; set; }

            [JsonPropertyName("hbd_last_interest_payment")]
            public DateTime HbdLastInterestPayment { get; set; }

            [JsonPropertyName("savings_hbd_balance")]
            public string SavingsHbdBalance { get; set; }

            [JsonPropertyName("savings_hbd_seconds")]
            public string SavingsHbdSeconds { get; set; }

            [JsonPropertyName("savings_hbd_seconds_last_update")]
            public DateTime SavingsHbdSecondsLastUpdate { get; set; }

            [JsonPropertyName("savings_hbd_last_interest_payment")]
            public DateTime SavingsHbdLastInterestPayment { get; set; }

            [JsonPropertyName("savings_withdraw_requests")]
            public NumberOrStringModel SavingsWithdrawRequests { get; set; }

            [JsonPropertyName("reward_hbd_balance")]
            public string RewardHbdBalance { get; set; }

            [JsonPropertyName("reward_hive_balance")]
            public string RewardHiveBalance { get; set; }

            [JsonPropertyName("reward_vesting_balance")]
            public string RewardVestingBalance { get; set; }

            [JsonPropertyName("reward_vesting_hive")]
            public string RewardVestingHive { get; set; }

            [JsonPropertyName("vesting_shares")] public string VestingShares { get; set; }

            [JsonPropertyName("delegated_vesting_shares")]
            public string DelegatedVestingShares { get; set; }

            [JsonPropertyName("received_vesting_shares")]
            public string ReceivedVestingShares { get; set; }

            [JsonPropertyName("vesting_withdraw_rate")]
            public string VestingWithdrawRate { get; set; }

            [JsonPropertyName("next_vesting_withdrawal")]
            public DateTime NextVestingWithdrawal { get; set; }

            [JsonPropertyName("withdrawn")] public NumberOrStringModel Withdrawn { get; set; }

            [JsonPropertyName("to_withdraw")] public NumberOrStringModel ToWithdraw { get; set; }

            [JsonPropertyName("withdraw_routes")] public NumberOrStringModel WithdrawRoutes { get; set; }

            [JsonPropertyName("curation_rewards")] public NumberOrStringModel CurationRewards { get; set; }

            [JsonPropertyName("posting_rewards")] public NumberOrStringModel PostingRewards { get; set; }

            [JsonPropertyName("proxied_vsf_votes")]
            public NumberOrStringModel[] ProxiedVsfVotes { get; set; }

            [JsonPropertyName("witnesses_voted_for")]
            public NumberOrStringModel WitnessesVotedFor { get; set; }

            [JsonPropertyName("last_post")] public DateTime LastPost { get; set; }

            [JsonPropertyName("last_root_post")] public DateTime LastRootPost { get; set; }

            [JsonPropertyName("post_bandwidth")] public NumberOrStringModel PostBandwidth { get; set; }

            [JsonPropertyName("pending_claimed_accounts")]
            public NumberOrStringModel PendingClaimedAccounts { get; set; }

            [JsonPropertyName("delayed_votes")] public DelayedVotesModel[] DelayedVotes { get; set; }

            [JsonPropertyName("vesting_balance")] public string VestingBalance { get; set; }

            [JsonPropertyName("reputation")] public NumberOrStringModel Reputation { get; set; }

            [JsonPropertyName("transfer_history")] public object[] TransferHistory { get; set; }

            [JsonPropertyName("market_history")] public object[] MarketHistory { get; set; }

            [JsonPropertyName("post_history")] public object[] PostHistory { get; set; }

            [JsonPropertyName("vote_history")] public object[] VoteHistory { get; set; }

            [JsonPropertyName("other_history")] public object[] OtherHistory { get; set; }

            [JsonPropertyName("witness_votes")] public string[] WitnessVotes { get; set; }

            [JsonPropertyName("tags_usage")] public object[] TagsUsage { get; set; }

            [JsonPropertyName("guest_bloggers")] public object[] GuestBloggers { get; set; }
        }

        public class CondenserApiManaBarModel
        {
            public CondenserApiManaBarModel(NumberOrStringModel currentMana, NumberOrStringModel lastUpdateTime)
            {
                CurrentMana = currentMana;
                LastUpdateTime = lastUpdateTime;
            }

            [JsonPropertyName("current_mana")] public NumberOrStringModel CurrentMana { get; }

            [JsonPropertyName("last_update_time")] public NumberOrStringModel LastUpdateTime { get; }
        }

        public class DelayedVotesModel
        {
            public DelayedVotesModel(DateTime time, NumberOrStringModel value)
            {
                Time = time;
                Value = value;
            }

            [JsonPropertyName("time")] public DateTime Time { get; }

            [JsonPropertyName("val")] public NumberOrStringModel Value { get; }
        }
    }
}