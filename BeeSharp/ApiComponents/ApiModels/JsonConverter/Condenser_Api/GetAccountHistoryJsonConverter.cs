using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_account_history;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api
{
    public class GetAccountHistoryJsonConverter : JsonConverter<CondenserApiAccountHistoryModel>
    {
        public override CondenserApiAccountHistoryModel Read(ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            // Enter array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.StartArray, true);

            // Process id
            if (!reader.TryGetInt64(out var id)) throw new JsonException("Cannot parse id!");
            var resultId = new NumberOrStringModel(id);
            if (!reader.Read()) throw new JsonException("Unexpected end of sequence!");

            var resultCondenserApiHistoryInfoModel =
                JsonSerializer.Deserialize<CondenserApiHistoryInfoModel>(ref reader, options);
            if (resultCondenserApiHistoryInfoModel is null) throw new JsonException();

            // Exit CondenserApiHistoryInfoModel and array
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndObject, true);
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndArray, false);
            return new CondenserApiAccountHistoryModel(resultId, resultCondenserApiHistoryInfoModel);
        }

        public override void Write(Utf8JsonWriter writer, CondenserApiAccountHistoryModel value,
            JsonSerializerOptions options)
        {
            // Create list representation
            var listFormat = new object[2];
            listFormat[0] = value.Id;
            listFormat[1] = value.CondenserApiHistoryInfoModel;

            JsonSerializer.Serialize(writer, listFormat, options);
        }
    }
}