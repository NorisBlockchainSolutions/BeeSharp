#nullable enable
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents;
using BeeSharp.root.DebugInfoProvider;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class OperationJsonConverter : JsonConverter<BroadcastOpModel>
    {
        public override BroadcastOpModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.StartArray, true);

            var resultName = reader.GetString() ?? throw new JsonException();
            if (!reader.Read()) throw new JsonException();

            BroadcastOperation? resultOperation;
            var director = (BroadcastOpDirector)DirectorRegistry.GetDirector(typeof(BroadcastOpDirector));
            var operationType = director.GetStructure(resultName);
            
            // Get string representation first
            // This results in deserializing the whole operation, whether it can actually be deserialized in a model or
            // not.
            // If the deserialization failed, the JsonSerializer would not know where to continue for the next operation
            // otherwise.
            var operation = JsonSerializer.Deserialize<dynamic>(ref reader, options);
            var operationString = operation is null ? "" : (string)JsonSerializer.Serialize(operation);

            BroadcastOpModel? result = null;
            if (operationType is not null)
            {
                try
                {
                    resultOperation = (BroadcastOperation)JsonSerializer.Deserialize(operationString, operationType, options)!;
                    result = new BroadcastOpModel(resultName, resultOperation);
                }
                catch (JsonException e)
                {
                    JsonNotParsableInfoProvider.OnJsonNotParsable(this,
                        new JsonNotParsableEventArgs(resultName, e.ToString()));
                }
            }
            
            // Create result with operation string, since serialization failed
            result ??= new BroadcastOpModel(resultName, operationString);

            if (!reader.Read()) throw new JsonException();

            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndArray, false);
            return result;
        }

        public override void Write(Utf8JsonWriter writer, BroadcastOpModel value, JsonSerializerOptions options)
        {
            // Create list representation
            var listFormat = new object?[2];

            listFormat[0] = value.Name;
            listFormat[1] = value.Operation ?? (object)value.RawOperation!;

            JsonSerializer.Serialize(writer, listFormat, options);
        }
    }
}