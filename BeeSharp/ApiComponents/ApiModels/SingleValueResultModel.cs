using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api;

namespace BeeSharp.ApiComponents.ApiModels
{
    [JsonConverter(typeof(SingleValueResultJsonConverter))]
    public class SingleValueResultModel<T>
    {
        public SingleValueResultModel(T? value)
        {
            Value = value;
        }

        public T? Value { get; }
    }
}