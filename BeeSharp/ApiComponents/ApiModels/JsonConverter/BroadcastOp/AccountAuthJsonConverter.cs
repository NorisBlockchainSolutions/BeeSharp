using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class AccountAuthJsonConverter : JsonConverter<AccountAuthModel>
    {
        public override AccountAuthModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            // Enter array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.StartArray, true);

            var accountName = reader.GetString() ?? throw new JsonException("Cannot parse accountName!");
            if (!reader.Read()) throw new JsonException();

            var signatureIndex = JsonSerializer.Deserialize<NumberOrStringModel>(ref reader, options)
                                 ?? throw new JsonException("Cannot parse KeyThreshold!");
            if (!reader.Read()) throw new JsonException();

            // Exit array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndArray, false);
            return new AccountAuthModel(accountName, signatureIndex);
        }

        public override void Write(Utf8JsonWriter writer, AccountAuthModel value, JsonSerializerOptions options)
        {
            // Create list representation
            var listFormat = new object[2];

            listFormat[0] = value.AccountName!;
            listFormat[1] = value.AccountThreshold;

            JsonSerializer.Serialize(writer, listFormat, options);
        }
    }
}