using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_followers;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_following
    {
        public struct CondenserApiGetFollowing : ICondenserApiCall<object, List<CondenserApiFollowerModel>>
        {
            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; set; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_following";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiFollowerModel> ExpectedResponseJson { get; set; }

            public CondenserApiGetFollowing(string account, string start, string type, int limit)
            {
                QueryParametersJson = new[] {account, start, type, (object) limit};
                ExpectedResponseJson = new List<CondenserApiFollowerModel>();
            }
        }
    }
}