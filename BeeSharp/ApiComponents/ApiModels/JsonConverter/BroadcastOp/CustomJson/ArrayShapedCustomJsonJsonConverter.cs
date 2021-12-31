#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public class ArrayShapedCustomJsonJsonConverter : JsonConverter<ArrayShapedCustomJsonModel>
    {
        private static ArrayShapedCustomJsonModel? UnknownCustomJsonWithinArrayHandler(ref Utf8JsonReader reader)
        {
            // Read with the reader, until the end of the current array is reached
            while (reader.TokenType != JsonTokenType.EndArray)
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartArray:
                        if (!reader.TrySkip()) throw new JsonException();
                        // Read ending of child array
                        if (!reader.Read()) throw new JsonException();
                        break;
                    case JsonTokenType.StartObject:
                        if (!reader.TrySkip()) throw new JsonException();
                        // Read ending of object
                        if (!reader.Read()) throw new JsonException();
                        break;
                    default:
                        if (!reader.Read()) throw new JsonException();
                        break;
                }

            return null;
        }

        private static ArrayShapedCustomJsonModel? UnknownCustomJsonHandler(ref Utf8JsonReader reader)
        {
            // Only arrays of structure [ operationName, operation ] are supported!
            // Cannot simply return null, because reader needs to be adjusted to the right position
            if (!reader.TrySkip()) throw new JsonException();
            return null;
        }

        public override ArrayShapedCustomJsonModel? Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            // Check if content is an array
            if (reader.TokenType != JsonTokenType.StartArray) return UnknownCustomJsonHandler(ref reader);
            // Enter array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.StartArray, true);

            // Get operationName
            if (reader.TokenType != JsonTokenType.String) return UnknownCustomJsonWithinArrayHandler(ref reader);
            var operationName = reader.GetString();
            if (operationName is null) return UnknownCustomJsonWithinArrayHandler(ref reader);
            if (!reader.Read()) return UnknownCustomJsonWithinArrayHandler(ref reader);

            // Get operation
            if (reader.TokenType != JsonTokenType.StartObject) return UnknownCustomJsonWithinArrayHandler(ref reader);
            var director = (CustomJsonOpListOpDirector)DirectorRegistry.GetDirector(typeof(CustomJsonOpListOpDirector));
            var operationType = director.GetStructure(operationName!);
            if (operationType is null) return UnknownCustomJsonWithinArrayHandler(ref reader);

            var resultOperation = (CustomJsonOperation)JsonSerializer.Deserialize(ref reader, operationType!, options)!;
            if (resultOperation is null) return UnknownCustomJsonWithinArrayHandler(ref reader);
            if (!reader.Read()) return UnknownCustomJsonWithinArrayHandler(ref reader);

            // Exit array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndArray, false);

            return new ArrayShapedCustomJsonModel(operationName!, resultOperation!);
        }

        public override void Write(Utf8JsonWriter writer, ArrayShapedCustomJsonModel value,
            JsonSerializerOptions options)
        {
            // Create list representation
            var listFormat = new object[2];

            listFormat[0] = value.Name;
            listFormat[1] = value.Operation!;

            JsonSerializer.Serialize(writer, listFormat, options);
        }
    }
}