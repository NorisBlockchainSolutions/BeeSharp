using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_savings_withdraw_from
    {
        public class CondenserApiGetSavingsWithdrawFrom : ICondenserApiCall<string, List<object>>
        {
            public CondenserApiGetSavingsWithdrawFrom(string account)
            {
                QueryParametersJson = new[] {account};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_savings_withdraw_from";

            [JsonPropertyName("expected_response_json")]
            public List<object>? ExpectedResponseJson { get; }
        }
    }
}