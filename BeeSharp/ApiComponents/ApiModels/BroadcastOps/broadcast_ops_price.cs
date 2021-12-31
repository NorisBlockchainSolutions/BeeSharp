using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    [BroadcastOp("price")]
    public class ExchangeRateModel : BroadcastOperation
    {
        public ExchangeRateModel(string @base, string quote)
        {
            Base = @base;
            Quote = quote;
        }

        [JsonPropertyName("base")] public string Base { get; }

        [JsonPropertyName("quote")] public string Quote { get; }
    }
}