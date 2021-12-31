using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiWebCalls
{
    public class WebClientAdapter : IWebClientAdapter
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public WebClientAdapter(IJsonSerializerOptionsProvider jsonSerializerOptionsProvider)
        {
            _jsonSerializerOptions = jsonSerializerOptionsProvider.Get();
        }

        /// <summary>
        ///     Calls the REST-API using GET
        /// </summary>
        /// <typeparam name="T">The class/struct build upon the structure of the JSON-Object</typeparam>
        /// <returns>The class/struct build upon the structure of the JSON-Object</returns>
        /// <exception cref="JsonException">Thrown when the result cannot be converted to T.</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public async Task<T?> GetApiCallAsync<T>(WebClientCall call) where T : IWebRequestModel
        {
            var (webClientProxy, urlParams) = call;
            if (webClientProxy == null || urlParams == null) throw new ArgumentNullException();

            var response = await webClientProxy.GetWebCallContentAsync(urlParams);
            var result = await JsonSerializer.DeserializeAsync<T>(await response.ReadAsStreamAsync(),
                _jsonSerializerOptions);

            // Add raw request data
            if (result is not null)
            {
                result.RawRequest = JsonSerializer.Serialize(urlParams);
                result.RawResponse = await response.ReadAsStringAsync();
            }

            return result;
        }

        /// <summary>
        ///     Calls the REST-API using GET
        /// </summary>
        /// <returns>The received JSON-Object as string</returns>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public async Task<string> GetApiCallAsync(WebClientCall call)
        {
            var (webClientProxy, urlParams) = call;
            if (webClientProxy == null || urlParams == null) throw new ArgumentNullException();

            var response = await webClientProxy.GetWebCallContentAsync(urlParams);
            return await response.ReadAsStringAsync();
        }

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
        public async Task<TU?> PostApiCallAsync<T, TU>(WebClientCall call, T apiParams) where TU : IWebRequestModel
        {
            var (webClientProxy, urlParams) = call;
            if (webClientProxy == null || urlParams == null) throw new ArgumentNullException();

            var response = await webClientProxy.PostWebCallContentAsync(apiParams, urlParams);
            var result = await JsonSerializer.DeserializeAsync<TU>(await response.ReadAsStreamAsync(),
                _jsonSerializerOptions);

            // Add raw request data
            if (result is not null)
            {
                result.RawRequest = JsonSerializer.Serialize(urlParams);
                result.RawResponse = await response.ReadAsStringAsync();
            }

            return result;
        }

        /// <summary>
        ///     Calls the REST-API using POST.
        /// </summary>
        /// <typeparam name="T">The type of the JSON-Object passed as apiParams input.</typeparam>
        /// <param name="apiParams">The HiveApiCallModel-JSON struct containing POST parameters</param>
        /// <param name="call">The web call parameters.</param>
        /// <returns>The received JSON-Object as string</returns>
        public async Task<string> PostApiCallAsync<T>(WebClientCall call, T? apiParams)
        {
            var (webClientProxy, urlParams) = call;
            if (webClientProxy == null || urlParams == null) throw new ArgumentNullException();

            var response = await webClientProxy.PostWebCallContentAsync(apiParams, urlParams);
            return await response.ReadAsStringAsync();
        }
    }
}