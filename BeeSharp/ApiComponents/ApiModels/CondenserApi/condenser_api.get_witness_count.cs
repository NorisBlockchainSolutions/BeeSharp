using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_witness_count
    {
        public class CondenserApiGetWitnessCount : ICondenserApiCall<object, NumberOrStringModel>
        {
            public CondenserApiGetWitnessCount()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_witness_count";

            [JsonPropertyName("expected_response_json")]
            public NumberOrStringModel? ExpectedResponseJson { get; }
        }
    }
}