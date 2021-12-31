using System;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking;
using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.ApiComponents.Condenser.ErrorResponse;
using BeeSharp.root.DebugInfoProvider;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiComponents.Condenser
{
    public class CondenserResponseVerifier : ICondenserResponseVerifier
    {
        private readonly IApiNodeRankingManager _apiNodeRankingManager;

        public CondenserResponseVerifier(IApiNodeRankingManager apiNodeRankingManager)
        {
            _apiNodeRankingManager = apiNodeRankingManager;
        }

        /// <summary>
        /// Check the result for error responses and throw according errors
        /// </summary>
        /// <param name="apiResponse">The apiResponse to check</param>
        /// <typeparam name="TU">The type of the api response object.</typeparam>
        /// <exception cref="CondenserApiException">Thrown when the result contains an error code or is empty.</exception>
        /// <exception cref="TimeoutException">Thrown when the node timeouts on request.</exception>
        /// <exception cref="ApiNodeTimeoutException">Thrown when too many requests are made in a short time
        /// interval.</exception>
        /// <exception cref="ApiNodeErrorException">Thrown when the node is malfunctioning.</exception>
        public async Task CheckCondenserApiCallResultAsync<TU>(CondenserApiResponse<TU> apiResponse)
            where TU : class
        {
            // Check response for errors
            if (apiResponse.Error.Code != 0)
            {
                try
                {
                    CondenserErrorResponseDirector.HandleErrorResponse(apiResponse.Error, apiResponse.RawRequest,
                        apiResponse.RawResponse);
                }
                catch (ApiNodeTimeoutException e)
                {
                    // Node timeout
                    ConnectionErrorInfoProvider.OnConnectionError(this,
                        new ConnectionErrorEventArgs(apiResponse.NodeUrl, e.ToString()));
                    
                    // Un-rank node until next re-ranking
                    await _apiNodeRankingManager.RemoveUrlFromCurrentRankingAsync(apiResponse.NodeUrl);
                    throw;
                }
                catch (ApiNodeErrorException e)
                {
                    // Node server error
                    ConnectionErrorInfoProvider.OnConnectionError(this,
                        new ConnectionErrorEventArgs(apiResponse.NodeUrl, e.ToString()));
                    
                    // Un-rank node until next re-ranking
                    await _apiNodeRankingManager.RemoveUrlFromCurrentRankingAsync(apiResponse.NodeUrl);
                    throw;
                }
                
                var exception = new CondenserApiException(
                    $"{apiResponse.NodeUrl} returned error code {apiResponse.Error.Code}!");
                ConnectionErrorInfoProvider.OnConnectionError(this,
                    new ConnectionErrorEventArgs(apiResponse.NodeUrl, exception.ToString()));
                throw exception;
            }
            if (apiResponse.Result is null)
            {
                // Node server empty response
                // Un-rank node until next re-ranking
                await _apiNodeRankingManager.RemoveUrlFromCurrentRankingAsync(apiResponse.NodeUrl);
                
                var exception = new CondenserApiException($"{apiResponse.NodeUrl} returned empty result!");
                ConnectionErrorInfoProvider.OnConnectionError(this,
                    new ConnectionErrorEventArgs(apiResponse.NodeUrl, exception.ToString()));
                throw exception;
            }
        }
    }
}