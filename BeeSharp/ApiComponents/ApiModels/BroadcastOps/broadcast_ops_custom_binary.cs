using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace custom_binary
    {
        [BroadcastOp("custom_binary")]
        public class BroadcastOpCustomBinaryModel : BroadcastOperation
        {
            /// <summary>
            ///     Custom content operation for binary data. Cheaper alternative to custom_json.
            /// </summary>
            /// <param name="id">custom binary operation id.</param>
            /// <param name="data">The binary data.</param>
            public BroadcastOpCustomBinaryModel(NumberOrStringModel id, string data)
            {
                Id = id;
                Data = data;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }
            [JsonPropertyName("data")] public string Data { get; }
        }
    }
}