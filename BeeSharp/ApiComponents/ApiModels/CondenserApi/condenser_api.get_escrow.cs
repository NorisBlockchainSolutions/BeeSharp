using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_escrow
    {
        public class CondenserApiGetEscrow : ICondenserApiCall<object, CondenserApiEscrowModel>
        {
            public CondenserApiGetEscrow(string account, long escrowId)
            {
                QueryParametersJson = new[] {account, (object) escrowId};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_escrow";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiEscrowModel? ExpectedResponseJson { get; }
        }
    }
}