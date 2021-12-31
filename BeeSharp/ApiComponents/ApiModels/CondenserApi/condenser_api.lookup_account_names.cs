using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_accounts;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace lookup_account_names
    {
        public class CondenserApiLookupAccountNames : ICondenserApiCall<object, List<CondenserApiLookupAccountModel>>
        {
            public CondenserApiLookupAccountNames(string[] accountNames, bool delayedVotesActive)
            {
                QueryParametersJson = new[] {accountNames, (object) delayedVotesActive};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.lookup_account_names";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiLookupAccountModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiLookupAccountModel
        {
            public CondenserApiLookupAccountModel(NumberOrStringModel id, string name, AccountKeyModel owner,
                AccountKeyModel active, AccountKeyModel posting, string memoKey, JsonMetadataResponseModel jsonMetadata,
                PostingJsonMetadataResponseModel postingJsonMetadata, string proxy, DateTime lastOwnerUpdate,
                DateTime lastAccountUpdate, DateTime created, bool mined, string recoveryAccount,
                DateTime lastAccountRecovery, string resetAccount, NumberOrStringModel commentCount,
                NumberOrStringModel lifetimeVoteCount, NumberOrStringModel postCount, bool canVote,
                CondenserApiManaBarModel votingCondenserApiManaBar,
                CondenserApiManaBarModel downVoteCondenserApiManaBar, NumberOrStringModel votingPower, string balance,
                string savingsBalance, string hbdBalance, string hbdSeconds, DateTime hbdSecondsLastUpdate,
                DateTime hbdLastInterestPayment, string savingsHbdBalance, string savingsHbdSeconds,
                DateTime savingsHbdSecondsLastUpdate, DateTime savingsHbdLastInterestPayment,
                NumberOrStringModel savingsWithdrawRequests, string rewardHbdBalance, string rewardHiveBalance,
                string rewardVestingBalance, string rewardVestingHive, string vestingShares,
                string delegatedVestingShares, string receivedVestingShares, string vestingWithdrawRate,
                string postVotingPower, DateTime nextVestingWithdrawal, NumberOrStringModel withdrawn,
                NumberOrStringModel toWithdraw, NumberOrStringModel withdrawRoutes,
                NumberOrStringModel pendingTransfers, NumberOrStringModel curationRewards,
                NumberOrStringModel postingRewards, NumberOrStringModel[] proxiedVsfVotes,
                NumberOrStringModel witnessesVotedFor, DateTime lastPost, DateTime lastRootPost, DateTime lastVoteTime,
                NumberOrStringModel postBandwidth, NumberOrStringModel pendingClaimedAccounts,
                DelayedVotesModel[] delayedVotes)
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
                PostVotingPower = postVotingPower;
                NextVestingWithdrawal = nextVestingWithdrawal;
                Withdrawn = withdrawn;
                ToWithdraw = toWithdraw;
                WithdrawRoutes = withdrawRoutes;
                PendingTransfers = pendingTransfers;
                CurationRewards = curationRewards;
                PostingRewards = postingRewards;
                ProxiedVsfVotes = proxiedVsfVotes;
                WitnessesVotedFor = witnessesVotedFor;
                LastPost = lastPost;
                LastRootPost = lastRootPost;
                LastVoteTime = lastVoteTime;
                PostBandwidth = postBandwidth;
                PendingClaimedAccounts = pendingClaimedAccounts;
                DelayedVotes = delayedVotes;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("name")] public string Name { get; }

            [JsonPropertyName("owner")] public AccountKeyModel Owner { get; }

            [JsonPropertyName("active")] public AccountKeyModel Active { get; }

            [JsonPropertyName("posting")] public AccountKeyModel Posting { get; }

            [JsonPropertyName("memo_key")] public string MemoKey { get; }

            [JsonPropertyName("json_metadata")] public JsonMetadataResponseModel JsonMetadata { get; }

            [JsonPropertyName("posting_json_metadata")]
            public PostingJsonMetadataResponseModel PostingJsonMetadata { get; }

            [JsonPropertyName("proxy")] public string Proxy { get; }

            [JsonPropertyName("last_owner_update")]
            public DateTime LastOwnerUpdate { get; }

            [JsonPropertyName("last_account_update")]
            public DateTime LastAccountUpdate { get; }

            [JsonPropertyName("created")] public DateTime Created { get; }

            [JsonPropertyName("mined")] public bool Mined { get; }

            [JsonPropertyName("recovery_account")] public string RecoveryAccount { get; }

            [JsonPropertyName("last_account_recovery")]
            public DateTime LastAccountRecovery { get; }

            [JsonPropertyName("reset_account")] public string ResetAccount { get; }

            [JsonPropertyName("comment_count")] public NumberOrStringModel CommentCount { get; }

            [JsonPropertyName("lifetime_vote_count")]
            public NumberOrStringModel LifetimeVoteCount { get; }

            [JsonPropertyName("post_count")] public NumberOrStringModel PostCount { get; }

            [JsonPropertyName("can_vote")] public bool CanVote { get; }

            [JsonPropertyName("voting_manabar")] public CondenserApiManaBarModel VotingCondenserApiManaBar { get; }

            [JsonPropertyName("downvote_manabar")] public CondenserApiManaBarModel DownVoteCondenserApiManaBar { get; }

            [JsonPropertyName("voting_power")] public NumberOrStringModel VotingPower { get; }

            [JsonPropertyName("balance")] public string Balance { get; }

            [JsonPropertyName("savings_balance")] public string SavingsBalance { get; }

            [JsonPropertyName("hbd_balance")] public string HbdBalance { get; }

            [JsonPropertyName("hbd_seconds")] public string HbdSeconds { get; }

            [JsonPropertyName("hbd_seconds_last_update")]
            public DateTime HbdSecondsLastUpdate { get; }

            [JsonPropertyName("hbd_last_interest_payment")]
            public DateTime HbdLastInterestPayment { get; }

            [JsonPropertyName("savings_hbd_balance")]
            public string SavingsHbdBalance { get; }

            [JsonPropertyName("savings_hbd_seconds")]
            public string SavingsHbdSeconds { get; }

            [JsonPropertyName("savings_hbd_seconds_last_update")]
            public DateTime SavingsHbdSecondsLastUpdate { get; }

            [JsonPropertyName("savings_hbd_last_interest_payment")]
            public DateTime SavingsHbdLastInterestPayment { get; }

            [JsonPropertyName("savings_withdraw_requests")]
            public NumberOrStringModel SavingsWithdrawRequests { get; }

            [JsonPropertyName("reward_hbd_balance")]
            public string RewardHbdBalance { get; }

            [JsonPropertyName("reward_hive_balance")]
            public string RewardHiveBalance { get; }

            [JsonPropertyName("reward_vesting_balance")]
            public string RewardVestingBalance { get; }

            [JsonPropertyName("reward_vesting_hive")]
            public string RewardVestingHive { get; }

            [JsonPropertyName("vesting_shares")] public string VestingShares { get; }

            [JsonPropertyName("delegated_vesting_shares")]
            public string DelegatedVestingShares { get; }

            [JsonPropertyName("received_vesting_shares")]
            public string ReceivedVestingShares { get; }

            [JsonPropertyName("vesting_withdraw_rate")]
            public string VestingWithdrawRate { get; }

            [JsonPropertyName("post_voting_power")]
            public string PostVotingPower { get; }

            [JsonPropertyName("next_vesting_withdrawal")]
            public DateTime NextVestingWithdrawal { get; }

            [JsonPropertyName("withdrawn")] public NumberOrStringModel Withdrawn { get; }

            [JsonPropertyName("to_withdraw")] public NumberOrStringModel ToWithdraw { get; }

            [JsonPropertyName("withdraw_routes")] public NumberOrStringModel WithdrawRoutes { get; }

            [JsonPropertyName("pending_transfers")]
            public NumberOrStringModel PendingTransfers { get; }

            [JsonPropertyName("curation_rewards")] public NumberOrStringModel CurationRewards { get; }

            [JsonPropertyName("posting_rewards")] public NumberOrStringModel PostingRewards { get; }

            [JsonPropertyName("proxied_vsf_votes")]
            public NumberOrStringModel[] ProxiedVsfVotes { get; }

            [JsonPropertyName("witnesses_voted_for")]
            public NumberOrStringModel WitnessesVotedFor { get; }

            [JsonPropertyName("last_post")] public DateTime LastPost { get; }

            [JsonPropertyName("last_root_post")] public DateTime LastRootPost { get; }

            [JsonPropertyName("last_vote_time")] public DateTime LastVoteTime { get; }

            [JsonPropertyName("post_bandwidth")] public NumberOrStringModel PostBandwidth { get; }

            [JsonPropertyName("pending_claimed_accounts")]
            public NumberOrStringModel PendingClaimedAccounts { get; }

            [JsonPropertyName("delayed_votes")] public DelayedVotesModel[] DelayedVotes { get; }
        }
    }
}