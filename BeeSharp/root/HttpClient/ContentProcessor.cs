using System.Net.Http;
using System.Text;
using System.Text.Json;
using BeeSharp.ApiCall.ApiWebCalls.WebClient.Processing;

namespace BeeSharp.root.HttpClient
{
    public class ContentProcessor : IContentProcessor
    {
        /// <summary>
        ///     Create a StringContent from a class by json serializing it.
        /// </summary>
        /// <param name="apiParams">The parameter class that should be serialized.</param>
        /// <typeparam name="T">The type of the apiParams class.</typeparam>
        /// <returns>The serialized StringContent.</returns>
        public StringContent GetRequestBodyContent<T>(T? apiParams)
        {
            var result = "";
            if (apiParams != null) result = JsonSerializer.Serialize(apiParams);

            var resultContent = new StringContent(result, Encoding.Default, "application/json");
            return resultContent;
        }
    }
}