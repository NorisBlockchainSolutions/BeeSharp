using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels
{
    /// <summary>
    ///     Represents the JSON-Object used for API-Calls to a CondenserApiHive API
    /// </summary>
    public class HiveApiCallModel<T>
    {
        [JsonPropertyName("jsonrpc")] public string JsonRpc { get; }
        [JsonPropertyName("method")] public string Method { get; }
        [JsonPropertyName("params")] public T[] Params { get; }
        [JsonPropertyName("id")] public long Id { get; }

        public HiveApiCallModel(string method = "", T[] @params = null!, string jsonRpc = "2.0", long id = 1)
        {
            JsonRpc = jsonRpc;
            Method = method;
            Id = id;

            Params = @params ?? Array.Empty<T>();
        }
    }
}