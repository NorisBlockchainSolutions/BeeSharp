using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_config
    {
        public class CondenserApiGetConfig : ICondenserApiCall<object, CondenserApiConfigModel>
        {
            public CondenserApiGetConfig()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_config";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiConfigModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiConfigModel
        {
            /// <summary>
            ///     This constructor IS ONLY FOR USAGE BY JSONSERIALIZER!
            /// </summary>
            [JsonConstructor]
            [Obsolete("This constructor is ONLY FOR USAGE BY JSONSERIALIZER!", true)]
            public CondenserApiConfigModel()
            {
                // Since the default constructor contains more than 64 elements, it is not supported by System.Net.Json.
            }

            public CondenserApiConfigModel(bool isTestNet, bool enableSmt, HiveSymbolModel hbdSymbol,
                NumberOrStringModel initialVotePowerRate, NumberOrStringModel reducedVotePowerRate,
                NumberOrStringModel hive100Percent, NumberOrStringModel hive1Percent,
                string accountRecoveryRequestExpirationPeriod, string activeChallengeCooldown,
                FeeModelOrStringModel activeChallengeFee, string addressPrefix, string aprPercentMultiplyPerBlock,
                string aprPercentMultiplyPerHour, string aprPercentMultiplyPerRound,
                NumberOrStringModel aprPercentShiftPerBlock, NumberOrStringModel aprPercentShiftPerHour,
                NumberOrStringModel aprPercentShiftPerRound, NumberOrStringModel bandwidthAverageWindowSeconds,
                NumberOrStringModel bandwidthPrecision, NumberOrStringModel beneficiaryLimit,
                NumberOrStringModel blockchainPrecision, NumberOrStringModel blockchainPrecisionDigits,
                string blockchainHardForkVersion, string blockchainVersion, NumberOrStringModel blockInterval,
                NumberOrStringModel blocksPerDay, NumberOrStringModel blocksPerHour, NumberOrStringModel blocksPerYear,
                NumberOrStringModel cashoutWindowSeconds, NumberOrStringModel cashoutWindowSecondsPreHf12,
                NumberOrStringModel cashoutWindowSecondsPreHf17, string hiveChainId, string commentRewardFundName,
                NumberOrStringModel commentTitleLimit, NumberOrStringModel contentAprPercent, string contentConstantHf0,
                string contentConstantHf21, NumberOrStringModel contentRewardPercentHf16,
                NumberOrStringModel contentRewardPercentHf21, string conversionDelay, string conversionDelayPreHf16,
                NumberOrStringModel createAccountDelegationRatio, string createAccountDelegationTime,
                NumberOrStringModel createAccountWithHiveModifier, NumberOrStringModel curateAprPercent,
                NumberOrStringModel customOpDataMaxLength, NumberOrStringModel customOpIdMaxLength,
                NumberOrStringModel defaultHbdInterestRate, NumberOrStringModel downVotePoolPercentHf21,
                NumberOrStringModel equiHashK, NumberOrStringModel equiHashN, NumberOrStringModel feedHistoryWindow,
                NumberOrStringModel feedHistoryWindowPreHf16, NumberOrStringModel feedIntervalBlocks,
                DateTime genesisTime, NumberOrStringModel hardForkRequiredWitnesses,
                string hf21ConvergentLinearRecentClaims, NumberOrStringModel inflationNarrowingPeriod,
                NumberOrStringModel inflationRateStartPercent, NumberOrStringModel inflationRateStopPercent,
                string initMinerName, string initPublicKeyStr, NumberOrStringModel initSupply,
                NumberOrStringModel hbdInitSupply, DateTime initTime, NumberOrStringModel irreversibleThreshold,
                NumberOrStringModel liquidityAprPercent, NumberOrStringModel liquidityRewardBlocks,
                NumberOrStringModel liquidityRewardPeriodSec, string liquidityTimeoutSec,
                NumberOrStringModel maxAccountCreationFee, NumberOrStringModel maxAccountNameLength,
                NumberOrStringModel maxAccountWitnessVotes, NumberOrStringModel maxAssetWhitelistAuthorities,
                NumberOrStringModel maxAuthorityMembership, NumberOrStringModel maxBlockSize,
                NumberOrStringModel softMaxBlockSize, NumberOrStringModel maxCashoutWindowSeconds,
                NumberOrStringModel maxCommentDepth, NumberOrStringModel maxCommentDepthPreHf17,
                NumberOrStringModel maxFeedAgeSeconds, string maxInstanceId, NumberOrStringModel maxMemoSize,
                NumberOrStringModel maxWitnesses, NumberOrStringModel maxMinerWitnessesHf0,
                NumberOrStringModel maxMinerWitnessesHf17, NumberOrStringModel maxPermlinkLength,
                NumberOrStringModel maxProxyRecursionDepth, NumberOrStringModel maxRationDecayRate,
                NumberOrStringModel maxReserveRatio, NumberOrStringModel maxRunnerWitnessesHf0,
                NumberOrStringModel maxRunnerWitnessesHf17, string maxSatoshis, string maxShareSupply,
                NumberOrStringModel maxSigCheckDepth, NumberOrStringModel maxSigCheckAccounts,
                NumberOrStringModel maxTimeUntilExpiration, NumberOrStringModel maxTransactionSize,
                NumberOrStringModel maxUndoHistory, NumberOrStringModel maxUrlLength,
                NumberOrStringModel maxVoteChanges, NumberOrStringModel maxVotedWitnessesHf0,
                NumberOrStringModel maxVotedWitnessesHf17, NumberOrStringModel maxWithdrawRoutes,
                NumberOrStringModel maxPendingTransfers, NumberOrStringModel maxWitnessUrlLength,
                NumberOrStringModel minAccountCreationFee, NumberOrStringModel minAccountNameLength,
                NumberOrStringModel minBlockSizeLimit, NumberOrStringModel minBlockSize,
                FeeModelOrStringModel minContentReward, FeeModelOrStringModel minCurateReward,
                NumberOrStringModel minPermlinkLength, NumberOrStringModel minReplyInterval,
                NumberOrStringModel minReplyIntervalHf20, NumberOrStringModel minRootCommentInterval,
                NumberOrStringModel minCommentEditInterval, NumberOrStringModel minVoteIntervalSec, string minerAccount,
                NumberOrStringModel minerPayPercent, NumberOrStringModel minFeeds, FeeModelOrStringModel miningReward,
                DateTime miningTime, FeeModelOrStringModel minLiquidityReward,
                NumberOrStringModel minLiquidityRewardPeriodSec, FeeModelOrStringModel minPayoutHbd,
                FeeModelOrStringModel minPowReward, FeeModelOrStringModel minProducerReward,
                NumberOrStringModel minTransactionExpirationLimit, NumberOrStringModel minTransactionSizeLimit,
                NumberOrStringModel minUndoHistory, string nullAccount, NumberOrStringModel numInitMiners,
                NumberOrStringModel ownerAuthHistoryTrackingStartBlockNum, string ownerAuthRecoveryPeriod,
                string ownerChallengeCooldown, FeeModelOrStringModel oWnerChallengeFee,
                NumberOrStringModel ownerUpdateLimit, NumberOrStringModel postAverageWindow, string postRewardFundNAme,
                NumberOrStringModel postWeightConstant, NumberOrStringModel powAprPercent,
                NumberOrStringModel producerAprPercent, string proxyToSelfAccount,
                NumberOrStringModel hbdInterestCompoundInternalSec, NumberOrStringModel secondsPerYear,
                NumberOrStringModel proposalFundPercentHf0, NumberOrStringModel proposalFundPercentHf21,
                string recentRSharesDecayTimeHf19, string recentRSharesDecayTimeHf17,
                NumberOrStringModel reverseAuctionWindowSecondsHf6, NumberOrStringModel reverseAuctionWindowSecondsHf20,
                NumberOrStringModel reverseAuctionWindowSecondsHf21, string rootPostParent,
                NumberOrStringModel savingsWithdrawRequestLimit, string savingsWithdrawTime,
                NumberOrStringModel hiveHbdStartPercentHf14, NumberOrStringModel hiveHbdStartPercentHf20,
                NumberOrStringModel hiveHbdStopPercentHf14, NumberOrStringModel hiveHbdStopPercentHf20,
                NumberOrStringModel secondCashoutWindow, NumberOrStringModel softMaxCommentDepth,
                NumberOrStringModel startMinerVotingBlock, NumberOrStringModel startVestingBlock, string tempAccount,
                NumberOrStringModel upvoteLockoutHf7, string upvoteLockoutHf17,
                NumberOrStringModel upvoteLockoutSeconds, NumberOrStringModel vestingFundPercentHf16,
                NumberOrStringModel vestingWithdrawIntervals, NumberOrStringModel vestingWithdrawIntervalsPreHf16,
                NumberOrStringModel vestingWithdrawIntervalSeconds, NumberOrStringModel voteDustThreshold,
                NumberOrStringModel votingManaRegenerationSeconds, HiveSymbolModel hiveSymbol,
                HiveSymbolModel vestsSymbol, string virtualScheduleLapLength, string virtualScheduleLapLength2,
                NumberOrStringModel maxLimitOrderExpiration, NumberOrStringModel delegationReturnPeriodHf0,
                NumberOrStringModel delegationReturnPeriodHf20, NumberOrStringModel rdMinDecayBits,
                NumberOrStringModel rdMaxDecayBits, NumberOrStringModel rdDecayDenomShift,
                NumberOrStringModel rdMaxPoolBits, string rdMaxBudget1, NumberOrStringModel rdMaxBudget2,
                NumberOrStringModel rdMaxBudget3, NumberOrStringModel rdMaxBudget, NumberOrStringModel rdMinDecay,
                NumberOrStringModel rdMinBudget, NumberOrStringModel rdMaxDecay,
                NumberOrStringModel accountSubsidyPrecision, NumberOrStringModel witnessSubsidyBudgetPercent,
                NumberOrStringModel witnessSubsidyDecayPercent, NumberOrStringModel defaultAccountSubsidyDecay,
                NumberOrStringModel defaultAccountSubsidyBudget, NumberOrStringModel decayBackstopPercent,
                NumberOrStringModel blockGenerationPostponedTxLimit,
                NumberOrStringModel pendingTransactionExecutionLimit, string treasuryAccount,
                NumberOrStringModel treasuryFee, NumberOrStringModel proposalMaintenancePeriod,
                NumberOrStringModel proposalMaintenanceCleanup, NumberOrStringModel proposalSubjectMaxLength,
                NumberOrStringModel proposalMaxIdsNumber)
            {
                IsTestNet = isTestNet;
                EnableSmt = enableSmt;
                HbdSymbol = hbdSymbol;
                InitialVotePowerRate = initialVotePowerRate;
                ReducedVotePowerRate = reducedVotePowerRate;
                Hive100Percent = hive100Percent;
                Hive1Percent = hive1Percent;
                AccountRecoveryRequestExpirationPeriod = accountRecoveryRequestExpirationPeriod;
                ActiveChallengeCooldown = activeChallengeCooldown;
                ActiveChallengeFee = activeChallengeFee;
                AddressPrefix = addressPrefix;
                AprPercentMultiplyPerBlock = aprPercentMultiplyPerBlock;
                AprPercentMultiplyPerHour = aprPercentMultiplyPerHour;
                AprPercentMultiplyPerRound = aprPercentMultiplyPerRound;
                AprPercentShiftPerBlock = aprPercentShiftPerBlock;
                AprPercentShiftPerHour = aprPercentShiftPerHour;
                AprPercentShiftPerRound = aprPercentShiftPerRound;
                BandwidthAverageWindowSeconds = bandwidthAverageWindowSeconds;
                BandwidthPrecision = bandwidthPrecision;
                BeneficiaryLimit = beneficiaryLimit;
                BlockchainPrecision = blockchainPrecision;
                BlockchainPrecisionDigits = blockchainPrecisionDigits;
                BlockchainHardForkVersion = blockchainHardForkVersion;
                BlockchainVersion = blockchainVersion;
                BlockInterval = blockInterval;
                BlocksPerDay = blocksPerDay;
                BlocksPerHour = blocksPerHour;
                BlocksPerYear = blocksPerYear;
                CashoutWindowSeconds = cashoutWindowSeconds;
                CashoutWindowSecondsPreHf12 = cashoutWindowSecondsPreHf12;
                CashoutWindowSecondsPreHf17 = cashoutWindowSecondsPreHf17;
                HiveChainId = hiveChainId;
                CommentRewardFundName = commentRewardFundName;
                CommentTitleLimit = commentTitleLimit;
                ContentAprPercent = contentAprPercent;
                ContentConstantHf0 = contentConstantHf0;
                ContentConstantHf21 = contentConstantHf21;
                ContentRewardPercentHf16 = contentRewardPercentHf16;
                ContentRewardPercentHf21 = contentRewardPercentHf21;
                ConversionDelay = conversionDelay;
                ConversionDelayPreHf16 = conversionDelayPreHf16;
                CreateAccountDelegationRatio = createAccountDelegationRatio;
                CreateAccountDelegationTime = createAccountDelegationTime;
                CreateAccountWithHiveModifier = createAccountWithHiveModifier;
                CurateAprPercent = curateAprPercent;
                CustomOpDataMaxLength = customOpDataMaxLength;
                CustomOpIdMaxLength = customOpIdMaxLength;
                DefaultHbdInterestRate = defaultHbdInterestRate;
                DownVotePoolPercentHf21 = downVotePoolPercentHf21;
                EquiHashK = equiHashK;
                EquiHashN = equiHashN;
                FeedHistoryWindow = feedHistoryWindow;
                FeedHistoryWindowPreHf16 = feedHistoryWindowPreHf16;
                FeedIntervalBlocks = feedIntervalBlocks;
                GenesisTime = genesisTime;
                HardForkRequiredWitnesses = hardForkRequiredWitnesses;
                Hf21ConvergentLinearRecentClaims = hf21ConvergentLinearRecentClaims;
                InflationNarrowingPeriod = inflationNarrowingPeriod;
                InflationRateStartPercent = inflationRateStartPercent;
                InflationRateStopPercent = inflationRateStopPercent;
                InitMinerName = initMinerName;
                InitPublicKeyStr = initPublicKeyStr;
                InitSupply = initSupply;
                HbdInitSupply = hbdInitSupply;
                InitTime = initTime;
                IrreversibleThreshold = irreversibleThreshold;
                LiquidityAprPercent = liquidityAprPercent;
                LiquidityRewardBlocks = liquidityRewardBlocks;
                LiquidityRewardPeriodSec = liquidityRewardPeriodSec;
                LiquidityTimeoutSec = liquidityTimeoutSec;
                MaxAccountCreationFee = maxAccountCreationFee;
                MaxAccountNameLength = maxAccountNameLength;
                MaxAccountWitnessVotes = maxAccountWitnessVotes;
                MaxAssetWhitelistAuthorities = maxAssetWhitelistAuthorities;
                MaxAuthorityMembership = maxAuthorityMembership;
                MaxBlockSize = maxBlockSize;
                SoftMaxBlockSize = softMaxBlockSize;
                MaxCashoutWindowSeconds = maxCashoutWindowSeconds;
                MaxCommentDepth = maxCommentDepth;
                MaxCommentDepthPreHf17 = maxCommentDepthPreHf17;
                MaxFeedAgeSeconds = maxFeedAgeSeconds;
                MaxInstanceId = maxInstanceId;
                MaxMemoSize = maxMemoSize;
                MaxWitnesses = maxWitnesses;
                MaxMinerWitnessesHf0 = maxMinerWitnessesHf0;
                MaxMinerWitnessesHf17 = maxMinerWitnessesHf17;
                MaxPermlinkLength = maxPermlinkLength;
                MaxProxyRecursionDepth = maxProxyRecursionDepth;
                MaxRationDecayRate = maxRationDecayRate;
                MaxReserveRatio = maxReserveRatio;
                MaxRunnerWitnessesHf0 = maxRunnerWitnessesHf0;
                MaxRunnerWitnessesHf17 = maxRunnerWitnessesHf17;
                MaxSatoshis = maxSatoshis;
                MaxShareSupply = maxShareSupply;
                MaxSigCheckDepth = maxSigCheckDepth;
                MaxSigCheckAccounts = maxSigCheckAccounts;
                MaxTimeUntilExpiration = maxTimeUntilExpiration;
                MaxTransactionSize = maxTransactionSize;
                MaxUndoHistory = maxUndoHistory;
                MaxUrlLength = maxUrlLength;
                MaxVoteChanges = maxVoteChanges;
                MaxVotedWitnessesHf0 = maxVotedWitnessesHf0;
                MaxVotedWitnessesHf17 = maxVotedWitnessesHf17;
                MaxWithdrawRoutes = maxWithdrawRoutes;
                MaxPendingTransfers = maxPendingTransfers;
                MaxWitnessUrlLength = maxWitnessUrlLength;
                MinAccountCreationFee = minAccountCreationFee;
                MinAccountNameLength = minAccountNameLength;
                MinBlockSizeLimit = minBlockSizeLimit;
                MinBlockSize = minBlockSize;
                MinContentReward = minContentReward;
                MinCurateReward = minCurateReward;
                MinPermlinkLength = minPermlinkLength;
                MinReplyInterval = minReplyInterval;
                MinReplyIntervalHf20 = minReplyIntervalHf20;
                MinRootCommentInterval = minRootCommentInterval;
                MinCommentEditInterval = minCommentEditInterval;
                MinVoteIntervalSec = minVoteIntervalSec;
                MinerAccount = minerAccount;
                MinerPayPercent = minerPayPercent;
                MinFeeds = minFeeds;
                MiningReward = miningReward;
                MiningTime = miningTime;
                MinLiquidityReward = minLiquidityReward;
                MinLiquidityRewardPeriodSec = minLiquidityRewardPeriodSec;
                MinPayoutHbd = minPayoutHbd;
                MinPowReward = minPowReward;
                MinProducerReward = minProducerReward;
                MinTransactionExpirationLimit = minTransactionExpirationLimit;
                MinTransactionSizeLimit = minTransactionSizeLimit;
                MinUndoHistory = minUndoHistory;
                NullAccount = nullAccount;
                NumInitMiners = numInitMiners;
                OwnerAuthHistoryTrackingStartBlockNum = ownerAuthHistoryTrackingStartBlockNum;
                OwnerAuthRecoveryPeriod = ownerAuthRecoveryPeriod;
                OwnerChallengeCooldown = ownerChallengeCooldown;
                OWnerChallengeFee = oWnerChallengeFee;
                OwnerUpdateLimit = ownerUpdateLimit;
                PostAverageWindow = postAverageWindow;
                PostRewardFundNAme = postRewardFundNAme;
                PostWeightConstant = postWeightConstant;
                PowAprPercent = powAprPercent;
                ProducerAprPercent = producerAprPercent;
                ProxyToSelfAccount = proxyToSelfAccount;
                HbdInterestCompoundInternalSec = hbdInterestCompoundInternalSec;
                SecondsPerYear = secondsPerYear;
                ProposalFundPercentHf0 = proposalFundPercentHf0;
                ProposalFundPercentHf21 = proposalFundPercentHf21;
                RecentRSharesDecayTimeHf19 = recentRSharesDecayTimeHf19;
                RecentRSharesDecayTimeHf17 = recentRSharesDecayTimeHf17;
                ReverseAuctionWindowSecondsHf6 = reverseAuctionWindowSecondsHf6;
                ReverseAuctionWindowSecondsHf20 = reverseAuctionWindowSecondsHf20;
                ReverseAuctionWindowSecondsHf21 = reverseAuctionWindowSecondsHf21;
                RootPostParent = rootPostParent;
                SavingsWithdrawRequestLimit = savingsWithdrawRequestLimit;
                SavingsWithdrawTime = savingsWithdrawTime;
                HiveHbdStartPercentHf14 = hiveHbdStartPercentHf14;
                HiveHbdStartPercentHf20 = hiveHbdStartPercentHf20;
                HiveHbdStopPercentHf14 = hiveHbdStopPercentHf14;
                HiveHbdStopPercentHf20 = hiveHbdStopPercentHf20;
                SecondCashoutWindow = secondCashoutWindow;
                SoftMaxCommentDepth = softMaxCommentDepth;
                StartMinerVotingBlock = startMinerVotingBlock;
                StartVestingBlock = startVestingBlock;
                TempAccount = tempAccount;
                UpvoteLockoutHf7 = upvoteLockoutHf7;
                UpvoteLockoutHf17 = upvoteLockoutHf17;
                UpvoteLockoutSeconds = upvoteLockoutSeconds;
                VestingFundPercentHf16 = vestingFundPercentHf16;
                VestingWithdrawIntervals = vestingWithdrawIntervals;
                VestingWithdrawIntervalsPreHf16 = vestingWithdrawIntervalsPreHf16;
                VestingWithdrawIntervalSeconds = vestingWithdrawIntervalSeconds;
                VoteDustThreshold = voteDustThreshold;
                VotingManaRegenerationSeconds = votingManaRegenerationSeconds;
                HiveSymbol = hiveSymbol;
                VestsSymbol = vestsSymbol;
                VirtualScheduleLapLength = virtualScheduleLapLength;
                VirtualScheduleLapLength2 = virtualScheduleLapLength2;
                MaxLimitOrderExpiration = maxLimitOrderExpiration;
                DelegationReturnPeriodHf0 = delegationReturnPeriodHf0;
                DelegationReturnPeriodHf20 = delegationReturnPeriodHf20;
                RdMinDecayBits = rdMinDecayBits;
                RdMaxDecayBits = rdMaxDecayBits;
                RdDecayDenomShift = rdDecayDenomShift;
                RdMaxPoolBits = rdMaxPoolBits;
                RdMaxBudget1 = rdMaxBudget1;
                RdMaxBudget2 = rdMaxBudget2;
                RdMaxBudget3 = rdMaxBudget3;
                RdMaxBudget = rdMaxBudget;
                RdMinDecay = rdMinDecay;
                RdMinBudget = rdMinBudget;
                RdMaxDecay = rdMaxDecay;
                AccountSubsidyPrecision = accountSubsidyPrecision;
                WitnessSubsidyBudgetPercent = witnessSubsidyBudgetPercent;
                WitnessSubsidyDecayPercent = witnessSubsidyDecayPercent;
                DefaultAccountSubsidyDecay = defaultAccountSubsidyDecay;
                DefaultAccountSubsidyBudget = defaultAccountSubsidyBudget;
                DecayBackstopPercent = decayBackstopPercent;
                BlockGenerationPostponedTxLimit = blockGenerationPostponedTxLimit;
                PendingTransactionExecutionLimit = pendingTransactionExecutionLimit;
                TreasuryAccount = treasuryAccount;
                TreasuryFee = treasuryFee;
                ProposalMaintenancePeriod = proposalMaintenancePeriod;
                ProposalMaintenanceCleanup = proposalMaintenanceCleanup;
                ProposalSubjectMaxLength = proposalSubjectMaxLength;
                ProposalMaxIdsNumber = proposalMaxIdsNumber;
            }

            [JsonPropertyName("IS_TEST_NET")] public bool IsTestNet { get; set; }

            [JsonPropertyName("HIVE_ENABLE_SMT")] public bool EnableSmt { get; set; }

            [JsonPropertyName("HBD_SYMBOL")] public HiveSymbolModel HbdSymbol { get; set; }

            [JsonPropertyName("HIVE_INITIAL_VOTE_POWER_RATE")]
            public NumberOrStringModel InitialVotePowerRate { get; set; }

            [JsonPropertyName("HIVE_REDUCED_VOTE_POWER_RATE")]
            public NumberOrStringModel ReducedVotePowerRate { get; set; }

            [JsonPropertyName("HIVE_100_PERCENT")] public NumberOrStringModel Hive100Percent { get; set; }

            [JsonPropertyName("HIVE_1_PERCENT")] public NumberOrStringModel Hive1Percent { get; set; }

            [JsonPropertyName("HIVE_ACCOUNT_RECOVERY_REQUEST_EXPIRATION_PERIOD")]
            public string AccountRecoveryRequestExpirationPeriod { get; set; }

            [JsonPropertyName("HIVE_ACTIVE_CHALLENGE_COOLDOWN")]
            public string ActiveChallengeCooldown { get; set; }

            [JsonPropertyName("HIVE_ACTIVE_CHALLENGE_FEE")]
            public FeeModelOrStringModel ActiveChallengeFee { get; set; }

            [JsonPropertyName("HIVE_ADDRESS_PREFIX")]
            public string AddressPrefix { get; set; }

            [JsonPropertyName("HIVE_APR_PERCENT_MULTIPLY_PER_BLOCK")]
            public string AprPercentMultiplyPerBlock { get; set; }

            [JsonPropertyName("HIVE_APR_PERCENT_MULTIPLY_PER_HOUR")]
            public string AprPercentMultiplyPerHour { get; set; }

            [JsonPropertyName("HIVE_APR_PERCENT_MULTIPLY_PER_ROUND")]
            public string AprPercentMultiplyPerRound { get; set; }

            [JsonPropertyName("HIVE_APR_PERCENT_SHIFT_PER_BLOCK")]
            public NumberOrStringModel AprPercentShiftPerBlock { get; set; }

            [JsonPropertyName("HIVE_APR_PERCENT_SHIFT_PER_HOUR")]
            public NumberOrStringModel AprPercentShiftPerHour { get; set; }

            [JsonPropertyName("HIVE_APR_PERCENT_SHIFT_PER_ROUND")]
            public NumberOrStringModel AprPercentShiftPerRound { get; set; }

            [JsonPropertyName("HIVE_BANDWIDTH_AVERAGE_WINDOW_SECONDS")]
            public NumberOrStringModel BandwidthAverageWindowSeconds { get; set; }

            [JsonPropertyName("HIVE_BANDWIDTH_PRECISION")]
            public NumberOrStringModel BandwidthPrecision { get; set; }

            [JsonPropertyName("HIVE_BENEFICIARY_LIMIT")]
            public NumberOrStringModel BeneficiaryLimit { get; set; }

            [JsonPropertyName("HIVE_BLOCKCHAIN_PRECISION")]
            public NumberOrStringModel BlockchainPrecision { get; set; }

            [JsonPropertyName("HIVE_BLOCKCHAIN_PRECISION_DIGITS")]
            public NumberOrStringModel BlockchainPrecisionDigits { get; set; }

            [JsonPropertyName("HIVE_BLOCKCHAIN_HARDFORK_VERSION")]
            public string BlockchainHardForkVersion { get; set; }

            [JsonPropertyName("HIVE_BLOCKCHAIN_VERSION")]
            public string BlockchainVersion { get; set; }

            [JsonPropertyName("HIVE_BLOCK_INTERVAL")]
            public NumberOrStringModel BlockInterval { get; set; }

            [JsonPropertyName("HIVE_BLOCKS_PER_DAY")]
            public NumberOrStringModel BlocksPerDay { get; set; }

            [JsonPropertyName("HIVE_BLOCKS_PER_HOUR")]
            public NumberOrStringModel BlocksPerHour { get; set; }

            [JsonPropertyName("HIVE_BLOCKS_PER_YEAR")]
            public NumberOrStringModel BlocksPerYear { get; set; }

            [JsonPropertyName("HIVE_CASHOUT_WINDOW_SECONDS")]
            public NumberOrStringModel CashoutWindowSeconds { get; set; }

            [JsonPropertyName("HIVE_CASHOUT_WINDOW_SECONDS_PRE_HF12")]
            public NumberOrStringModel CashoutWindowSecondsPreHf12 { get; set; }

            [JsonPropertyName("HIVE_CASHOUT_WINDOW_SECONDS_PRE_HF17")]
            public NumberOrStringModel CashoutWindowSecondsPreHf17 { get; set; }

            [JsonPropertyName("HIVE_CHAIN_ID")] public string HiveChainId { get; set; }

            [JsonPropertyName("HIVE_COMMENT_REWARD_FUND_NAME")]
            public string CommentRewardFundName { get; set; }

            [JsonPropertyName("HIVE_COMMENT_TITLE_LIMIT")]
            public NumberOrStringModel CommentTitleLimit { get; set; }

            [JsonPropertyName("HIVE_CONTENT_APR_PERCENT")]
            public NumberOrStringModel ContentAprPercent { get; set; }

            [JsonPropertyName("HIVE_CONTENT_CONSTANT_HF0")]
            public string ContentConstantHf0 { get; set; }

            [JsonPropertyName("HIVE_CONTENT_CONSTANT_HF21")]
            public string ContentConstantHf21 { get; set; }

            [JsonPropertyName("HIVE_CONTENT_REWARD_PERCENT_HF16")]
            public NumberOrStringModel ContentRewardPercentHf16 { get; set; }

            [JsonPropertyName("HIVE_CONTENT_REWARD_PERCENT_HF21")]
            public NumberOrStringModel ContentRewardPercentHf21 { get; set; }

            [JsonPropertyName("HIVE_CONVERSION_DELAY")]
            public string ConversionDelay { get; set; }

            [JsonPropertyName("HIVE_CONVERSION_DELAY_PRE_HF_16")]
            public string ConversionDelayPreHf16 { get; set; }

            [JsonPropertyName("HIVE_CREATE_ACCOUNT_DELEGATION_RATIO")]
            public NumberOrStringModel CreateAccountDelegationRatio { get; set; }

            [JsonPropertyName("HIVE_CREATE_ACCOUNT_DELEGATION_TIME")]
            public string CreateAccountDelegationTime { get; set; }

            [JsonPropertyName("HIVE_CREATE_ACCOUNT_WITH_HIVE_MODIFIER")]
            public NumberOrStringModel CreateAccountWithHiveModifier { get; set; }

            [JsonPropertyName("HIVE_CURATE_APR_PERCENT")]
            public NumberOrStringModel CurateAprPercent { get; set; }

            [JsonPropertyName("HIVE_CUSTOM_OP_DATA_MAX_LENGTH")]
            public NumberOrStringModel CustomOpDataMaxLength { get; set; }

            [JsonPropertyName("HIVE_CUSTOM_OP_ID_MAX_LENGTH")]
            public NumberOrStringModel CustomOpIdMaxLength { get; set; }

            [JsonPropertyName("HIVE_DEFAULT_HBD_INTEREST_RATE")]
            public NumberOrStringModel DefaultHbdInterestRate { get; set; }

            [JsonPropertyName("HIVE_DOWNVOTE_POOL_PERCENT_HF21")]
            public NumberOrStringModel DownVotePoolPercentHf21 { get; set; }

            [JsonPropertyName("HIVE_EQUIHASH_K")] public NumberOrStringModel EquiHashK { get; set; }

            [JsonPropertyName("HIVE_EQUIHASH_N")] public NumberOrStringModel EquiHashN { get; set; }

            [JsonPropertyName("HIVE_FEED_HISTORY_WINDOW")]
            public NumberOrStringModel FeedHistoryWindow { get; set; }

            [JsonPropertyName("HIVE_FEED_HISTORY_WINDOW_PRE_HF_16")]
            public NumberOrStringModel FeedHistoryWindowPreHf16 { get; set; }

            [JsonPropertyName("HIVE_FEED_INTERVAL_BLOCKS")]
            public NumberOrStringModel FeedIntervalBlocks { get; set; }

            [JsonPropertyName("HIVE_GENESIS_TIME")]
            public DateTime GenesisTime { get; set; }

            [JsonPropertyName("HIVE_HARDFORK_REQUIRED_WITNESSES")]
            public NumberOrStringModel HardForkRequiredWitnesses { get; set; }

            [JsonPropertyName("HIVE_HF21_CONVERGENT_LINEAR_RECENT_CLAIMS")]
            public string Hf21ConvergentLinearRecentClaims { get; set; }

            [JsonPropertyName("HIVE_INFLATION_NARROWING_PERIOD")]
            public NumberOrStringModel InflationNarrowingPeriod { get; set; }

            [JsonPropertyName("HIVE_INFLATION_RATE_START_PERCENT")]
            public NumberOrStringModel InflationRateStartPercent { get; set; }

            [JsonPropertyName("HIVE_INFLATION_RATE_STOP_PERCENT")]
            public NumberOrStringModel InflationRateStopPercent { get; set; }

            [JsonPropertyName("HIVE_INIT_MINER_NAME")]
            public string InitMinerName { get; set; }

            [JsonPropertyName("HIVE_INIT_PUBLIC_KEY_STR")]
            public string InitPublicKeyStr { get; set; }

            [JsonPropertyName("HIVE_INIT_SUPPLY")] public NumberOrStringModel InitSupply { get; set; }

            [JsonPropertyName("HIVE_HBD_INIT_SUPPLY")]
            public NumberOrStringModel HbdInitSupply { get; set; }

            [JsonPropertyName("HIVE_INIT_TIME")] public DateTime InitTime { get; set; }

            [JsonPropertyName("HIVE_IRREVERSIBLE_THRESHOLD")]
            public NumberOrStringModel IrreversibleThreshold { get; set; }

            [JsonPropertyName("HIVE_LIQUIDITY_APR_PERCENT")]
            public NumberOrStringModel LiquidityAprPercent { get; set; }

            [JsonPropertyName("HIVE_LIQUIDITY_REWARD_BLOCKS")]
            public NumberOrStringModel LiquidityRewardBlocks { get; set; }

            [JsonPropertyName("HIVE_LIQUIDITY_REWARD_PERIOD_SEC")]
            public NumberOrStringModel LiquidityRewardPeriodSec { get; set; }

            [JsonPropertyName("HIVE_LIQUIDITY_TIMEOUT_SEC")]
            public string LiquidityTimeoutSec { get; set; }

            [JsonPropertyName("HIVE_MAX_ACCOUNT_CREATION_FEE")]
            public NumberOrStringModel MaxAccountCreationFee { get; set; }

            [JsonPropertyName("HIVE_MAX_ACCOUNT_NAME_LENGTH")]
            public NumberOrStringModel MaxAccountNameLength { get; set; }

            [JsonPropertyName("HIVE_MAX_ACCOUNT_WITNESS_VOTES")]
            public NumberOrStringModel MaxAccountWitnessVotes { get; set; }

            [JsonPropertyName("HIVE_MAX_ASSET_WHITELIST_AUTHORITIES")]
            public NumberOrStringModel MaxAssetWhitelistAuthorities { get; set; }

            [JsonPropertyName("HIVE_MAX_AUTHORITY_MEMBERSHIP")]
            public NumberOrStringModel MaxAuthorityMembership { get; set; }

            [JsonPropertyName("HIVE_MAX_BLOCK_SIZE")]
            public NumberOrStringModel MaxBlockSize { get; set; }

            [JsonPropertyName("HIVE_SOFT_MAX_BLOCK_SIZE")]
            public NumberOrStringModel SoftMaxBlockSize { get; set; }

            [JsonPropertyName("HIVE_MAX_CASHOUT_WINDOW_SECONDS")]
            public NumberOrStringModel MaxCashoutWindowSeconds { get; set; }

            [JsonPropertyName("HIVE_MAX_COMMENT_DEPTH")]
            public NumberOrStringModel MaxCommentDepth { get; set; }

            [JsonPropertyName("HIVE_MAX_COMMENT_DEPTH_PRE_HF17")]
            public NumberOrStringModel MaxCommentDepthPreHf17 { get; set; }

            [JsonPropertyName("HIVE_MAX_FEED_AGE_SECONDS")]
            public NumberOrStringModel MaxFeedAgeSeconds { get; set; }

            [JsonPropertyName("HIVE_MAX_INSTANCE_ID")]
            public string MaxInstanceId { get; set; }

            [JsonPropertyName("HIVE_MAX_MEMO_SIZE")]
            public NumberOrStringModel MaxMemoSize { get; set; }

            [JsonPropertyName("HIVE_MAX_WITNESSES")]
            public NumberOrStringModel MaxWitnesses { get; set; }

            [JsonPropertyName("HIVE_MAX_MINER_WITNESSES_HF0")]
            public NumberOrStringModel MaxMinerWitnessesHf0 { get; set; }

            [JsonPropertyName("HIVE_MAX_MINER_WITNESSES_HF17")]
            public NumberOrStringModel MaxMinerWitnessesHf17 { get; set; }

            [JsonPropertyName("HIVE_MAX_PERMLINK_LENGTH")]
            public NumberOrStringModel MaxPermlinkLength { get; set; }

            [JsonPropertyName("HIVE_MAX_PROXY_RECURSION_DEPTH")]
            public NumberOrStringModel MaxProxyRecursionDepth { get; set; }

            [JsonPropertyName("HIVE_MAX_RATION_DECAY_RATE")]
            public NumberOrStringModel MaxRationDecayRate { get; set; }

            [JsonPropertyName("HIVE_MAX_RESERVE_RATIO")]
            public NumberOrStringModel MaxReserveRatio { get; set; }

            [JsonPropertyName("HIVE_MAX_RUNNER_WITNESSES_HF0")]
            public NumberOrStringModel MaxRunnerWitnessesHf0 { get; set; }

            [JsonPropertyName("HIVE_MAX_RUNNER_WITNESSES_HF17")]
            public NumberOrStringModel MaxRunnerWitnessesHf17 { get; set; }

            [JsonPropertyName("HIVE_MAX_SATOSHIS")]
            public string MaxSatoshis { get; set; }

            [JsonPropertyName("HIVE_MAX_SHARE_SUPPLY")]
            public string MaxShareSupply { get; set; }

            [JsonPropertyName("HIVE_MAX_SIG_CHECK_DEPTH")]
            public NumberOrStringModel MaxSigCheckDepth { get; set; }

            [JsonPropertyName("HIVE_MAX_SIG_CHECK_ACCOUNTS")]
            public NumberOrStringModel MaxSigCheckAccounts { get; set; }

            [JsonPropertyName("HIVE_MAX_TIME_UNTIL_EXPIRATION")]
            public NumberOrStringModel MaxTimeUntilExpiration { get; set; }

            [JsonPropertyName("HIVE_MAX_TRANSACTION_SIZE")]
            public NumberOrStringModel MaxTransactionSize { get; set; }

            [JsonPropertyName("HIVE_MAX_UNDO_HISTORY")]
            public NumberOrStringModel MaxUndoHistory { get; set; }

            [JsonPropertyName("HIVE_MAX_URL_LENGTH")]
            public NumberOrStringModel MaxUrlLength { get; set; }

            [JsonPropertyName("HIVE_MAX_VOTE_CHANGES")]
            public NumberOrStringModel MaxVoteChanges { get; set; }

            [JsonPropertyName("HIVE_MAX_VOTED_WITNESSES_HF0")]
            public NumberOrStringModel MaxVotedWitnessesHf0 { get; set; }

            [JsonPropertyName("HIVE_MAX_VOTED_WITNESSES_HF17")]
            public NumberOrStringModel MaxVotedWitnessesHf17 { get; set; }

            [JsonPropertyName("HIVE_MAX_WITHDRAW_ROUTES")]
            public NumberOrStringModel MaxWithdrawRoutes { get; set; }

            [JsonPropertyName("HIVE_MAX_PENDING_TRANSFERS")]
            public NumberOrStringModel MaxPendingTransfers { get; set; }

            [JsonPropertyName("HIVE_MAX_WITNESS_URL_LENGTH")]
            public NumberOrStringModel MaxWitnessUrlLength { get; set; }

            [JsonPropertyName("HIVE_MIN_ACCOUNT_CREATION_FEE")]
            public NumberOrStringModel MinAccountCreationFee { get; set; }

            [JsonPropertyName("HIVE_MIN_ACCOUNT_NAME_LENGTH")]
            public NumberOrStringModel MinAccountNameLength { get; set; }

            [JsonPropertyName("HIVE_MIN_BLOCK_SIZE_LIMIT")]
            public NumberOrStringModel MinBlockSizeLimit { get; set; }

            [JsonPropertyName("HIVE_MIN_BLOCK_SIZE")]
            public NumberOrStringModel MinBlockSize { get; set; }

            [JsonPropertyName("HIVE_MIN_CONTENT_REWARD")]
            public FeeModelOrStringModel MinContentReward { get; set; }

            [JsonPropertyName("HIVE_MIN_CURATE_REWARD")]
            public FeeModelOrStringModel MinCurateReward { get; set; }

            [JsonPropertyName("HIVE_MIN_PERMLINK_LENGTH")]
            public NumberOrStringModel MinPermlinkLength { get; set; }

            [JsonPropertyName("HIVE_MIN_REPLY_INTERVAL")]
            public NumberOrStringModel MinReplyInterval { get; set; }

            [JsonPropertyName("HIVE_MIN_REPLY_INTERVAL_HF20")]
            public NumberOrStringModel MinReplyIntervalHf20 { get; set; }

            [JsonPropertyName("HIVE_MIN_ROOT_COMMENT_INTERVAL")]
            public NumberOrStringModel MinRootCommentInterval { get; set; }

            [JsonPropertyName("HIVE_MIN_COMMENT_EDIT_INTERVAL")]
            public NumberOrStringModel MinCommentEditInterval { get; set; }

            [JsonPropertyName("HIVE_MIN_VOTE_INTERVAL_SEC")]
            public NumberOrStringModel MinVoteIntervalSec { get; set; }

            [JsonPropertyName("HIVE_MINER_ACCOUNT")]
            public string MinerAccount { get; set; }

            [JsonPropertyName("HIVE_MINER_PAY_PERCENT")]
            public NumberOrStringModel MinerPayPercent { get; set; }

            [JsonPropertyName("HIVE_MIN_FEEDS")] public NumberOrStringModel MinFeeds { get; set; }

            [JsonPropertyName("HIVE_MINING_REWARD")]
            public FeeModelOrStringModel MiningReward { get; set; }

            [JsonPropertyName("HIVE_MINING_TIME")] public DateTime MiningTime { get; set; }

            [JsonPropertyName("HIVE_MIN_LIQUIDITY_REWARD")]
            public FeeModelOrStringModel MinLiquidityReward { get; set; }

            [JsonPropertyName("HIVE_MIN_LIQUIDITY_REWARD_PERIOD_SEC")]
            public NumberOrStringModel MinLiquidityRewardPeriodSec { get; set; }

            [JsonPropertyName("HIVE_MIN_PAYOUT_HBD")]
            public FeeModelOrStringModel MinPayoutHbd { get; set; }

            [JsonPropertyName("HIVE_MIN_POW_REWARD")]
            public FeeModelOrStringModel MinPowReward { get; set; }

            [JsonPropertyName("HIVE_MIN_PRODUCER_REWARD")]
            public FeeModelOrStringModel MinProducerReward { get; set; }

            [JsonPropertyName("HIVE_MIN_TRANSACTION_EXPIRATION_LIMIT")]
            public NumberOrStringModel MinTransactionExpirationLimit { get; set; }

            [JsonPropertyName("HIVE_MIN_TRANSACTION_SIZE_LIMIT")]
            public NumberOrStringModel MinTransactionSizeLimit { get; set; }

            [JsonPropertyName("HIVE_MIN_UNDO_HISTORY")]
            public NumberOrStringModel MinUndoHistory { get; set; }

            [JsonPropertyName("HIVE_NULL_ACCOUNT")]
            public string NullAccount { get; set; }

            [JsonPropertyName("HIVE_NUM_INIT_MINERS")]
            public NumberOrStringModel NumInitMiners { get; set; }

            [JsonPropertyName("HIVE_OWNER_AUTH_HISTORY_TRACKING_START_BLOCK_NUM")]
            public NumberOrStringModel OwnerAuthHistoryTrackingStartBlockNum { get; set; }

            [JsonPropertyName("HIVE_OWNER_AUTH_RECOVERY_PERIOD")]
            public string OwnerAuthRecoveryPeriod { get; set; }

            [JsonPropertyName("HIVE_OWNER_CHALLENGE_COOLDOWN")]
            public string OwnerChallengeCooldown { get; set; }

            [JsonPropertyName("HIVE_OWNER_CHALLENGE_FEE")]
            public FeeModelOrStringModel OWnerChallengeFee { get; set; }

            [JsonPropertyName("HIVE_OWNER_UPDATE_LIMIT")]
            public NumberOrStringModel OwnerUpdateLimit { get; set; }

            [JsonPropertyName("HIVE_POST_AVERAGE_WINDOW")]
            public NumberOrStringModel PostAverageWindow { get; set; }

            [JsonPropertyName("HIVE_POST_REWARD_FUND_NAME")]
            public string PostRewardFundNAme { get; set; }

            [JsonPropertyName("HIVE_POST_WEIGHT_CONSTANT")]
            public NumberOrStringModel PostWeightConstant { get; set; }

            [JsonPropertyName("HIVE_POW_APR_PERCENT")]
            public NumberOrStringModel PowAprPercent { get; set; }

            [JsonPropertyName("HIVE_PRODUCER_APR_PERCENT")]
            public NumberOrStringModel ProducerAprPercent { get; set; }

            [JsonPropertyName("HIVE_PROXY_TO_SELF_ACCOUNT")]
            public string ProxyToSelfAccount { get; set; }

            [JsonPropertyName("HIVE_HBD_INTEREST_COMPOUND_INTERVAL_SEC")]
            public NumberOrStringModel HbdInterestCompoundInternalSec { get; set; }

            [JsonPropertyName("HIVE_SECONDS_PER_YEAR")]
            public NumberOrStringModel SecondsPerYear { get; set; }

            [JsonPropertyName("HIVE_PROPOSAL_FUND_PERCENT_HF0")]
            public NumberOrStringModel ProposalFundPercentHf0 { get; set; }

            [JsonPropertyName("HIVE_PROPOSAL_FUND_PERCENT_HF21")]
            public NumberOrStringModel ProposalFundPercentHf21 { get; set; }

            [JsonPropertyName("HIVE_RECENT_RSHARES_DECAY_TIME_HF19")]
            public string RecentRSharesDecayTimeHf19 { get; set; }

            [JsonPropertyName("HIVE_RECENT_RSHARES_DECAY_TIME_HF17")]
            public string RecentRSharesDecayTimeHf17 { get; set; }

            [JsonPropertyName("HIVE_REVERSE_AUCTION_WINDOW_SECONDS_HF6")]
            public NumberOrStringModel ReverseAuctionWindowSecondsHf6 { get; set; }

            [JsonPropertyName("HIVE_REVERSE_AUCTION_WINDOW_SECONDS_HF20")]
            public NumberOrStringModel ReverseAuctionWindowSecondsHf20 { get; set; }

            [JsonPropertyName("HIVE_REVERSE_AUCTION_WINDOW_SECONDS_HF21")]
            public NumberOrStringModel ReverseAuctionWindowSecondsHf21 { get; set; }

            [JsonPropertyName("HIVE_ROOT_POST_PARENT")]
            public string RootPostParent { get; set; }

            [JsonPropertyName("HIVE_SAVINGS_WITHDRAW_REQUEST_LIMIT")]
            public NumberOrStringModel SavingsWithdrawRequestLimit { get; set; }

            [JsonPropertyName("HIVE_SAVINGS_WITHDRAW_TIME")]
            public string SavingsWithdrawTime { get; set; }

            [JsonPropertyName("HIVE_HBD_START_PERCENT_HF14")]
            public NumberOrStringModel HiveHbdStartPercentHf14 { get; set; }

            [JsonPropertyName("HIVE_HBD_START_PERCENT_HF20")]
            public NumberOrStringModel HiveHbdStartPercentHf20 { get; set; }

            [JsonPropertyName("HIVE_HBD_STOP_PERCENT_HF14")]
            public NumberOrStringModel HiveHbdStopPercentHf14 { get; set; }

            [JsonPropertyName("HIVE_HBD_STOP_PERCENT_HF20")]
            public NumberOrStringModel HiveHbdStopPercentHf20 { get; set; }

            [JsonPropertyName("HIVE_SECOND_CASHOUT_WINDOW")]
            public NumberOrStringModel SecondCashoutWindow { get; set; }

            [JsonPropertyName("HIVE_SOFT_MAX_COMMENT_DEPTH")]
            public NumberOrStringModel SoftMaxCommentDepth { get; set; }

            [JsonPropertyName("HIVE_START_MINER_VOTING_BLOCK")]
            public NumberOrStringModel StartMinerVotingBlock { get; set; }

            [JsonPropertyName("HIVE_START_VESTING_BLOCK")]
            public NumberOrStringModel StartVestingBlock { get; set; }

            [JsonPropertyName("HIVE_TEMP_ACCOUNT")]
            public string TempAccount { get; set; }

            [JsonPropertyName("HIVE_UPVOTE_LOCKOUT_HF7")]
            public NumberOrStringModel UpvoteLockoutHf7 { get; set; }

            [JsonPropertyName("HIVE_UPVOTE_LOCKOUT_HF17")]
            public string UpvoteLockoutHf17 { get; set; }

            [JsonPropertyName("HIVE_UPVOTE_LOCKOUT_SECONDS")]
            public NumberOrStringModel UpvoteLockoutSeconds { get; set; }

            [JsonPropertyName("HIVE_VESTING_FUND_PERCENT_HF16")]
            public NumberOrStringModel VestingFundPercentHf16 { get; set; }

            [JsonPropertyName("HIVE_VESTING_WITHDRAW_INTERVALS")]
            public NumberOrStringModel VestingWithdrawIntervals { get; set; }

            [JsonPropertyName("HIVE_VESTING_WITHDRAW_INTERVALS_PRE_HF_16")]
            public NumberOrStringModel VestingWithdrawIntervalsPreHf16 { get; set; }

            [JsonPropertyName("HIVE_VESTING_WITHDRAW_INTERVAL_SECONDS")]
            public NumberOrStringModel VestingWithdrawIntervalSeconds { get; set; }

            [JsonPropertyName("HIVE_VOTE_DUST_THRESHOLD")]
            public NumberOrStringModel VoteDustThreshold { get; set; }

            [JsonPropertyName("HIVE_VOTING_MANA_REGENERATION_SECONDS")]
            public NumberOrStringModel VotingManaRegenerationSeconds { get; set; }

            [JsonPropertyName("HIVE_SYMBOL")] public HiveSymbolModel HiveSymbol { get; set; }

            [JsonPropertyName("VESTS_SYMBOL")] public HiveSymbolModel VestsSymbol { get; set; }

            [JsonPropertyName("HIVE_VIRTUAL_SCHEDULE_LAP_LENGTH")]
            public string VirtualScheduleLapLength { get; set; }

            [JsonPropertyName("HIVE_VIRTUAL_SCHEDULE_LAP_LENGTH2")]
            public string VirtualScheduleLapLength2 { get; set; }

            [JsonPropertyName("HIVE_MAX_LIMIT_ORDER_EXPIRATION")]
            public NumberOrStringModel MaxLimitOrderExpiration { get; set; }

            [JsonPropertyName("HIVE_DELEGATION_RETURN_PERIOD_HF0")]
            public NumberOrStringModel DelegationReturnPeriodHf0 { get; set; }

            [JsonPropertyName("HIVE_DELEGATION_RETURN_PERIOD_HF20")]
            public NumberOrStringModel DelegationReturnPeriodHf20 { get; set; }

            [JsonPropertyName("HIVE_RD_MIN_DECAY_BITS")]
            public NumberOrStringModel RdMinDecayBits { get; set; }

            [JsonPropertyName("HIVE_RD_MAX_DECAY_BITS")]
            public NumberOrStringModel RdMaxDecayBits { get; set; }

            [JsonPropertyName("HIVE_RD_DECAY_DENOM_SHIFT")]
            public NumberOrStringModel RdDecayDenomShift { get; set; }

            [JsonPropertyName("HIVE_RD_MAX_POOL_BITS")]
            public NumberOrStringModel RdMaxPoolBits { get; set; }

            [JsonPropertyName("HIVE_RD_MAX_BUDGET_1")]
            public string RdMaxBudget1 { get; set; }

            [JsonPropertyName("HIVE_RD_MAX_BUDGET_2")]
            public NumberOrStringModel RdMaxBudget2 { get; set; }

            [JsonPropertyName("HIVE_RD_MAX_BUDGET_3")]
            public NumberOrStringModel RdMaxBudget3 { get; set; }

            [JsonPropertyName("HIVE_RD_MAX_BUDGET")]
            public NumberOrStringModel RdMaxBudget { get; set; }

            [JsonPropertyName("HIVE_RD_MIN_DECAY")]
            public NumberOrStringModel RdMinDecay { get; set; }

            [JsonPropertyName("HIVE_RD_MIN_BUDGET")]
            public NumberOrStringModel RdMinBudget { get; set; }

            [JsonPropertyName("HIVE_RD_MAX_DECAY")]
            public NumberOrStringModel RdMaxDecay { get; set; }

            [JsonPropertyName("HIVE_ACCOUNT_SUBSIDY_PRECISION")]
            public NumberOrStringModel AccountSubsidyPrecision { get; set; }

            [JsonPropertyName("HIVE_WITNESS_SUBSIDY_BUDGET_PERCENT")]
            public NumberOrStringModel WitnessSubsidyBudgetPercent { get; set; }

            [JsonPropertyName("HIVE_WITNESS_SUBSIDY_DECAY_PERCENT")]
            public NumberOrStringModel WitnessSubsidyDecayPercent { get; set; }

            [JsonPropertyName("HIVE_DEFAULT_ACCOUNT_SUBSIDY_DECAY")]
            public NumberOrStringModel DefaultAccountSubsidyDecay { get; set; }

            [JsonPropertyName("HIVE_DEFAULT_ACCOUNT_SUBSIDY_BUDGET")]
            public NumberOrStringModel DefaultAccountSubsidyBudget { get; set; }

            [JsonPropertyName("HIVE_DECAY_BACKSTOP_PERCENT")]
            public NumberOrStringModel DecayBackstopPercent { get; set; }

            [JsonPropertyName("HIVE_BLOCK_GENERATION_POSTPONED_TX_LIMIT")]
            public NumberOrStringModel BlockGenerationPostponedTxLimit { get; set; }

            [JsonPropertyName("HIVE_PENDING_TRANSACTION_EXECUTION_LIMIT")]
            public NumberOrStringModel PendingTransactionExecutionLimit { get; set; }

            [JsonPropertyName("HIVE_TREASURY_ACCOUNT")]
            public string TreasuryAccount { get; set; }

            [JsonPropertyName("HIVE_TREASURY_FEE")]
            public NumberOrStringModel TreasuryFee { get; set; }

            [JsonPropertyName("HIVE_PROPOSAL_MAINTENANCE_PERIOD")]
            public NumberOrStringModel ProposalMaintenancePeriod { get; set; }

            [JsonPropertyName("HIVE_PROPOSAL_MAINTENANCE_CLEANUP")]
            public NumberOrStringModel ProposalMaintenanceCleanup { get; set; }

            [JsonPropertyName("HIVE_PROPOSAL_SUBJECT_MAX_LENGTH")]
            public NumberOrStringModel ProposalSubjectMaxLength { get; set; }

            [JsonPropertyName("HIVE_PROPOSAL_MAX_IDS_NUMBER")]
            public NumberOrStringModel ProposalMaxIdsNumber { get; set; }
        }

        public class HiveSymbolModel
        {
            public HiveSymbolModel(string nai, NumberOrStringModel decimals)
            {
                Nai = nai;
                Decimals = decimals;
            }

            [JsonPropertyName("nai")] public string Nai { get; }

            [JsonPropertyName("decimals")] public NumberOrStringModel Decimals { get; }
        }
    }
}