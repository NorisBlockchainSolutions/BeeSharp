using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api
{
    public class NumberOrStringJsonConverter : JsonConverter<NumberOrStringModel>
    {
        public override NumberOrStringModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            NumberOrStringModel result = reader.TokenType switch
            {
                JsonTokenType.String =>
                    new NumberOrStringModel(reader.GetString() ?? ""),
                JsonTokenType.Number =>
                    new NumberOrStringModel(reader.GetInt64()),
                _ => throw new JsonException("Cannot parse element!")
            };

            return result;
        }

        public override void Write(Utf8JsonWriter writer, NumberOrStringModel value, JsonSerializerOptions options)
        {
            if (value.OrigType == typeof(long))
                writer.WriteNumberValue(
                    Convert.ToInt64(value.Value));
            else JsonSerializer.Serialize(writer, value.Value, options);
        }
    }
}