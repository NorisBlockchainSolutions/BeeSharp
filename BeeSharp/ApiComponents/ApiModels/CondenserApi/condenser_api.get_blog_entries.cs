using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_blog_entries
    {
        public class CondenserApiGetBlogEntries : ICondenserApiCall<object, List<CondenserApiBlogEntryCompactModel>>
        {
            public CondenserApiGetBlogEntries(string account, int startEntry, [Range(0, 500)] int limit)
            {
                QueryParametersJson = new[] {account, (object) startEntry, limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_blog_entries";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiBlogEntryCompactModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiBlogEntryCompactModel
        {
            public CondenserApiBlogEntryCompactModel(string author, string permLink, string blog, DateTime rebloggedOn,
                NumberOrStringModel entryId)
            {
                Author = author;
                PermLink = permLink;
                Blog = blog;
                RebloggedOn = rebloggedOn;
                EntryId = entryId;
            }

            [JsonPropertyName("blog")] public string Blog { get; }

            [JsonPropertyName("entry_id")] public NumberOrStringModel EntryId { get; }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            [JsonPropertyName("reblogged_on")] public DateTime RebloggedOn { get; }
        }
    }
}