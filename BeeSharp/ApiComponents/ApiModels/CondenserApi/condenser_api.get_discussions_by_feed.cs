using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_discussions_by_feed
    {
        public class
            CondenserApiGetDiscussionsByFeed : ICondenserApiCall<CondenserApiGetDiscussionsByFeedQueryParametersJson,
                List<CondenserApiCommentModel>>
        {
            public CondenserApiGetDiscussionsByFeed(string tag, long limit,
                string? startAuthor = null, string? startPermLink = null)
            {
                QueryParametersJson = new[]
                    {new CondenserApiGetDiscussionsByFeedQueryParametersJson(tag, limit, startAuthor, startPermLink)};
                ExpectedResponseJson = new List<CondenserApiCommentModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiGetDiscussionsByFeedQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_discussions_by_feed";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiCommentModel> ExpectedResponseJson { get; }
        }

        public class CondenserApiGetDiscussionsByFeedQueryParametersJson
        {
            public CondenserApiGetDiscussionsByFeedQueryParametersJson(string tag, long limit,
                string? startAuthor = null, string? startPermLink = null)
            {
                Tag = tag;
                StartAuthor = startAuthor;
                StartPermLink = startPermLink;
                Limit = limit;
            }

            [JsonPropertyName("tag")] public string Tag { get; }

            [JsonPropertyName("start_author")] public string? StartAuthor { get; }

            [JsonPropertyName("start_permlink")] public string? StartPermLink { get; }

            [JsonPropertyName("limit")] public long Limit { get; }
        }
    }
}