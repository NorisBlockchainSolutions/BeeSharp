using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_content_replies
    {
        public class CondenserApiGetContentReplies : ICondenserApiCall<string, List<CondenserApiContentModel>>
        {
            public CondenserApiGetContentReplies(string author, string permLink)
            {
                QueryParametersJson = new[] {author, permLink};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_content_replies";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiContentModel>? ExpectedResponseJson { get; }
        }
    }
}