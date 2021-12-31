using System;
using BeeSharp.ApiCall.ApiWebCalls.WebClient;

#nullable disable
namespace BeeSharp.ApiCall.ApiWebCalls
{
    public readonly struct WebClientCall
    {
        public IWebClientProxy WebClientProxy { get; }
        public string UrlParams { get; }

        public WebClientCall(IWebClientProxy webClientProxy, string urlParams = "")
        {
            WebClientProxy = webClientProxy ?? throw new ArgumentNullException();
            UrlParams = urlParams ?? "";
        }

        public void Deconstruct(out IWebClientProxy webClientProxy, out string urlParams)
        {
            webClientProxy = WebClientProxy;
            urlParams = string.IsNullOrWhiteSpace(UrlParams) ? "" : UrlParams;
        }
    }
}