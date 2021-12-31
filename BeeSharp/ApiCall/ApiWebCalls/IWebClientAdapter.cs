using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiWebCalls
{
    public interface IWebClientAdapter
    {
        /// <summary>
        ///     Calls the REST-API using GET
        /// </summary>
        /// <typeparam name="T">The class/struct build upon the structure of the JSON-Object</typeparam>
        /// <returns>The class/struct build upon the structure of the JSON-Object</returns>
        /// <exception cref="JsonException">Thrown when the result cannot be converted to T.</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        Task<T?> GetApiCallAsync<T>(WebClientCall call) where T : IWebRequestModel;

        /// <summary>
        ///     Calls the REST-API using GET
        /// </summary>
        /// <returns>The received JSON-Object as string</returns>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        Task<string> GetApiCallAsync(WebClientCall call);

        /// <summary>
        ///     Calls the REST-API using POST
        /// </summary>
        /// <typeparam name="T">The type of the JSON-Object passed as apiParams input.</typeparam>
        /// <typeparam name="TU">The class/struct build upon the structure of the JSON-Object</typeparam>
        /// <param name="call">The web call parameters.</param>
        /// <param name="apiParams">The HiveApiCallModel-JSON struct containing POST parameters</param>
        /// <returns>The class/struct build upon the structure of the JSON-Object</returns>
        /// <exception cref="JsonException">Thrown when the result cannot be converted to T.</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public Task<TU?> PostApiCallAsync<T, TU>(WebClientCall call, T apiParams) where TU : IWebRequestModel;

        /// <summary>
        ///     Calls the REST-API using POST.
        /// </summary>
        /// <typeparam name="T">The type of the JSON-Object passed as apiParams input.</typeparam>
        /// <param name="apiParams">The HiveApiCallModel-JSON struct containing POST parameters</param>
        /// <param name="call">The web call parameters.</param>
        /// <returns>The received JSON-Object as string</returns>
        Task<string> PostApiCallAsync<T>(WebClientCall call, T apiParams);
    }
}