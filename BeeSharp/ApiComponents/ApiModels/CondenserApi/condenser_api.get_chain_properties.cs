using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_chain_properties
    {
        public class CondenserApiGetChainProperties : ICondenserApiCall<object, CondenserApiChainPropertiesModel>
        {
            public CondenserApiGetChainProperties()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_chain_properties";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiChainPropertiesModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiChainPropertiesModel
        {
            public CondenserApiChainPropertiesModel(string accountCreationFee, NumberOrStringModel maximumBlockSize,
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