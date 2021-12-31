using System.Text.Json.Serialization;
using BeeSharp.ApiCall.ApiWebCalls;

namespace BeeSharp.ApiComponents.ApiModels
{
    /// <summary>
    ///     Represents the answer to an empty GET/POST request to a CondenserApiHive API
    /// </summary>
    public struct InfoMessageResponseModel : IWebRequestModel
    {
        [JsonPropertyName("jussi_num")] public NumberOrStringModel JussiNum { get; init; }

        [JsonPropertyName("status")] public string Status { get; init; }

        public string RawRequest { get; set; }

        public string RawResponse { get; set; }
        public string NodeUrl { get; set; }
    }
}