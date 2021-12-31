using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking;
using BeeSharp.ApiCall.ApiUrlForSingleRequest;
using BeeSharp.ApiCall.ApiWebCalls;
using BeeSharp.ApiCall.ApiWebCalls.WebClient;

namespace BeeSharp.ApiCall
{
    public interface IApiCallManager
    {
        /// <summary>
        /// Initializes the current instance. THIS NEEDS TO BE RUN BEFORE USING APICALLMANAGER!
        /// </summary>
        public Task InitializeAsync();
        
        Task UpdateApiNodeRankingAsync();

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
        Task<T?> GetApiCallAsync<T>(string urlParams = "") where T : IWebRequestModel;

        /// <summary>
        ///     Calls the REST-API using GET
        /// </summary>
        /// <param name="urlParams">The parameters to append to the URL</param>
        /// <returns>The received JSON-Object as string</returns>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="TimeoutException">Thrown when the target apiNode is not reachable.</exception>
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        Task<string> GetApiCallAsync(string urlParams = "");

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
        public Task<TU?> PostApiCallAsync<T, TU>(T apiParams, string urlParams = "") where TU : IWebRequestModel;

        /// <summary>
        ///     Calls the REST-API using POST.
        /// </summary>
        /// <typeparam name="T">The type of the JSON-Object passed as apiParams input.</typeparam>
        /// <param name="apiParams">The HiveApiCallModel-JSON struct containing POST parameters</param>
        /// <param name="urlParams">Additional (GET)-Parameters passed via url parameter.</param>
        /// <returns>The received JSON-Object as string</returns>
        Task<string> PostApiCallAsync<T>(T apiParams, string urlParams = "");
    }
}