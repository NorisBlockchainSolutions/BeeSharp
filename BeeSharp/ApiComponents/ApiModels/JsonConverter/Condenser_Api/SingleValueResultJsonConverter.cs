using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api
{
    public class SingleValueResultJsonConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var genericType = typeToConvert.GetGenericTypeDefinition();
            if (typeof(SingleValueResultModel<>) != genericType) return false;
            return true;
        }

        public override System.Text.Json.Serialization.JsonConverter? CreateConverter(Type typeToConvert,
            JsonSerializerOptions options)
        {
            var type = typeToConvert.GetGenericArguments()[0];
            var converter = (System.Text.Json.Serialization.JsonConverter) Activator.CreateInstance(
                typeof(SingleValueResultJsonConverterInner<>).MakeGenericType(type),
                null
            )!;
            return converter;
        }

        private class SingleValueResultJsonConverterInner<T> : JsonConverter<SingleValueResultModel<T>>
        {
            public override SingleValueResultModel<T> Read(ref Utf8JsonReader reader, Type typeToConvert,
                JsonSerializerOptions options)
            {
                var result = new SingleValueResultModel<T>(
                    JsonSerializer.Deserialize<T>(ref reader, options)
                );
                return result;
            }

            public override void Write(Utf8JsonWriter writer, SingleValueResultModel<T> value,
                JsonSerializerOptions options)
            {
                JsonSerializer.Serialize(writer, value.Value, options);
            }
        }
    }
}