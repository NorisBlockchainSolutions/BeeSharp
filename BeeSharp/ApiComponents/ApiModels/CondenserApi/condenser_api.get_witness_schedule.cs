using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_witness_by_account;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_witness_schedule
    {
        public class CondenserApiGetWitnessSchedule : ICondenserApiCall<object, CondenserApiWitnessScheduleModel>
        {
            public CondenserApiGetWitnessSchedule()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_witness_schedule";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiWitnessScheduleModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiWitnessScheduleModel
        {
            public CondenserApiWitnessScheduleModel(NumberOrStringModel id, string currentVirtualTime,
                NumberOrStringModel nextShuffleBlockNum, string[] currentShuffledWitnesses,
                NumberOrStringModel numScheduledWitnesses, NumberOrStringModel electedWeight,
                NumberOrStringModel timeshareWeight, NumberOrStringModel minerWeight,
                NumberOrStringModel witnessPayNormalizationFactor, CondenserApiWitnessPropertiesModel medianProps,
                string majorityVersion, NumberOrStringModel maxVotedWitnesses, NumberOrStringModel maxMinerWitnesses,
                NumberOrStringModel maxRunnerWitnesses, NumberOrStringModel hardforkRequiredWitnesses,
                CondenserApiAccountSubsidyRdModel condenserApiAccountSubsidyRd,
                CondenserApiAccountSubsidyRdModel condenserApiAccountSubsidyWitnessRd,
                NumberOrStringModel minWitnessAccountSubsidyDecay)
            {
                Id = id;
                CurrentVirtualTime = currentVirtualTime;
                NextShuffleBlockNum = nextShuffleBlockNum;
                CurrentShuffledWitnesses = currentShuffledWitnesses;
                NumScheduledWitnesses = numScheduledWitnesses;
                ElectedWeight = electedWeight;
                TimeshareWeight = timeshareWeight;
                MinerWeight = minerWeight;
                WitnessPayNormalizationFactor = witnessPayNormalizationFactor;
                MedianProps = medianProps;
                MajorityVersion = majorityVersion;
                MaxVotedWitnesses = maxVotedWitnesses;
                MaxMinerWitnesses = maxMinerWitnesses;
                MaxRunnerWitnesses = maxRunnerWitnesses;
                HardforkRequiredWitnesses = hardforkRequiredWitnesses;
                CondenserApiAccountSubsidyRd = condenserApiAccountSubsidyRd;
                CondenserApiAccountSubsidyWitnessRd = condenserApiAccountSubsidyWitnessRd;
                MinWitnessAccountSubsidyDecay = minWitnessAccountSubsidyDecay;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("current_virtual_time")]
            public string CurrentVirtualTime { get; }

            [JsonPropertyName("next_shuffle_block_num")]
            public NumberOrStringModel NextShuffleBlockNum { get; }

            [JsonPropertyName("current_shuffled_witnesses")]
            public string[] CurrentShuffledWitnesses { get; }

            [JsonPropertyName("num_scheduled_witnesses")]
            public NumberOrStringModel NumScheduledWitnesses { get; }

            [JsonPropertyName("elected_weight")] public NumberOrStringModel ElectedWeight { get; }

            [JsonPropertyName("timeshare_weight")] public NumberOrStringModel TimeshareWeight { get; }

            [JsonPropertyName("miner_weight")] public NumberOrStringModel MinerWeight { get; }

            [JsonPropertyName("witness_pay_normalization_factor")]
            public NumberOrStringModel WitnessPayNormalizationFactor { get; }

            [JsonPropertyName("median_props")] public CondenserApiWitnessPropertiesModel MedianProps { get; }

            [JsonPropertyName("majority_version")] public string MajorityVersion { get; }

            [JsonPropertyName("max_voted_witnesses")]
            public NumberOrStringModel MaxVotedWitnesses { get; }

            [JsonPropertyName("max_miner_witnesses")]
            public NumberOrStringModel MaxMinerWitnesses { get; }

            [JsonPropertyName("max_runner_witnesses")]
            public NumberOrStringModel MaxRunnerWitnesses { get; }

            [JsonPropertyName("hardfork_required_witnesses")]
            public NumberOrStringModel HardforkRequiredWitnesses { get; }

            [JsonPropertyName("account_subsidy_rd")]
            public CondenserApiAccountSubsidyRdModel CondenserApiAccountSubsidyRd { get; }

            [JsonPropertyName("account_subsidy_witness_rd")]
            public CondenserApiAccountSubsidyRdModel CondenserApiAccountSubsidyWitnessRd { get; }

            [JsonPropertyName("min_witness_account_subsidy_decay")]
            public NumberOrStringModel MinWitnessAccountSubsidyDecay { get; }
        }

        public class CondenserApiAccountSubsidyRdModel
        {
            public CondenserApiAccountSubsidyRdModel(NumberOrStringModel resourceUnit,
                NumberOrStringModel budgetPerTimeUnit,
                NumberOrStringModel poolEq, NumberOrStringModel maxPoolSize, CondenserApiDecayParamsModel decayParams,
                NumberOrStringModel minDecay)
            {
                ResourceUnit = resourceUnit;
                BudgetPerTimeUnit = budgetPerTimeUnit;
                PoolEq = poolEq;
                MaxPoolSize = maxPoolSize;
                DecayParams = decayParams;
                MinDecay = minDecay;
            }

            [JsonPropertyName("resource_unit")] public NumberOrStringModel ResourceUnit { get; }

            [JsonPropertyName("budget_per_time_unit")]
            public NumberOrStringModel BudgetPerTimeUnit { get; }

            [JsonPropertyName("pool_eq")] public NumberOrStringModel PoolEq { get; }

            [JsonPropertyName("max_pool_size")] public NumberOrStringModel MaxPoolSize { get; }

            [JsonPropertyName("decay_params")] public CondenserApiDecayParamsModel DecayParams { get; }

            [JsonPropertyName("min_decay")] public NumberOrStringModel MinDecay { get; }
        }

        public class CondenserApiDecayParamsModel
        {
            public CondenserApiDecayParamsModel(NumberOrStringModel decayPerTimeUnit,
                NumberOrStringModel decayPerTimeUnitDenomShift)
            {
                DecayPerTimeUnit = decayPerTimeUnit;
                DecayPerTimeUnitDenomShift = decayPerTimeUnitDenomShift;
            }

            [JsonPropertyName("decay_per_time_unit")]
            public NumberOrStringModel DecayPerTimeUnit { get; }

            [JsonPropertyName("decay_per_time_unit_denom_shift")]
            public NumberOrStringModel DecayPerTimeUnitDenomShift { get; }
        }
    }
}