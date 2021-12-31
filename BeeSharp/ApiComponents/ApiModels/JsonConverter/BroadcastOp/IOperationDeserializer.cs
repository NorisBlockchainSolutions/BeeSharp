namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public interface IOperationDeserializer
    {
        object DeserializeOperation(string operationName, string json);
    }
}