using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.root.DebugInfoProvider;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class JsonMetadataJsonConverter : JsonConverter<JsonMetadataResponseModel>
    {
        public override JsonMetadataResponseModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            // JsonMetadata is in string quotes. Read as string.
            var inner = JsonSerializer.Deserialize<string>(ref reader, options) ?? throw new JsonException();

            if (string.IsNullOrWhiteSpace(inner)) return new JsonMetadataResponseModel(inner);

            // Try to deserialize jsonMetadataModel (since it is custom, and not well defined, it will often not work)
            try
            {
                var model = JsonSerializer.Deserialize<JsonMetadataModel>(inner);
                return new JsonMetadataResponseModel(inner, model);
            }
            catch (JsonException e)
            {
                JsonNotParsableInfoProvider.OnJsonNotParsable(this,
                    new JsonNotParsableEventArgs(nameof(JsonMetadataModel), e.ToString()));
            }
            
            return new JsonMetadataResponseModel(inner);
        }

        public override void Write(Utf8JsonWriter writer, JsonMetadataResponseModel value,
            JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value.RawResponse, options);
        }
    }
}