using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson
{
    namespace follow
    {
        [CustomJsonOpId("follow", typeof(ArrayShapedCustomJsonModel))]
        [CustomJsonOpListOp("follow")]
        public class CustomJsonOpFollowModel : CustomJsonOperation
        {
            public CustomJsonOpFollowModel(string follower, ObjectListOrObjectWrapperModel<string> following,
                string[] what)
            {
                Follower = follower;
                Following = following;
                What = what;
            }

            [JsonPropertyName("follower")] public string Follower { get; }

            [JsonPropertyName("following")] public ObjectListOrObjectWrapperModel<string> Following { get; }

            [JsonPropertyName("what")] public string[] What { get; }
        }
    }
}