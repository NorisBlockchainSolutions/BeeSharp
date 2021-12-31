using System.Text.Json;
using BeeSharp.ApiCall.ApiWebCalls;

namespace BeeSharp.root
{
    public class JsonSerializerOptionsProvider : IJsonSerializerOptionsProvider
    {
        public JsonSerializerOptions Get()
        {
            var options = new JsonSerializerOptions();
            // Currently no options need to be changed.
            // This is included for future adjustments.
            return options;
        }
    }
}