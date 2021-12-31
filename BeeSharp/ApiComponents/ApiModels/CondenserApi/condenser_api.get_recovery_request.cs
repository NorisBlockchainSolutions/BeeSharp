using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_recovery_request
    {
        public class CondenserApiGetRecoveryRequest : ICondenserApiCall<string, object>
        {
            public CondenserApiGetRecoveryRequest(string account)
            {
                QueryParametersJson = new[] {account};
                ExpectedResponseJson = null!;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_recovery_request";

            [JsonPropertyName("expected_response_json")]
            public object? ExpectedResponseJson { get; }
        }
    }
}