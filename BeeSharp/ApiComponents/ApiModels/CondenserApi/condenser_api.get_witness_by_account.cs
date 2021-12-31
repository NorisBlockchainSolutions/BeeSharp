using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_witness_by_account
    {
        public class CondenserApiGetWitnessByAccount : ICondenserApiCall<string, CondenserApiWitnessInfoModel>
        {
            public CondenserApiGetWitnessByAccount(string account)
            {
                QueryParametersJson = new[] {account};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_witness_by_account";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiWitnessInfoModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiWitnessInfoModel
        {
            public CondenserApiWitnessInfoModel(NumberOrStringModel id, string owner, DateTime created, string url,
                NumberOrStringModel votes, string virtualLastUpdate, string virtualPosition,
                string virtualScheduledTime, NumberOrStringModel totalMissed, NumberOrStringModel lastAslot,
                NumberOrStringModel lastConfirmedBlockNum, NumberOrStringModel powWorker, string signingKey,
                CondenserApiWitnessPropertiesModel props, ExchangeRateModel hbdExchangeRate,
                DateTime lastHbdExchangeUpdate, string lastWork, string runningVersion, string hardforkVersionVote,
                DateTime hardforkTimeVote, NumberOrStringModel availableWitnessAccountSubsidies)
            {
                Id = id;
                Owner = owner;
                Created = created;
                Url = url;
                Votes = votes;
                VirtualLastUpdate = virtualLastUpdate;
                VirtualPosition = virtualPosition;
                VirtualScheduledTime = virtualScheduledTime;
                TotalMissed = totalMissed;
                LastAslot = lastAslot;
                LastConfirmedBlockNum = lastConfirmedBlockNum;
                PowWorker = powWorker;
                SigningKey = signingKey;
                Props = props;
                HbdExchangeRate = hbdExchangeRate;
                LastHbdExchangeUpdate = lastHbdExchangeUpdate;
                LastWork = lastWork;
                RunningVersion = runningVersion;
                HardforkVersionVote = hardforkVersionVote;
                HardforkTimeVote = hardforkTimeVote;
                AvailableWitnessAccountSubsidies = availableWitnessAccountSubsidies;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("owner")] public string Owner { get; }

            [JsonPropertyName("created")] public DateTime Created { get; }

            [JsonPropertyName("url")] public string Url { get; }

            [JsonPropertyName("votes")] public NumberOrStringModel Votes { get; }

            [JsonPropertyName("virtual_last_update")]
            public string VirtualLastUpdate { get; }

            [JsonPropertyName("virtual_position")] public string VirtualPosition { get; }

            [JsonPropertyName("virtual_scheduled_time")]
            public string VirtualScheduledTime { get; }

            [JsonPropertyName("total_missed")] public NumberOrStringModel TotalMissed { get; }

            [JsonPropertyName("last_aslot")] public NumberOrStringModel LastAslot { get; }

            [JsonPropertyName("last_confirmed_block_num")]
            public NumberOrStringModel LastConfirmedBlockNum { get; }

            [JsonPropertyName("pow_worker")] public NumberOrStringModel PowWorker { get; }

            [JsonPropertyName("signing_key")] public string SigningKey { get; }

            [JsonPropertyName("props")] public CondenserApiWitnessPropertiesModel Props { get; }

            [JsonPropertyName("hbd_exchange_rate")]
            public ExchangeRateModel HbdExchangeRate { get; }

            [JsonPropertyName("last_hbd_exchange_update")]
            public DateTime LastHbdExchangeUpdate { get; }

            [JsonPropertyName("last_work")] public string LastWork { get; }

            [JsonPropertyName("running_version")] public string RunningVersion { get; }

            [JsonPropertyName("hardfork_version_vote")]
            public string HardforkVersionVote { get; }

            [JsonPropertyName("hardfork_time_vote")]
            public DateTime HardforkTimeVote { get; }

            [JsonPropertyName("available_witness_account_subsidies")]
            public NumberOrStringModel AvailableWitnessAccountSubsidies { get; }
        }

        public class CondenserApiWitnessPropertiesModel
        {
            public CondenserApiWitnessPropertiesModel(string accountCreationFee, NumberOrStringModel maximumBlockSize,
                NumberOrStringModel hbdInterestRate, NumberOrStringModel accountSubsidyBudget,
                NumberOrStringModel accountSubsidyDecay)
            {
                AccountCreationFee = accountCreationFee;
                MaximumBlockSize = maximumBlockSize;
                HbdInterestRate = hbdInterestRate;
                AccountSubsidyBudget = accountSubsidyBudget;
                AccountSubsidyDecay = accountSubsidyDecay;
            }

            [JsonPropertyName("account_creation_fee")]
            public string AccountCreationFee { get; }

            [JsonPropertyName("maximum_block_size")]
            public NumberOrStringModel MaximumBlockSize { get; }

            [JsonPropertyName("hbd_interest_rate")]
            public NumberOrStringModel HbdInterestRate { get; }

            [JsonPropertyName("account_subsidy_budget")]
            public NumberOrStringModel AccountSubsidyBudget { get; }

            [JsonPropertyName("account_subsidy_decay")]
            public NumberOrStringModel AccountSubsidyDecay { get; }
        }
    }
}