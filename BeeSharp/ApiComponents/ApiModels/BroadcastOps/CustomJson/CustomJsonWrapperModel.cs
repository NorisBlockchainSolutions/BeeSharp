using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson
{
    [JsonConverter(typeof(CustomJsonJsonConverter))]
    public class CustomJsonWrapperModel
    {
        public CustomJsonWrapperModel(string id, string rawResponse)
        {
            RawResponse = rawResponse;
            JsonModel = CustomJsonJsonConverter.DeserializeCustomJson(id, rawResponse);
        }

        public CustomJsonWrapperModel(CustomJsonOperation jsonModel)
        {
            JsonModel = jsonModel;
            RawResponse = DeserializeJsonModel(jsonModel);
        }

        public string RawResponse { get; }
        public CustomJsonOperation? JsonModel { get; }

        private string DeserializeJsonModel(object jsonModel)
        {
            return JsonSerializer.Serialize(jsonModel);
        }
    }
}