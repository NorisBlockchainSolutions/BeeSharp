using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace lookup_accounts
    {
        public class CondenserApiLookupAccounts : ICondenserApiCall<object, List<string>>
        {
            public CondenserApiLookupAccounts(string accountStartsWith, [Range(-1, 1000)] short limit)
            {
                QueryParametersJson = new[] {accountStartsWith, (object) limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.lookup_accounts";

            [JsonPropertyName("expected_response_json")]
            public List<string>? ExpectedResponseJson { get; }
        }
    }
}