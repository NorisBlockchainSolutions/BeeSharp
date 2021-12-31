using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.ApiComponents.Condenser.CallComponents.ErrorDetails;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter
{
    public class ErrorResponseJsonConverter : JsonConverter<CondenserApiErrorDataWrapper>
    {
        public override CondenserApiErrorDataWrapper Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            var result = new CondenserApiErrorDataWrapper();
            if (reader.TokenType == JsonTokenType.String)
                result.Raw = reader.GetString();
            else
                result.Data = JsonSerializer.Deserialize<CondenserApiErrorData>(ref reader, options);

            return result;
        }

        public override void Write(Utf8JsonWriter writer, CondenserApiErrorDataWrapper value,
            JsonSerializerOptions options)
        {
            if (value.Raw is not null)
            {
                var intermediate = JsonSerializer.Deserialize<dynamic>(value.Raw);
                JsonSerializer.Serialize(writer, intermediate, options);
            }
            else
            {
                JsonSerializer.Serialize(writer, value.Data, options);
            }
        }
    }
}