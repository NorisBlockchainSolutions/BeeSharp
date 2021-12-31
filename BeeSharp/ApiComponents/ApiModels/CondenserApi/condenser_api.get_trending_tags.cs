using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_trending_tags
    {
        public class CondenserApiGetTrendingTags : ICondenserApiCall<object, List<CondenserApiTrendingTagModel>>
        {
            public CondenserApiGetTrendingTags(string? tag, [Range(-1, 100)] int limit)
            {
                QueryParametersJson = new[] {tag!, (object) limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_trending_tags";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiTrendingTagModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiTrendingTagModel
        {
            public CondenserApiTrendingTagModel(string name, NumberOrStringModel comments, NumberOrStringModel topPosts,
                string totalPayouts)
            {
                Name = name;
                Comments = comments;
                TopPosts = topPosts;
                TotalPayouts = totalPayouts;
            }

            [JsonPropertyName("name")] public string Name { get; }

            [JsonPropertyName("comments")] public NumberOrStringModel Comments { get; }

            [JsonPropertyName("top_posts")] public NumberOrStringModel TopPosts { get; }

            [JsonPropertyName("total_payouts")] public string TotalPayouts { get; }
        }
    }
}