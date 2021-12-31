using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_active_witnesses
    {
        public class CondenserApiGetActiveWitnesses : ICondenserApiCall<object, List<string>>
        {
            public CondenserApiGetActiveWitnesses()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_active_witnesses";

            [JsonPropertyName("expected_response_json")]
            public List<string>? ExpectedResponseJson { get; }
        }
    }
}