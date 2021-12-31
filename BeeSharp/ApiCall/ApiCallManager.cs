#nullable enable
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking;
using BeeSharp.ApiCall.ApiUrlForSingleRequest;
using BeeSharp.ApiCall.ApiWebCalls;
using BeeSharp.ApiCall.ApiWebCalls.WebClient;
using BeeSharp.root.DebugInfoProvider;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiCall
{
    /// <summary>
    ///     Abstracts all interactions with a CondenserApiHive REST-API
    /// </summary>
    public class ApiCallManager : IApiCallManager
    {
        private readonly IApiNodeRankingManager _apiNodeRankingManager;
        private readonly ISingleApiUrlHandler _singleApiUrlHandler;
        private readonly IWebClientAdapter _webClientAdapter;
        private readonly ApiCallContext _apiCallContext;

        private readonly IWebClientFactory _webClientFactory;

        /// <summary>
        ///     Create a new instance of ApiCallManager.
        ///     INITIALIZE THE INSTANCE WITH InitializeAsync() BEFORE USING!
        /// </summary>
        public ApiCallManager(IApiNodeRankingManager apiNodeRankingManager, ISingleApiUrlHandler singleApiUrlHandler,
            IWebClientFactory webClientFactory, IWebClientAdapter webClientAdapter,
            ApiCallContext apiCallContext)
        {
            _apiNodeRankingManager = apiNodeRankingManager;
            _singleApiUrlHandler = singleApiUrlHandler;
            _webClientFactory = webClientFactory;
            _webClientAdapter = webClientAdapter;
            _apiCallContext = apiCallContext;
        }
        
        /// <summary>
        /// Initializes the instance for use.
        /// </summary>
        public async Task InitializeAsync()
        {
            await _apiNodeRankingManager.RunInitialApiNodeRankingAsync();
        }

        public async Task UpdateApiNodeRankingAsync()
        {
            await _apiNodeRankingManager.UpdateApiNodeRankingAsync();
        }

        private async Task<WebClientCall> GetSingleRequestWebCallAsync(string urlParams = "")
        {
            var apiUrls = _apiNodeRankingManager.GetCurrentTimedApiNodes();

            var baseUrl = await _singleApiUrlHandler.GetApiUrlAsync(apiUrls);
            var client = _webClientFactory.Create(baseUrl, _apiCallContext.WebRequestTimeout);

            return new WebClientCall(client, urlParams);
        }

        /// <summary>
        ///     Calls the REST-API using GET
        /// </summary>
        /// <typeparam name="T">The class/struct build upon the structure of the JSON-Object</typeparam>
        /// <param name="urlParams">The parameters to append to the URL</param>
        /// <returns>The class/struct build upon the structure of the JSON-Object</returns>
        /// <exception cref="JsonException">Thrown when the result cannot be converted to T.</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public async Task<T?> GetApiCallAsync<T>(string urlParams = "") where T : IWebRequestModel
        {
            var call = await GetSingleRequestWebCallAsync(urlParams);
            return await _webClientAdapter.GetApiCallAsync<T>(call);
        }

        /// <summary>
        ///     Calls the REST-API using GET
        /// </summary>
        /// <param name="urlParams">The parameters to append to the URL</param>
        /// <returns>The received JSON-Object as string</returns>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public async Task<string> GetApiCallAsync(string urlParams = "")
        {
            var call = await GetSingleRequestWebCallAsync(urlParams);
            return await _webClientAdapter.GetApiCallAsync(call);
        }

        /// <summary>
        ///     Calls the REST-API using POST
        /// </summary>
        /// <typeparam name="T">The type of the JSON-Object passed as apiParams input.</typeparam>
        /// <typeparam name="TU">The class/struct build upon the structure of the JSON-Object</typeparam>
        /// <param name="apiParams">The HiveApiCallModel-JSON struct containing POST parameters</param>
        /// <param name="urlParams">Additional (GET)-Parameters passed via url parameter.</param>
        /// <returns>The class/struct build upon the structure of the JSON-Object</returns>
        /// <exception cref="JsonException">Thrown when the result cannot be converted to T.</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public async Task<TU?> PostApiCallAsync<T, TU>(T apiParams, string urlParams = "") where TU : IWebRequestModel
        {
            Exception? exception = null;
            // Repeat until exception is thrown or successful
            // This is done to prevent failure of a few nodes from disturbing the network traffic.
            for (var i = 0; i < _apiCallContext.MaxConnectionRetries; i++)
            {
                var call = await GetSingleRequestWebCallAsync(urlParams);
                try
                {
                    var result = await _webClientAdapter.PostApiCallAsync<T, TU>(call, apiParams);
                    if (result is not null)
                        result.NodeUrl = call.WebClientProxy!.BaseUrl;

                    return result;
                }
                catch (HttpRequestException e)
                {
                    exception = e;
                    ConnectionErrorInfoProvider.OnConnectionError(this,
                        new ConnectionErrorEventArgs(call.WebClientProxy!.BaseUrl, e.ToString()));

                    // This node has a httpConnectionError
                    // Either all nodes have (in case of an invalid request), or just this one
                    // Disable the connection and do another attempt with a different node
                    // If the other attempts also fail, the request is probably faulty and user interaction is needed.
                    await _apiNodeRankingManager.RemoveUrlFromCurrentRankingAsync(call.WebClientProxy!.BaseUrl);
                }
                catch (TimeoutException e)
                {
                    exception = e;
                    ConnectionErrorInfoProvider.OnConnectionError(this,
                        new ConnectionErrorEventArgs(call.WebClientProxy!.BaseUrl, e.ToString()));

                    // Either all connections are lost, or only this node is
                    // Disable the connection and do another attempt with a different node
                    // If the other attempts also fail, all connections are probably dropped and a re-ranking is needed.
                    await _apiNodeRankingManager.RemoveUrlFromCurrentRankingAsync(call.WebClientProxy!.BaseUrl);
                }
            }

            // Throw exception, if MaxRetries passed
            if (exception is null)
                // This case should never happen, since only TimeoutExceptions are caught.
                throw new CondenserApiException("ApiCallManager is in an invalid state!");
            throw exception;
        }

        /// <summary>
        ///     Calls the REST-API using POST.
        /// </summary>
        /// <typeparam name="T">The type of the JSON-Object passed as apiParams input.</typeparam>
        /// <param name="apiParams">The HiveApiCallModel-JSON struct containing POST parameters</param>
        /// <param name="urlParams">Additional (GET)-Parameters passed via url parameter.</param>
        /// <returns>The received JSON-Object as string</returns>
        public async Task<string> PostApiCallAsync<T>(T apiParams, string urlParams = "")
        {
            var call = await GetSingleRequestWebCallAsync(urlParams);
            return await _webClientAdapter.PostApiCallAsync(call, apiParams);
        }
    }
}