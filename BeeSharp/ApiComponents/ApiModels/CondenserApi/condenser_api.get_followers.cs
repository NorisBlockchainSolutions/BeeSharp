using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_followers
    {
        public class CondenserApiGetFollowers : ICondenserApiCall<object, List<CondenserApiFollowerModel>>
        {
            public CondenserApiGetFollowers(string account, string start, string type, int limit)
            {
                QueryParametersJson = new[] {account, start, type, (object) limit};
                ExpectedResponseJson = new List<CondenserApiFollowerModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_followers";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiFollowerModel> ExpectedResponseJson { get; }
        }

        public class CondenserApiFollowerModel
        {
            public CondenserApiFollowerModel(string follower, string following, string[] what)
            {
                Follower = follower;
                Following = following;
                What = what;
            }

            [JsonPropertyName("follower")] public string Follower { get; }

            [JsonPropertyName("following")] public string Following { get; }

            [JsonPropertyName("what")] public string[] What { get; }
        }
    }
}