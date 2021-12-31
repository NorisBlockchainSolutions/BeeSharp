using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_discussions_by_author_before_date
    {
        public class
            CondenserApiGetDiscussionsByAuthorBeforeDate : ICondenserApiCall<object, List<CondenserApiCommentModel>>
        {
            public CondenserApiGetDiscussionsByAuthorBeforeDate(
                string author, string permLink, DateTime beforeDate, long limit)
            {
                QueryParametersJson = new[] {author, permLink, beforeDate, (object) limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")]
            public string MethodName => "condenser_api.get_discussions_by_author_before_date";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiCommentModel>? ExpectedResponseJson { get; }
        }
    }
}