using System;

namespace BeeSharp.ApiCall.ApiWebCalls.WebClient.Processing
{
    public interface IUriCreator
    {
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public Uri GetTargetUri(string? baseUrl, string urlParams = "");
    }
}