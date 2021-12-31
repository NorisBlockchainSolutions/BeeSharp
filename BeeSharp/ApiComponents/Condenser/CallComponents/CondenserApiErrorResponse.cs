using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter;
using BeeSharp.ApiComponents.Condenser.CallComponents.ErrorDetails;

namespace BeeSharp.ApiComponents.Condenser.CallComponents
{
    public struct CondenserApiErrorResponse
    {
        [JsonPropertyName("code")] public int Code { get; set; }

        [JsonPropertyName("message")] public string Message { get; set; }

        [JsonPropertyName("data")] public CondenserApiErrorDataWrapper Data { get; set; }
    }

    [JsonConverter(typeof(ErrorResponseJsonConverter))]
    public struct CondenserApiErrorDataWrapper
    {
        public string? Raw { get; set; }
        public CondenserApiErrorData Data { get; set; }
    }
}