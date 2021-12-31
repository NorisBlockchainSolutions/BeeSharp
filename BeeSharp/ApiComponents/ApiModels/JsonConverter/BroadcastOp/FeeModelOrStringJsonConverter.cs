using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class FeeModelOrStringJsonConverter : JsonConverter<FeeModelOrStringModel>
    {
        public override FeeModelOrStringModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
                return new FeeModelOrStringModel(reader.GetString());

            return new FeeModelOrStringModel(null,
                JsonSerializer.Deserialize<FeeModel>(ref reader, options));
        }

        public override void Write(Utf8JsonWriter writer, FeeModelOrStringModel value, JsonSerializerOptions options)
        {
            if (value.StringValue is not null) JsonSerializer.Serialize(writer, value.StringValue, options);
            else JsonSerializer.Serialize(writer, value.FeeModelValue, options);
        }
    }
}