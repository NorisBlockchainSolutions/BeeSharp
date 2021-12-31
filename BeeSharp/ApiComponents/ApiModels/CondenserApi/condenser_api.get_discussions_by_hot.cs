using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_discussions_by_hot
    {
        public class CondenserApiGetDiscussionsByHot : ICondenserApiCall<
            CondenserApiGetDiscussionsByHotQueryParametersJson, List<CondenserApiCommentModel>>
        {
            public CondenserApiGetDiscussionsByHot(string tag, long limit,
                string[]? filterTags = null,
                long truncateBody = 0)
            {
                QueryParametersJson = new[]
                    {new CondenserApiGetDiscussionsByHotQueryParametersJson(tag, limit, filterTags, truncateBody)};
                ExpectedResponseJson = new List<CondenserApiCommentModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiGetDiscussionsByHotQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_discussions_by_hot";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiCommentModel> ExpectedResponseJson { get; }
        }

        public class CondenserApiGetDiscussionsByHotQueryParametersJson
        {
            public CondenserApiGetDiscussionsByHotQueryParametersJson(string tag, long limit,
                string[]? filterTags = null,
                long truncateBody = 0)
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