using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_transaction
    {
        public class CondenserApiGetTransaction : ICondenserApiCall<string, CondenserApiTransactionModel>
        {
            public CondenserApiGetTransaction(string transactionId)
            {
                QueryParametersJson = new[] {transactionId};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_transaction";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiTransactionModel? ExpectedResponseJson { get; }
        }
    }
}