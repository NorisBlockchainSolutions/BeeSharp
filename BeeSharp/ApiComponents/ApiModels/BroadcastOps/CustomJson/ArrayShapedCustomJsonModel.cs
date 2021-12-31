using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson
{
    [CustomJsonOpId("community")]
    [JsonConverter(typeof(ArrayShapedCustomJsonJsonConverter))]
    public class ArrayShapedCustomJsonModel : CustomJsonOperation
    {
        public ArrayShapedCustomJsonModel(string name, CustomJsonOperation operation)
        {
            Name = name;
            Operation = operation;
        }

        public string Name { get; }
        public CustomJsonOperation? Operation { get; }
    }
}