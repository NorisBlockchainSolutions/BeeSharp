using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using BeeSharp.ApiCall.ApiWebCalls.WebClient;
using BeeSharp.ApiCall.ApiWebCalls.WebClient.Processing;

namespace BeeSharp.root.HttpClient
{
    public class HttpClientFactory : IWebClientFactory
    {
        private readonly IContentProcessor _contentProcessor;
        private readonly IUriCreator _uriCreator;

        public HttpClientFactory(IUriCreator uriCreator, IContentProcessor contentProcessor)
        {
            _uriCreator = uriCreator;
            _contentProcessor = contentProcessor;
        }

        /// <param name="baseUrl">The base apiNode url.</param>
        /// <param name="timeout">The timeout of a client request in seconds.</param>
        public IWebClientProxy Create(string? baseUrl, ushort timeout)
        {
            var client = new System.Net.Http.HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            if (!string.IsNullOrWhiteSpace(baseUrl)) client.BaseAddress = _uriCreator.GetTargetUri(baseUrl);

            client.Timeout = TimeSpan.FromSeconds(timeout);

            var proxy = new HttpClientProxy(_uriCreator, _contentProcessor, client, baseUrl ?? "");

            return proxy;
        }
    }
}