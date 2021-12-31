namespace BeeSharp.ApiCall.ApiWebCalls.WebClient
{
    public interface IWebClientFactory
    {
        /// <param name="baseUrl">The base apiNode url.</param>
        /// <param name="timeout">The timeout of a client request in seconds.</param>
        IWebClientProxy Create(string? baseUrl, ushort timeout);
    }
}