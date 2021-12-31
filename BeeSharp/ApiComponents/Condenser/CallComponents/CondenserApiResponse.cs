using System.Text.Json.Serialization;
using BeeSharp.ApiCall.ApiWebCalls;
using BeeSharp.ApiComponents.ApiModels;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api;

namespace BeeSharp.ApiComponents.Condenser.CallComponents
{
    /// <summary>
    ///     Represents the JSON-Object containing an API-Response
    /// </summary>
    /// <typeparam name="T">The class/struct representing the inner result</typeparam>
    public class CondenserApiResponse<T> : IWebRequestModel where T : class
    {
        public CondenserApiResponse(NumberOrStringModel id, string jsonRpc, T? result, CondenserApiErrorResponse error,
            string rawRequest, string rawResponse, string nodeUrl)
        {
            Id = id;
            JsonRpc = jsonRpc;
            Result = result;
            Error = error;
            RawRequest = rawRequest;
            RawResponse = rawResponse;
            NodeUrl = nodeUrl;
        }

        [JsonPropertyName("jsonrpc")] public string JsonRpc { get; }

        [JsonPropertyName("result")]
        [JsonConverter(typeof(NullOrElementJsonConverter))]
        public T? Result { get; }

        [JsonPropertyName("error")] public CondenserApiErrorResponse Error { get; }

        [JsonIgnore] public string RawRequest { get; set; }

        [JsonIgnore] public string RawResponse { get; set; }
        
        [JsonIgnore] public string NodeUrl { get; set; }

        [JsonPropertyName("id")] public NumberOrStringModel Id { get; }
    }
}