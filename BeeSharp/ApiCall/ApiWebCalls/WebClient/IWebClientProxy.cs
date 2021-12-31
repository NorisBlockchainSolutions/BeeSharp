using System.Net.Http;
using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiWebCalls.WebClient
{
    public interface IWebClientProxy
    {
        public string BaseUrl { get; }
        
        /// <summary>
        ///     Get the HttpContent from a Http Get request.
        /// </summary>
        /// <param name="urlParams">The request parameters passed inside the url.</param>
        /// <returns>The HttpContent of the request.</returns>
        public Task<HttpContent> GetWebCallContentAsync(string? urlParams = "");

        /// <summary>
        ///     Get the HttpContent from a Http Post request.
        /// </summary>
        /// <typeparam name="T">The type variable of the class containing the apiParams.</typeparam>
        /// <param name="urlParams">The request parameters passed inside the url.</param>
        /// <param name="webParams">The api parameters to pass in the post request body.</param>
        /// <returns>The HttpContent of the request.</returns>
        public Task<HttpContent> PostWebCallContentAsync<T>(T webParams, string? urlParams = "");
    }
}