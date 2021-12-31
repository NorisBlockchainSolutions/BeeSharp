using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class DecimalOrStringJsonConverter : JsonConverter<DecimalOrStringModel>
    {
        public override DecimalOrStringModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            DecimalOrStringModel result;
            switch (reader)
            {
                case {TokenType: JsonTokenType.String}:
                    result = new DecimalOrStringModel(reader.GetString() ?? "");
                    break;
                case {TokenType: JsonTokenType.Number}:
                    result = new DecimalOrStringModel(reader.GetDecimal());
                    break;
                case {TokenType: JsonTokenType.StartObject}:
                    // Sometimes {} instead of null is used
                    reader.Read();
                    if (reader.TokenType != JsonTokenType.EndObject)
                        throw new JsonException($"Cannot parse element as an empty object !");
                    result = new DecimalOrStringModel("");
                    break;
                case {TokenType: JsonTokenType.StartArray}:
                    // Sometimes [] instead of null is used
                    reader.Read();
                    if (reader.TokenType != JsonTokenType.EndArray)
                        throw new JsonException($"Cannot parse element as an empty array !");
                    result = new DecimalOrStringModel("");
                    break;
                default:
                    throw new JsonException($"Cannot parse element of type {reader.TokenType}!");
            }

            return result;
        }

        public override void Write(Utf8JsonWriter writer, DecimalOrStringModel value, JsonSerializerOptions options)
        {
            if (value.OrigType == typeof(long))
                writer.WriteNumberValue(
                    Convert.ToDecimal(value.Value));
            else JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}