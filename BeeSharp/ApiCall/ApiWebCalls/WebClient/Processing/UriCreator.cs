using System;

namespace BeeSharp.ApiCall.ApiWebCalls.WebClient.Processing
{
    public class UriCreator : IUriCreator
    {
        /// <exception cref="UriFormatException">Thrown when no uri can be created from apiUrl and urlParams.</exception>
        public Uri GetTargetUri(string? baseUrl, string urlParams = "")
        {
            return new(Uri.EscapeUriString($"{baseUrl}{urlParams}"));
        }
    }
}