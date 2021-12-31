using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_discussions_by_comments
    {
        public class
            CondenserApiGetDiscussionsByComments : ICondenserApiCall<
                CondenserApiGetDiscussionsByCommentsQueryParametersJson,
                List<CondenserApiCommentModel>>
        {
            public CondenserApiGetDiscussionsByComments(
                string startAuthor, string startPermLink, long limit)
            {
                QueryParametersJson = new[]
                    {new CondenserApiGetDiscussionsByCommentsQueryParametersJson(startAuthor, startPermLink, limit)};
                ExpectedResponseJson = new List<CondenserApiCommentModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiGetDiscussionsByCommentsQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_discussions_by_comments";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiCommentModel> ExpectedResponseJson { get; }
        }

        public class CondenserApiGetDiscussionsByCommentsQueryParametersJson
        {
            public CondenserApiGetDiscussionsByCommentsQueryParametersJson(string startAuthor, string startPermLink,
                long limit)
            {
                StartAuthor = startAuthor;
                StartPermLink = startPermLink;
                Limit = limit;
            }

            [JsonPropertyName("start_author")] public string StartAuthor { get; }

            [JsonPropertyName("start_permlink")] public string StartPermLink { get; }

            [JsonPropertyName("limit")] public long Limit { get; }
        }
    }
}