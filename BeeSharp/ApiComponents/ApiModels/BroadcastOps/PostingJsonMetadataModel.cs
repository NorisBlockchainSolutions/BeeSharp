using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    /// <summary>
    ///     This component is not validated by the blockchain!
    /// </summary>
    [JsonConverter(typeof(PostingJsonMetadataJsonConverter))]
    public class PostingJsonMetadataResponseModel
    {
        [JsonConstructor]
        public PostingJsonMetadataResponseModel(string rawResponse,
            PostingJsonMetadataModel? postingJsonMetadataModel = null)
        {
            RawResponse = rawResponse;
            PostingJsonMetadataModel = postingJsonMetadataModel;
        }

        /// <summary>
        ///     RegisterNew a new model for serialization.
        /// </summary>
        /// <param name="postingJsonMetadataModel">The model to serialize.</param>
        public PostingJsonMetadataResponseModel(PostingJsonMetadataModel postingJsonMetadataModel)
        {
            RawResponse = JsonSerializer.Serialize(postingJsonMetadataModel);
            PostingJsonMetadataModel = postingJsonMetadataModel;
        }

        public string RawResponse { get; }
        public PostingJsonMetadataModel? PostingJsonMetadataModel { get; }
    }

    /// <summary>
    ///     Any new keys can be added by a developer, therefore the model contains only the basic keys that often used.
    /// </summary>
    public class PostingJsonMetadataModel
    {
        public PostingJsonMetadataModel(PostingJsonMetadataProfileModel profile)
        {
            Profile = profile;
        }

        [JsonPropertyName("profile")] public PostingJsonMetadataProfileModel Profile { get; }
    }

    public class PostingJsonMetadataProfileModel
    {
        public PostingJsonMetadataProfileModel(string about, string pinned, NumberOrStringModel version, string website,
            string profileImage, string coverImage, string location)
        {
            About = about;
            Pinned = pinned;
            Version = version;
            Website = website;
            ProfileImage = profileImage;
            CoverImage = coverImage;
            Location = location;
        }

        [JsonPropertyName("about")] public string About { get; }

        [JsonPropertyName("pinned")] public string Pinned { get; }

        [JsonPropertyName("version")] public NumberOrStringModel Version { get; }

        [JsonPropertyName("website")] public string Website { get; }

        [JsonPropertyName("profile_image")] public string ProfileImage { get; }

        [JsonPropertyName("cover_image")] public string CoverImage { get; }

        [JsonPropertyName("location")] public string Location { get; }
    }
}