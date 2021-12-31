using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_post_discussions_by_payout
    {
        public class CondenserApiGetPostDiscussionsByPayout : ICondenserApiCall<
            CondenserApiGetPostDiscussionsByPayoutQueryParametersJson,
            List<CondenserApiCommentModel>>
        {
            public CondenserApiGetPostDiscussionsByPayout(string tag, long limit,
                long truncateBody = 0)
            {
                QueryParametersJson = new[]
                    {new CondenserApiGetPostDiscussionsByPayoutQueryParametersJson(tag, limit, truncateBody)};
                ExpectedResponseJson = new List<CondenserApiCommentModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiGetPostDiscussionsByPayoutQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_post_discussions_by_payout";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiCommentModel> ExpectedResponseJson { get; }
        }

        public class CondenserApiGetPostDiscussionsByPayoutQueryParametersJson
        {
            public CondenserApiGetPostDiscussionsByPayoutQueryParametersJson(string tag, long limit,
                long truncateBody = 0)
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