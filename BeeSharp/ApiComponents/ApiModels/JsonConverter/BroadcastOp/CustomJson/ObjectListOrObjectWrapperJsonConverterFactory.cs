using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public class ObjectListOrObjectWrapperJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            var genericType = typeToConvert.GetGenericTypeDefinition();
            if (typeof(ObjectListOrObjectWrapperModel<>) != genericType) return false;
            return true;
        }

        public override System.Text.Json.Serialization.JsonConverter CreateConverter(Type typeToConvert,
            JsonSerializerOptions options)
        {
            // Extract type parameter
            var type = typeToConvert.GetGenericArguments()[0];
            return ((System.Text.Json.Serialization.JsonConverter) Activator.CreateInstance(
                typeof(HiveEngineWrapperJsonConverterInner<>).MakeGenericType(type),
                null
            )!)!;
        }

        private class HiveEngineWrapperJsonConverterInner<T> : JsonConverter<ObjectListOrObjectWrapperModel<T>>
        {
            public override ObjectListOrObjectWrapperModel<T> Read(ref Utf8JsonReader reader, Type typeToConvert,
                JsonSerializerOptions options)
            {
                var isList = false;
                if (reader.TokenType == JsonTokenType.StartArray)
                {
                    // Object is a list
                    reader.Read();
                    isList = true;
                }

                var result = new List<T>();
                
                // Check for additional string nesting and resolve recursively
                if (reader.TokenType == JsonTokenType.String)
                {
                    var rawValue = reader.GetString();

                    if (rawValue!.StartsWith('[') || rawValue.StartsWith('{'))
                    {
                        reader.Read();
                        return JsonSerializer.Deserialize<ObjectListOrObjectWrapperModel<T>>(rawValue!, options)!;
                    }
                }
                
                // Check for empty list
                if (reader.TokenType == JsonTokenType.EndArray)
                    return new ObjectListOrObjectWrapperModel<T>(result.ToArray());
                
                do
                {
                    result.Add(
                        JsonSerializer.Deserialize<T>(ref reader, options)!);
                    if(isList) reader.Read();
                } while (isList && reader.TokenType != JsonTokenType.EndArray);

                return new ObjectListOrObjectWrapperModel<T>(result.ToArray());
            }

            public override void Write(Utf8JsonWriter writer, ObjectListOrObjectWrapperModel<T> value,
                JsonSerializerOptions options)
            {
                var isArray = false;
                if (value.Transactions.Length > 1)
                {
                    isArray = true;
                    writer.WriteStartArray();
                }

                foreach (var entry in value.Transactions)
                {
                    JsonSerializer.Serialize(writer, entry, options);
                }

                if (isArray) writer.WriteEndArray();
            }
        }
    }
}