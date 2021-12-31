using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_witness_by_account;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_witnesses
    {
        public class CondenserApiGetWitnesses : ICondenserApiCall<long[], List<CondenserApiWitnessInfoModel>>
        {
            public CondenserApiGetWitnesses(long[] witnessIds)
            {
                QueryParametersJson = new[] {witnessIds};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public long[][] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_witnesses";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiWitnessInfoModel>? ExpectedResponseJson { get; }
        }
    }
}