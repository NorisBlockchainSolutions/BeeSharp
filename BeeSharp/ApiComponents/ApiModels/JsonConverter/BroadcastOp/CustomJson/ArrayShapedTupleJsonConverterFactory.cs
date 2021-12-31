using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public class ArrayShapedTupleJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var genericType = typeToConvert.GetGenericTypeDefinition();
            return typeof(Tuple<,>) == genericType;
        }

        public override System.Text.Json.Serialization.JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            // Extract type parameter
            var t1 = typeToConvert.GetGenericArguments()[0];
            var t2 = typeToConvert.GetGenericArguments()[1];
            return ((System.Text.Json.Serialization.JsonConverter) Activator.CreateInstance(
                typeof(ArrayShapedTupleJsonConverterInner<,>).MakeGenericType(t1, t2),
                null
            )!)!;
        }

        private class ArrayShapedTupleJsonConverterInner<T1, T2> : JsonConverter<Tuple<T1, T2>>
        {
            public override Tuple<T1, T2>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Cannot serialize non-list!");
                reader.Read();
                
                // Deserialize first component
                var first = JsonSerializer.Deserialize<T1>(ref reader, options);
                reader.Read();
                var second = JsonSerializer.Deserialize<T2>(ref reader, options);
                reader.Read();

                return new Tuple<T1, T2>(first!, second!);
            }

            public override void Write(Utf8JsonWriter writer, Tuple<T1, T2> value, JsonSerializerOptions options)
            {
                writer.WriteStartArray();

                JsonSerializer.Serialize(writer, value.Item1, options);
                JsonSerializer.Serialize(writer, value.Item2, options);
                
                writer.WriteEndArray();
            }
        }
    }
}