using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class KeyAuthJsonConverter : JsonConverter<AccountKeyAuthModel>
    {
        public override AccountKeyAuthModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            // Enter array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.StartArray, true);

            var key = reader.GetString() ?? throw new JsonException("Cannot parse Key!");
            if (!reader.Read()) throw new JsonException();

            var signatureIndex = JsonSerializer.Deserialize<NumberOrStringModel>(ref reader, options)
                                 ?? throw new JsonException("Cannot parse AccountThreshold!");
            if (!reader.Read()) throw new JsonException();

            // Exit array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndArray, false);
            return new AccountKeyAuthModel(key, signatureIndex);
        }

        public override void Write(Utf8JsonWriter writer, AccountKeyAuthModel value, JsonSerializerOptions options)
        {
            // Create list representation
            var listFormat = new object[2];

            listFormat[0] = value.Key!;
            listFormat[1] = value.KeyThreshold;

            JsonSerializer.Serialize(writer, listFormat, options);
        }
    }
}