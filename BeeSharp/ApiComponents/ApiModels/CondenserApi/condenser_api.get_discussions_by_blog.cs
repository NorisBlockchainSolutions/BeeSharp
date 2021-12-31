using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_discussions_by_blog
    {
        public class CondenserApiGetDiscussionsByBlog : ICondenserApiCall<
            CondenserApiGetDiscussionsByBlogQueryParametersJson, List<CondenserApiCommentModel>>
        {
            public CondenserApiGetDiscussionsByBlog(string tag, long limit,
                string[]? filterTags = null,
                long truncateBody = 0)
            {
                QueryParametersJson = new[]
                    {new CondenserApiGetDiscussionsByBlogQueryParametersJson(tag, limit, filterTags, truncateBody)};
                ExpectedResponseJson = new List<CondenserApiCommentModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiGetDiscussionsByBlogQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_discussions_by_blog";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiCommentModel> ExpectedResponseJson { get; }
        }

        public class CondenserApiGetDiscussionsByBlogQueryParametersJson
        {
            public CondenserApiGetDiscussionsByBlogQueryParametersJson(string tag, long limit, string[]? filterTags,
                long truncateBody)
            {
                Tag = tag;
                Limit = limit;
                FilterTags = filterTags;
                TruncateBody = truncateBody;
            }

            [JsonPropertyName("tag")] public string Tag { get; }

            [JsonPropertyName("limit")] public long Limit { get; }

            [JsonPropertyName("filter_tags")] public string[]? FilterTags { get; }

            [JsonPropertyName("truncate_body")] public long TruncateBody { get; }
        }
    }
}