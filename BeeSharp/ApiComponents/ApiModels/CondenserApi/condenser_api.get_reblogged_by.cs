using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_reblogged_by
    {
        public class CondenserApiGetRebloggedBy : ICondenserApiCall<string, List<string>>
        {
            public CondenserApiGetRebloggedBy(string author, string permLink)
            {
                QueryParametersJson = new[] {author, permLink};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_reblogged_by";

            [JsonPropertyName("expected_response_json")]
            public List<string>? ExpectedResponseJson { get; }
        }
    }
}