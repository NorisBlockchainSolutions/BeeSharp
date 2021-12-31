using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_follow_count
    {
        public class CondenserApiGetFollowCount : ICondenserApiCall<string, CondenserApiAccountFollowCountModel>
        {
            public CondenserApiGetFollowCount(string account)
            {
                QueryParametersJson = new[] {account};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_follow_count";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiAccountFollowCountModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiAccountFollowCountModel
        {
            public CondenserApiAccountFollowCountModel(string account, NumberOrStringModel followingCount,
                NumberOrStringModel followerCount)
            {
                Account = account;
                FollowerCount = followerCount;
                FollowingCount = followingCount;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("following_count")] public NumberOrStringModel FollowingCount { get; }

            [JsonPropertyName("follower_count")] public NumberOrStringModel FollowerCount { get; }
        }
    }
}