using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson.BroadcastOpsCommunities
{
    namespace updateProps
    {
        [CustomJsonOpListOp("updateProps")]
        public class CustomJsonCommunityOpUpdatePropsModel : CustomJsonOperation
        {
            /// <summary>
            ///     Set/Update the properties of a community.
            /// </summary>
            /// <param name="community">PostId of the community.</param>
            /// <param name="properties">The properties to set.</param>
            public CustomJsonCommunityOpUpdatePropsModel(string community, PropertiesModel properties)
            {
                Community = community;
                Properties = properties;
            }

            [JsonPropertyName("community")] public string Community { get; }

            [JsonPropertyName("props")] public PropertiesModel Properties { get; }
        }

        public class PropertiesModel
        {
            public PropertiesModel(string title, string about, bool isNsfw, string description, string flagText)
            {
                Title = title;
                About = about;
                IsNsfw = isNsfw;
                Description = description;
                FlagText = flagText;
            }

            [JsonPropertyName("title")] public string Title { get; }

            [JsonPropertyName("about")] public string About { get; }

            [JsonPropertyName("is_nsfw")] public bool IsNsfw { get; }

            [JsonPropertyName("description")] public string Description { get; }

            [JsonPropertyName("flag_text")] public string FlagText { get; }
        }
    }
}