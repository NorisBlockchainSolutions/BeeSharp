using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_dynamic_global_properties
    {
        public class
            CondenserApiGetDynamicGlobalProperties : ICondenserApiCall<object, CondenserApiDynamicGlobalPropertiesModel>
        {
            public CondenserApiGetDynamicGlobalProperties()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_dynamic_global_properties";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiDynamicGlobalPropertiesModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiDynamicGlobalPropertiesModel
        {
            public CondenserApiDynamicGlobalPropertiesModel(NumberOrStringModel headBlockNumber, string headBlockId,
                DateTime time, string currentWitness, NumberOrStringModel totalPow, NumberOrStringModel numPowWitnesses,
                string virtualSupply, string currentSupply, string initHbdSupply, string currentHbdSupply,
                string totalVestingFundHive, string totalVestingShares, string totalRewardFundHive,
                string totalRewardShares2, string pendingRewardedVestingShares, string pendingRewardedVestingHive,
                NumberOrStringModel hbdInterestRate, NumberOrStringModel hbdPrintRate,
                NumberOrStringModel maximumBlockSize, NumberOrStringModel requiredActionPartitionPercent,
                NumberOrStringModel currentAslot, string recentSlotsFilled, NumberOrStringModel participationCount,
                NumberOrStringModel lastIrreversibleBlockNum, NumberOrStringModel votePowerReserveRate,
                NumberOrStringModel delegationReturnPeriod, NumberOrStringModel reverseAuctionSeconds,
                NumberOrStringModel availableAccountSubsidies, NumberOrStringModel hbdStopPercent,
                NumberOrStringModel hbdStartPercent, DateTime nextMaintenanceTime, DateTime lastBudgetTime,
                DateTime nextDailyMaintenanceTime, NumberOrStringModel contentRewardPercent,
                NumberOrStringModel vestingRewardPercent, NumberOrStringModel spsFundPercent, string spsIntervalLedger,
                NumberOrStringModel downvotePoolPercent, NumberOrStringModel currentRemoveThreshold)
            {
                HeadBlockNumber = headBlockNumber;
                HeadBlockId = headBlockId;
                Time = time;
                CurrentWitness = currentWitness;
                TotalPow = totalPow;
                NumPowWitnesses = numPowWitnesses;
                VirtualSupply = virtualSupply;
                CurrentSupply = currentSupply;
                InitHbdSupply = initHbdSupply;
                CurrentHbdSupply = currentHbdSupply;
                TotalVestingFundHive = totalVestingFundHive;
                TotalVestingShares = totalVestingShares;
                TotalRewardFundHive = totalRewardFundHive;
                TotalRewardShares2 = totalRewardShares2;
                PendingRewardedVestingShares = pendingRewardedVestingShares;
                PendingRewardedVestingHive = pendingRewardedVestingHive;
                HbdInterestRate = hbdInterestRate;
                HbdPrintRate = hbdPrintRate;
                MaximumBlockSize = maximumBlockSize;
                RequiredActionPartitionPercent = requiredActionPartitionPercent;
                CurrentAslot = currentAslot;
                RecentSlotsFilled = recentSlotsFilled;
                ParticipationCount = participationCount;
                LastIrreversibleBlockNum = lastIrreversibleBlockNum;
                VotePowerReserveRate = votePowerReserveRate;
                DelegationReturnPeriod = delegationReturnPeriod;
                ReverseAuctionSeconds = reverseAuctionSeconds;
                AvailableAccountSubsidies = availableAccountSubsidies;
                HbdStopPercent = hbdStopPercent;
                HbdStartPercent = hbdStartPercent;
                NextMaintenanceTime = nextMaintenanceTime;
                LastBudgetTime = lastBudgetTime;
                NextDailyMaintenanceTime = nextDailyMaintenanceTime;
                ContentRewardPercent = contentRewardPercent;
                VestingRewardPercent = vestingRewardPercent;
                SpsFundPercent = spsFundPercent;
                SpsIntervalLedger = spsIntervalLedger;
                DownvotePoolPercent = downvotePoolPercent;
                CurrentRemoveThreshold = currentRemoveThreshold;
            }

            [JsonPropertyName("head_block_number")]
            public NumberOrStringModel HeadBlockNumber { get; }

            [JsonPropertyName("head_block_id")] public string HeadBlockId { get; }

            [JsonPropertyName("time")] public DateTime Time { get; }

            [JsonPropertyName("current_witness")] public string CurrentWitness { get; }

            [JsonPropertyName("total_pow")] public NumberOrStringModel TotalPow { get; }

            [JsonPropertyName("num_pow_witnesses")]
            public NumberOrStringModel NumPowWitnesses { get; }

            [JsonPropertyName("virtual_supply")] public string VirtualSupply { get; }

            [JsonPropertyName("current_supply")] public string CurrentSupply { get; }

            [JsonPropertyName("init_hbd_supply")] public string InitHbdSupply { get; }

            [JsonPropertyName("current_hbd_supply")]
            public string CurrentHbdSupply { get; }

            [JsonPropertyName("total_vesting_fund_hive")]
            public string TotalVestingFundHive { get; }

            [JsonPropertyName("total_vesting_shares")]
            public string TotalVestingShares { get; }

            [JsonPropertyName("total_reward_fund_hive")]
            public string TotalRewardFundHive { get; }

            [JsonPropertyName("total_reward_shares2")]
            public string TotalRewardShares2 { get; }

            [JsonPropertyName("pending_rewarded_vesting_shares")]
            public string PendingRewardedVestingShares { get; }

            [JsonPropertyName("pending_rewarded_vesting_hive")]
            public string PendingRewardedVestingHive { get; }

            [JsonPropertyName("hbd_interest_rate")]
            public NumberOrStringModel HbdInterestRate { get; }

            [JsonPropertyName("hbd_print_rate")] public NumberOrStringModel HbdPrintRate { get; }

            [JsonPropertyName("maximum_block_size")]
            public NumberOrStringModel MaximumBlockSize { get; }

            [JsonPropertyName("required_actions_partition_percent")]
            public NumberOrStringModel RequiredActionPartitionPercent { get; }

            [JsonPropertyName("current_aslot")] public NumberOrStringModel CurrentAslot { get; }

            [JsonPropertyName("recent_slots_filled")]
            public string RecentSlotsFilled { get; }

            [JsonPropertyName("participation_count")]
            public NumberOrStringModel ParticipationCount { get; }

            [JsonPropertyName("last_irreversible_block_num")]
            public NumberOrStringModel LastIrreversibleBlockNum { get; }

            [JsonPropertyName("vote_power_reserve_rate")]
            public NumberOrStringModel VotePowerReserveRate { get; }

            [JsonPropertyName("delegation_return_period")]
            public NumberOrStringModel DelegationReturnPeriod { get; }

            [JsonPropertyName("reverse_auction_seconds")]
            public NumberOrStringModel ReverseAuctionSeconds { get; }

            [JsonPropertyName("available_account_subsidies")]
            public NumberOrStringModel AvailableAccountSubsidies { get; }

            [JsonPropertyName("hbd_stop_percent")] public NumberOrStringModel HbdStopPercent { get; }

            [JsonPropertyName("hbd_start_percent")]
            public NumberOrStringModel HbdStartPercent { get; }

            [JsonPropertyName("next_maintenance_time")]
            public DateTime NextMaintenanceTime { get; }

            [JsonPropertyName("last_budget_time")] public DateTime LastBudgetTime { get; }

            [JsonPropertyName("next_daily_maintenance_time")]
            public DateTime NextDailyMaintenanceTime { get; }

            [JsonPropertyName("content_reward_percent")]
            public NumberOrStringModel ContentRewardPercent { get; }

            [JsonPropertyName("vesting_reward_percent")]
            public NumberOrStringModel VestingRewardPercent { get; }

            [JsonPropertyName("sps_fund_percent")] public NumberOrStringModel SpsFundPercent { get; }

            [JsonPropertyName("sps_interval_ledger")]
            public string SpsIntervalLedger { get; }

            [JsonPropertyName("downvote_pool_percent")]
            public NumberOrStringModel DownvotePoolPercent { get; }

            [JsonPropertyName("current_remove_threshold")]
            public NumberOrStringModel CurrentRemoveThreshold { get; }
        }
    }
}