using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson
{
    [JsonConverter(typeof(ObjectListOrObjectWrapperJsonConverterFactory))]
    public class ObjectListOrObjectWrapperModel<T> : CustomJsonOperation
    {
        public T[] Transactions { get; }

        public ObjectListOrObjectWrapperModel(T[] transactions)
        {
            Transactions = transactions;
        }
    }
}