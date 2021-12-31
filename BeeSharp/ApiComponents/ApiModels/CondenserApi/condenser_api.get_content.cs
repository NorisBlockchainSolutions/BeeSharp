using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_content
    {
        public class CondenserApiGetContent : ICondenserApiCall<string, CondenserApiContentModel>
        {
            public CondenserApiGetContent(string author, string permLink)
            {
                QueryParametersJson = new[] {author, permLink};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_content";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiContentModel? ExpectedResponseJson { get; }
        }
    }
}