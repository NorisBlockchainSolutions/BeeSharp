using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class ExtensionModelJsonConverter : JsonConverter<ExtensionModel>
    {
        public override ExtensionModel Read(ref Utf8JsonReader reader, Type typeToConvert,
            JsonSerializerOptions options)
        {
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.StartArray, true);

            var resId = new NumberOrStringModel(reader.GetInt64());
            Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.Number, true);

            // Extension can continue with a string version or a beneficiaries object
            if (reader.TokenType == JsonTokenType.String)
            {
                // Read string
                var info = JsonSerializer.Deserialize<string>(ref reader, options);
                Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.String, true);
                return new ExtensionModel(resId, info:info);
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                // Parse Beneficiaries
                Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.StartObject, true);
                var resBeneficiaries = JsonSerializer.Deserialize<BeneficiaryModel[]>(ref reader, options)
                                       ?? Array.Empty<BeneficiaryModel>();
                Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndArray, true);
                Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndObject, true);

                Utf8JsonReaderHelper.ReadToken(ref reader, JsonTokenType.EndArray, false);
                return new ExtensionModel(resId, resBeneficiaries);
            }
            else
            {
                throw new JsonException("Unsupported extension type!");
            }
        }

        public override void Write(Utf8JsonWriter writer, ExtensionModel value, JsonSerializerOptions options)
        {
            // Create list representation
            var listFormat = new object[2];

            listFormat[0] = value.Id;
            
            // read info or beneficiaries
            if (value.Info is not null)
            {
                listFormat[1] = value.Info;
            }
            else if (value.Beneficiaries is not null)
            {
                listFormat[1] = new {beneficiaries = value.Beneficiaries};
            }

            JsonSerializer.Serialize(writer, listFormat, options);
        }
    }
}