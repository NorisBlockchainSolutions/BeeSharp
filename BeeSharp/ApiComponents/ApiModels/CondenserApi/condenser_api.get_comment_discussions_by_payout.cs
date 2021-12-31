using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_comment_discussions_by_payout
    {
        public class CondenserApiGetCommentDiscussionsByPayout : ICondenserApiCall<
            CondenserApiGetCommentDiscussionsByPayoutQueryParametersJson,
            List<CondenserApiCommentModel>>
        {
            public CondenserApiGetCommentDiscussionsByPayout(string tag, long limit, long truncateBody)
            {
                QueryParametersJson = new[]
                    {new CondenserApiGetCommentDiscussionsByPayoutQueryParametersJson(tag, limit, truncateBody)};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiGetCommentDiscussionsByPayoutQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")]
            public string MethodName => "condenser_api.get_comment_discussions_by_payout";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiCommentModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiGetCommentDiscussionsByPayoutQueryParametersJson
        {
            public CondenserApiGetCommentDiscussionsByPayoutQueryParametersJson(string tag, long limit,
                long truncateBody)
            {
                Tag = tag;
                Limit = limit;
                TruncateBody = truncateBody;
            }

            [JsonPropertyName("tag")] public string Tag { get; }

            [JsonPropertyName("limit")] public long Limit { get; }

            [JsonPropertyName("truncate_body")] public long TruncateBody { get; }
        }
    }
}