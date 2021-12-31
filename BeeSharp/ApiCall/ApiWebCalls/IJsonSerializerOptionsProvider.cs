using System.Text.Json;

namespace BeeSharp.ApiCall.ApiWebCalls
{
    public interface IJsonSerializerOptionsProvider
    {
        public JsonSerializerOptions Get();
    }
}