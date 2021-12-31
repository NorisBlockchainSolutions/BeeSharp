using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public class ArrayShapedTupleListJsonConverter<T1, T2> : JsonConverter<Tuple<T1,T2>[]>
    {
        private readonly ArrayShapedTupleJsonConverterFactory _converterFactory;
        public ArrayShapedTupleListJsonConverter()
        {
            _converterFactory = new ArrayShapedTupleJsonConverterFactory();
            if (!_converterFactory.CanConvert(typeof(Tuple<T1, T2>)))
                throw new JsonException("Invalid tuple type to serialize!");
        }
        
        public override Tuple<T1, T2>[]? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Cannot serialize non-list!");
            reader.Read();

            // Add jsonserializerFactory to options
            var extendedOptions = new JsonSerializerOptions(options);
            extendedOptions.Converters.Add(_converterFactory.CreateConverter(typeof(Tuple<T1,T2>), options)!);
            
            var result = new List<Tuple<T1, T2>>();
            do
            {
                result.Add(JsonSerializer.Deserialize<Tuple<T1, T2>>(ref reader, extendedOptions)!);
                reader.Read();
            } while (reader.TokenType != JsonTokenType.EndArray);

            return result.ToArray();
        }

        public override void Write(Utf8JsonWriter writer, Tuple<T1, T2>[] value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();

            // Add jsonserializerFactory to options
            var extendedOptions = new JsonSerializerOptions(options);
            extendedOptions.Converters.Add(_converterFactory.CreateConverter(typeof(Tuple<T1,T2>), options)!);
            
            foreach (var tuple in value)
            {
                JsonSerializer.Serialize(writer, tuple, extendedOptions);
            }
            
            writer.WriteEndArray();
        }
    }
}