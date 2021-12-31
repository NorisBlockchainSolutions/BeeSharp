using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api
{
    public class NullOrElementJsonConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return true;
        }

        public override System.Text.Json.Serialization.JsonConverter? CreateConverter(Type typeToConvert,
            JsonSerializerOptions options)
        {
            var converter = (System.Text.Json.Serialization.JsonConverter) Activator.CreateInstance(
                typeof(NullOrElementConverterInner<>).MakeGenericType(typeToConvert),
                null
            )!;
            return converter;
        }

        private class NullOrElementConverterInner<T> : JsonConverter<T> where T : class
        {
            public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.Null) return null;
                return JsonSerializer.Deserialize<T?>(ref reader, options);
            }

            public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value, options);
            }
        }
    }
}