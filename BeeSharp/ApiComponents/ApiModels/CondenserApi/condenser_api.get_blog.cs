using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_blog
    {
        public class CondenserApiGetBlog : ICondenserApiCall<object, List<CondenserApiBlogEntryModel>>
        {
            public CondenserApiGetBlog(string account, NumberOrStringModel startEntryId, [Range(-1, 500)] int limit)
            {
                QueryParametersJson = new[] {account, (object) startEntryId, limit};
                ExpectedResponseJson = new List<CondenserApiBlogEntryModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_blog";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiBlogEntryModel> ExpectedResponseJson { get; }
        }

        public class CondenserApiBlogEntryModel
        {
            public CondenserApiBlogEntryModel(CondenserApiCommentModel condenserApiComment, string blog,
                DateTime rebloggedOn, NumberOrStringModel entryId)
            {
                CondenserApiComment = condenserApiComment;
                Blog = blog;
                RebloggedOn = rebloggedOn;
                EntryId = entryId;
            }

            [JsonPropertyName("blog")] public string Blog { get; }

            [JsonPropertyName("entry_id")] public NumberOrStringModel EntryId { get; }

            [JsonPropertyName("comment")] public CondenserApiCommentModel CondenserApiComment { get; }

            [JsonPropertyName("reblogged_on")] public DateTime RebloggedOn { get; }
        }
    }
}