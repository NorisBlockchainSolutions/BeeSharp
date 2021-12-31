#nullable enable
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    [JsonConverter(typeof(OperationJsonConverter))]
    public class BroadcastOpModel
    {
        public string Name { get; set; }
        public BroadcastOperation? Operation { get; set; }
        
        public string? RawOperation { get; set; }
        
        public BroadcastOpModel(string name, BroadcastOperation? operation)
        {
            Name = name;
            Operation = operation;
            RawOperation = null;
        }
        
        public BroadcastOpModel(string name, string operation)
        {
            Name = name;
            Operation = null;
            RawOperation = operation;
        }
    }
}