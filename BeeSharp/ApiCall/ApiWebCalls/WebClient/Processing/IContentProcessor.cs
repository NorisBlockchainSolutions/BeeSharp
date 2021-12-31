using System.Net.Http;

namespace BeeSharp.ApiCall.ApiWebCalls.WebClient.Processing
{
    public interface IContentProcessor
    {
        /// <summary>
        ///     Create a StringContent from a class by json serializing it.
        /// </summary>
        /// <param name="apiParams">The parameter class that should be serialized.</param>
        /// <typeparam name="T">The type of the apiParams class.</typeparam>
        /// <returns>The serialized StringContent.</returns>
        StringContent GetRequestBodyContent<T>(T? apiParams);
    }
}