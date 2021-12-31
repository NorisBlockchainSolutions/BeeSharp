using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_key_references
    {
        public class CondenserApiGetKeyReferences : ICondenserApiCall<string[], List<string[]>>
        {
            public CondenserApiGetKeyReferences(string accountKey)
            {
                QueryParametersJson = new[] {new[] {accountKey}};
                ExpectedResponseJson = new List<string[]>();
            }

            [JsonPropertyName("query_parameters_json")]
            public string[][] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_key_references";

            [JsonPropertyName("expected_response_json")]
            public List<string[]> ExpectedResponseJson { get; }
        }
    }
}