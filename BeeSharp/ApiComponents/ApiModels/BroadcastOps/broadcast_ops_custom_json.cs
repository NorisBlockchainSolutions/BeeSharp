using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace custom_json
    {
        [BroadcastOp("custom_json")]
        [JsonConverter(typeof(BroadcastOpCustomJsonJsonConverter))]
        public class BroadcastOpCustomJsonModel : BroadcastOperation, ISerializableOperation
        {
            public BroadcastOpCustomJsonModel(string[]? requiredAuths, string[]? requiredPostingAuths,
                string id, CustomJsonWrapperModel json)
            {
                RequiredAuths = requiredAuths ?? Array.Empty<string>();
                RequiredPostingAuths = requiredPostingAuths ?? Array.Empty<string>();
                Id = id;
                Json = json;
            }

            [JsonPropertyName("required_auths")] public string[] RequiredAuths { get; }

            [JsonPropertyName("required_posting_auths")]
            public string[] RequiredPostingAuths { get; }

            [JsonPropertyName("id")] public string Id { get; }

            [JsonPropertyName("json")] public CustomJsonWrapperModel Json { get; }

            public byte[] SerializeOperation()
            {
                var result = new MemoryStream();
                var writer = new BinaryWriter(result, Encoding.UTF8);

                writer.Write((byte) RequiredAuths.Length);
                if (RequiredAuths.Length > 0)
                    foreach (var auth
                        in RequiredAuths.OrderBy(auth => auth))
                        writer.Write(auth!);

                writer.Write((byte) RequiredPostingAuths.Length);
                if (RequiredPostingAuths.Length > 0)
                    foreach (var auth
                        in RequiredPostingAuths.OrderBy(auth => auth))
                        writer.Write(auth!);

                writer.Write(Id);
                writer.Write(Json.RawResponse);

                return result.ToArray();
            }

            public HivedOperationId GetOperationId()
            {
                return HivedOperationId.custom_json;
            }

            public string GetOperationName()
            {
                return "custom_json";
            }

            public object GetOperationModel()
            {
                return this;
            }
        }
    }
}