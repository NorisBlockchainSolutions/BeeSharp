using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.witness_set_properties;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class WitnessPropertiesJsonConverter : JsonConverter<WitnessPropertiesModel>
    {
        public override WitnessPropertiesModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            // Structure: [["PropertyName","PropertyValue"],["Property2Name","Property2Value"]]
            
            // Enter list 
            if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Invalid json list!");
            reader.Read();

            var result = new WitnessPropertiesModel();
            var resultProperties = result.GetType().GetProperties();
            
            // extract all serialization names
            var jsonSerializationNames = new Dictionary<string, PropertyInfo>();
            foreach (var property in resultProperties)
            {
                var jsonProperty = (JsonPropertyNameAttribute)property.GetCustomAttributes(false)
                    .First(a => a.GetType() == typeof(JsonPropertyNameAttribute)!);
                jsonSerializationNames.Add(jsonProperty.Name, property);
            }
            
            do
            {
                // Structure: ["PropertyName","PropertyValue"]
                // Enter list element
                if (reader.TokenType != JsonTokenType.StartArray) throw new JsonException("Invalid json list!");
                reader.Read();
                // Get propertyName
                if (reader.TokenType != JsonTokenType.String) throw new JsonException("Invalid json type!");
                var propertyName = reader.GetString()!;
                reader.Read();
                
                // Get propertyValue
                object propertyValue;
                if (reader.TokenType != JsonTokenType.String)
                {
                    // Property must be a NumberOrStringModel
                    propertyValue = JsonSerializer.Deserialize<NumberOrStringModel>(ref reader, options)!;
                }
                else
                {
                    propertyValue = reader.GetString()!;
                }
                reader.Read();
                
                // Set property
                jsonSerializationNames[propertyName!].SetMethod!.Invoke(result, new []{propertyValue});

                // Leave list element
                if (reader.TokenType != JsonTokenType.EndArray) throw new JsonException("Invalid json list!");
                reader.Read();
            } while (reader.TokenType != JsonTokenType.EndArray);

            return result;
        }

        public override void Write(Utf8JsonWriter writer, WitnessPropertiesModel value,
            JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            var properties = value.GetType().GetProperties();
            foreach (var propertyInfo in properties)
            {
                var propertyAttribute = (JsonPropertyNameAttribute) propertyInfo
                    .GetCustomAttributes(false).First(a => a.GetType() == typeof(JsonPropertyNameAttribute)!);

                // skip if value is null
                var propertyValue = propertyInfo.GetMethod!.Invoke(value, null);
                if (propertyValue is null) continue;
                
                writer.WriteStartArray();
                JsonSerializer.Serialize(writer, propertyAttribute.Name, options);
                JsonSerializer.Serialize(writer, propertyValue, options);
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
        }
    }
}