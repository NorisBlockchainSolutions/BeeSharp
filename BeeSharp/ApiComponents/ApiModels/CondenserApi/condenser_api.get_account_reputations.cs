using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_account_reputations
    {
        public class
            CondenserApiGetAccountReputations : ICondenserApiCall<object, List<CondenserApiAccountReputationModel>>
        {
            public CondenserApiGetAccountReputations(string accountStartsWith, long results)
            {
                QueryParametersJson = new[]
                {
                    (object) accountStartsWith,
                    results
                };

                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_account_reputations";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiAccountReputationModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiAccountReputationModel
        {
            public CondenserApiAccountReputationModel(string account, NumberOrStringModel reputation)
            {
                Account = account;
                Reputation = reputation;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("reputation")] public NumberOrStringModel Reputation { get; }
        }
    }
}