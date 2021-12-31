using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace custom
    {
        [BroadcastOp("custom")]
        public class BroadcastOpCustomModel: BroadcastOperation
        {
            /// <summary>
            ///     Generic way to add higher level protocols. No witness-side validation other than required auths are
            ///     valid!
            /// </summary>
            /// <param name="requiredAuths">The accounts whose authorization is required.</param>
            /// <param name="id">Custom operation id.</param>
            /// <param name="data">The data inside the operation.</param>
            public BroadcastOpCustomModel(string[] requiredAuths, NumberOrStringModel id, string data)
            {
                RequiredAuths = requiredAuths;
                Id = id;
                Data = data;
            }

            [JsonPropertyName("required_auths")] public string[] RequiredAuths { get; }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("data")] public string Data { get; }
        }
    }
}