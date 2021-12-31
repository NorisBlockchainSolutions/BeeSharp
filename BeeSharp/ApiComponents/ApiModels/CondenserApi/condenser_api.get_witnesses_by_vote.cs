using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_witness_by_account;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_witnesses_by_vote
    {
        public class CondenserApiGetWitnessesByVote : ICondenserApiCall<object, List<CondenserApiWitnessInfoModel>>
        {
            public CondenserApiGetWitnessesByVote(string? account, [Range(-1, 1000)] int limit)
            {
                QueryParametersJson = new[] {account!, (object) limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_witnesses_by_vote";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiWitnessInfoModel>? ExpectedResponseJson { get; }
        }
    }
}