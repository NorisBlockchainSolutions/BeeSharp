using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace prove_authority
    {
        [BroadcastOp("prove_authority")]
        public class BroadcastOpProveAuthorityModel : BroadcastOperation
        {
            [JsonPropertyName("challenged")] public object Challenged { get; }

            [JsonPropertyName("require_owner")] public object RequireOwner { get; }
        }
    }
}