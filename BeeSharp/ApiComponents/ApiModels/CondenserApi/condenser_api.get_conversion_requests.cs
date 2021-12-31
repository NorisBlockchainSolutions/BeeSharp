using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_conversion_requests
    {
        public class CondenserApiGetConversionRequests : ICondenserApiCall<long, List<object>>
        {
            public CondenserApiGetConversionRequests(long id)
            {
                QueryParametersJson = new[] {id};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public long[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_conversion_requests";

            [JsonPropertyName("expected_response_json")]
            public List<object>? ExpectedResponseJson { get; }
        }
    }
}