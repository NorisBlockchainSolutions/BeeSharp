using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.Condenser.CallComponents.ErrorDetails
{
    public class CondenserApiErrorStackElement
    {
        public CondenserApiErrorStackElement(CondenserApiErrorStackElementContext context, string format,
            dynamic data)
        {
            Context = context;
            Format = format;
            Data = data;
        }

        [JsonPropertyName("context")] public CondenserApiErrorStackElementContext Context { get; }
        [JsonPropertyName("format")] public string Format { get; }
        [JsonPropertyName("data")] public dynamic Data { get; }
    }
}