using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.custom_json;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public class BroadcastOpCustomJsonJsonConverter : JsonConverter<BroadcastOpCustomJsonModel>
    {
        public override BroadcastOpCustomJsonModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            // Enter object
            if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException("Invalid json object!");
            reader.Read();

            string[]? requiredAuths = null;
            string[]? requiredPostingAuths = null;
            string? id = null;
            string? customJson = null;
            do
            {
                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new JsonException("Cannot parse object: missing PropertyName!");
                switch (reader.GetString())
                {
                    case "required_auths":
                        requiredAuths = JsonSerializer.Deserialize<string[]?>(ref reader, options);
                        break;
                    case "required_posting_auths":
                        requiredPostingAuths = JsonSerializer.Deserialize<string[]?>(ref reader, options);
                        break;
                    case "id":
                        id = JsonSerializer.Deserialize<string>(ref reader, options);
                        break;
                    case "json":
                        // Skip propertyName
                        reader.Read();
                        if (reader.TokenType != JsonTokenType.String)
                        {
                            // Sometimes custom json is posted without quotes.
                            // Extract object
                            var customJsonObject = JsonSerializer.Deserialize<dynamic>(ref reader, options);
                            // Get json string
                            customJson = JsonSerializer.Serialize(customJsonObject);
                        }
                        else
                        {
                            customJson = JsonSerializer.Deserialize<string>(ref reader, options);
                        }
                        break;
                    default:
                        throw new JsonException("Unknown custom json format!");
                }
                reader.Read();
            } while (reader.TokenType != JsonTokenType.EndObject);

            return new BroadcastOpCustomJsonModel(requiredAuths!, requiredPostingAuths!, id!,
                new CustomJsonWrapperModel(id!, customJson!));
        }

        public override void Write(Utf8JsonWriter writer, BroadcastOpCustomJsonModel value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("required_auths");
            JsonSerializer.Serialize(writer, value.RequiredAuths, options);
            writer.WritePropertyName("required_posting_auths");
            JsonSerializer.Serialize(writer, value.RequiredPostingAuths, options);
            writer.WritePropertyName("id");
            JsonSerializer.Serialize(writer, value.Id, options);
            writer.WriteString("json", value.Json.RawResponse);
            writer.WriteEndObject();
        }
    }
}