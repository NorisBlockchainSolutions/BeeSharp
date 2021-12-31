using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class PostingJsonMetadataJsonConverter : JsonConverter<PostingJsonMetadataResponseModel>
    {
        public override PostingJsonMetadataResponseModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            // JsonMetadata is in string quotes. Read as string.
            var inner = JsonSerializer.Deserialize<string>(ref reader, options) ?? throw new JsonException();

            // Manually create and populate struct to avoid infinite recursion
            PostingJsonMetadataModel? postingJsonMetadataModel = null;
            if (!string.IsNullOrWhiteSpace(inner))
            {
                try
                {
                    postingJsonMetadataModel = JsonSerializer.Deserialize<PostingJsonMetadataModel>(inner);
                }
                catch (JsonException)
                {
                    // Serialization failed, continue with null object
                }
            }
            var result = new PostingJsonMetadataResponseModel(
                inner,
                postingJsonMetadataModel
            );

            return result;
        }

        public override void Write(Utf8JsonWriter writer, PostingJsonMetadataResponseModel value,
            JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.RawResponse, options);
        }
    }
}