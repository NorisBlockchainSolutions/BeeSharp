using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_replies_by_last_update
    {
        public class CondenserApiGetRepliesByLastUpdate : ICondenserApiCall<object, List<object>>
        {
            public CondenserApiGetRepliesByLastUpdate(string startParentAuthor, string startPermLink,
                [Range(-1, 100)] int limit)
            {
                QueryParametersJson = new[] {startParentAuthor, startPermLink, (object) limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_replies_by_last_update";

            [JsonPropertyName("expected_response_json")]
            public List<object>? ExpectedResponseJson { get; }
        }
    }
}