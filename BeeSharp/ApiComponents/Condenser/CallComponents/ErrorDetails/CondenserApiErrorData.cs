using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.Condenser.CallComponents.ErrorDetails
{
    public class CondenserApiErrorData
    {
        public CondenserApiErrorData(int code, string name, string message, List<CondenserApiErrorStackElement> stack)
        {
            Code = code;
            Name = name;
            Message = message;
            Stack = stack;
        }

        [JsonPropertyName("code")] public int Code { get; }

        [JsonPropertyName("name")] public string Name { get; }

        [JsonPropertyName("message")] public string Message { get; }

        [JsonPropertyName("stack")] public List<CondenserApiErrorStackElement> Stack { get; }
    }
}