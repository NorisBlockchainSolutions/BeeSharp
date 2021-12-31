using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiWebCalls.WebClient;
using BeeSharp.ApiCall.ApiWebCalls.WebClient.Processing;

namespace BeeSharp.root.HttpClient
{
    public class HttpClientProxy : IWebClientProxy
    {
        public string BaseUrl { get; }
        private readonly System.Net.Http.HttpClient _client;
        private readonly IContentProcessor _contentProcessor;
        private readonly IUriCreator _uriCreator;

        /// <summary>
        ///     Create a new WebClient.
        /// </summary>
        public HttpClientProxy(IUriCreator uriCreator, IContentProcessor contentProcessor,
            System.Net.Http.HttpClient client, string baseUrl)
        {
            _uriCreator = uriCreator;
            _contentProcessor = contentProcessor;
            _client = client;
            BaseUrl = baseUrl;
        }


        /// <summary>
        ///     Get the HttpContent from a Http Get request.
        /// </summary>
        /// <param name="urlParams">The request parameters passed inside the url.</param>
        /// <returns>The HttpContent of the request.</returns>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public async Task<HttpContent> GetWebCallContentAsync(string? urlParams = "")
        {
            var targetUri = _uriCreator.GetTargetUri(BaseUrl, urlParams ?? "");
            var response = await _client.GetAsync(targetUri);
            AssertResponseSuccess(response);

            return response.Content;
        }

        /// <summary>
        ///     Get the HttpContent from a Http Post request.
        /// </summary>
        /// <typeparam name="T">The type variable of the class containing the apiParams.</typeparam>
        /// <param name="webParams">The api parameters to pass in the post request body.</param>
        /// <param name="urlParams">The request parameters passed inside the url.</param>
        /// <returns>The HttpContent of the request.</returns>
        /// <exception cref="JsonException">Thrown when the result cannot be converted to T.</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public async Task<HttpContent> PostWebCallContentAsync<T>(T webParams, string? urlParams)
        {
            var targetUri = _uriCreator.GetTargetUri(BaseUrl, urlParams ?? "");
            var content = _contentProcessor.GetRequestBodyContent(webParams);

            try
            {
                var response = await _client.PostAsync(targetUri, content);
                AssertResponseSuccess(response);

                return response.Content;
            }
            catch (TaskCanceledException e)
            {
                if (e.InnerException is TimeoutException)
                    throw e.InnerException;
                throw new TimeoutException(e.ToString());
            }
        }

        private static void AssertResponseSuccess(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Unable to fulfill request! Returned {response.StatusCode}");
        }
    }
}