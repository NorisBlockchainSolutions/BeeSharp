using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_hardfork_version
    {
        public class CondenserApiGetHardforkVersion : ICondenserApiCall<object, SingleValueResultModel<string>>
        {
            public CondenserApiGetHardforkVersion()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_hardfork_version";

            [JsonPropertyName("expected_response_json")]
            public SingleValueResultModel<string>? ExpectedResponseJson { get; }
        }
    }
}