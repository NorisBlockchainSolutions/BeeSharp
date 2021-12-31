using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_owner_history
    {
        public class CondenserApiGetOwnerHistory : ICondenserApiCall<string, List<object>>
        {
            public CondenserApiGetOwnerHistory(string account)
            {
                QueryParametersJson = new[] {account};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_owner_history";

            [JsonPropertyName("expected_response_json")]
            public List<object>? ExpectedResponseJson { get; }
        }
    }
}