using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    /// <summary>
    ///     This component abstracts jsonMetadata component.
    ///     Serialization currently only supports rawResponse string! use new JsonMetadataResponseModel(null) for
    ///     empty jsonMetadata.
    /// </summary>
    [JsonConverter(typeof(JsonMetadataJsonConverter))]
    public class JsonMetadataResponseModel
    {
        public JsonMetadataResponseModel(string? rawResponse, JsonMetadataModel? jsonMetadataModel = null)
        {
            RawResponse = rawResponse ?? "{}";
            JsonMetadataModel = jsonMetadataModel;
        }

        public string? RawResponse { get; }
        public JsonMetadataModel? JsonMetadataModel { get; }
    }

    /// <summary>
    ///     Any new keys can be added by a developer, therefore the model contains only the basic keys that often used.
    ///     Currently unsupported for serialization!
    /// </summary>
    public class JsonMetadataModel
    {
        /// <summary>
        ///     Any new keys can be added by a developer, therefore the model contains only the basic keys that often used.
        /// </summary>
        /// <param name="tags">Only the first five entries will be processed by the tags plugin of the blockchain.</param>
        /// <param name="app">User-agent app identifier. Usually app_name/version.</param>
        /// <param name="format">Format of the body, eg. markdown.</param>
        /// <param name="community"></param>
        /// <param name="description"></param>
        /// <param name="portfolio"></param>
        /// <param name="links"></param>
        /// <param name="imageLinks"></param>
        public JsonMetadataModel(string[]? tags, string? app, string? format,
            string? community, string? description,
            bool? portfolio, string[]? links, string[]? imageLinks)
        {
            Tags = tags;
            App = app;
            Format = format;
            Community = community;
            Description = description;
            Portfolio = portfolio;
            Links = links;
            ImageLinks = imageLinks;
        }

        [JsonPropertyName("tags")] public string[]? Tags { get; }

        [JsonPropertyName("app")] public string? App { get; }

        [JsonPropertyName("format")] public string? Format { get; }

        [JsonPropertyName("community")] public string? Community { get; }

        [JsonPropertyName("description")] public string? Description { get; }

        [JsonPropertyName("portfolio")] public bool? Portfolio { get; }

        [JsonPropertyName("links")] public string[]? Links { get; }

        [JsonPropertyName("image")] public string[]? ImageLinks { get; }
    }
}