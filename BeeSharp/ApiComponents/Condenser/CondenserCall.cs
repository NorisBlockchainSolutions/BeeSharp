using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BeeSharp.ApiCall;
using BeeSharp.ApiComponents.ApiModels;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_chain_properties;
using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.Auth.Provider;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiComponents.Condenser
{
    public class CondenserCall : ICondenserCall
    {
        private readonly IApiCallManager _apiCallManager;
        private readonly ICondenserResponseVerifier _condenserResponseVerifier;
        private readonly CondenserCallContext _condenserCallContext;

        public CondenserCall(IApiCallManager apiCallManager, ICondenserResponseVerifier condenserResponseVerifier,
            BlockChainParametersContext blockChainParametersContext, CondenserCallContext condenserCallContext)
        {
            _apiCallManager = apiCallManager;
            _condenserResponseVerifier = condenserResponseVerifier;
            _condenserCallContext = condenserCallContext;

            // Set blockchain parameters
            // Done, so that all condenser calls can rely on set chainProperties.
            // If ChainProperties are needed without calling condenser first, they need to be set accordingly
            // (e.g for Key management)
            var chainProperties = GetCondenserApiCallResultAsync(
                new CondenserApiGetChainProperties()).Result;
            ChainParameterProvider.RegisterNew(chainProperties.AccountCreationFee, blockChainParametersContext);
        }

        /// <summary>
        ///     Get all information and results of a condenser api call.
        /// </summary>
        /// <typeparam name="T">The type of the parameter object.</typeparam>
        /// <typeparam name="TU">The type of the api response object.</typeparam>
        /// <param name="apiCall">The apiCall to make.</param>
        /// <returns>The response object.</returns>
        /// <exception cref="TimeoutException">Thrown when the node timeouts on request.</exception>
        /// <exception cref="HttpRequestException">Thrown when the HTTP request is invalid or unsuccessful.</exception>
        /// <exception cref="JsonException">Thrown when the result cannot be parsed to existing json objects.</exception>
        public async Task<CondenserApiResponse<TU>> GetRawCondenserApiCallAsync<T, TU>(ICondenserApiCall<T, TU> apiCall)
            where TU : class
        {
            HiveApiCallModel<T> apiCallModel;

            apiCallModel = apiCall.QueryParametersJson != null
                ? new HiveApiCallModel<T>(apiCall.MethodName, apiCall.QueryParametersJson)
                : new HiveApiCallModel<T>(apiCall.MethodName);

            var result =
                await _apiCallManager.PostApiCallAsync<HiveApiCallModel<T>, CondenserApiResponse<TU>>(apiCallModel);

            if (result is null) throw new JsonException();
            result.RawRequest = JsonSerializer.Serialize(apiCallModel);

            return result;
        }

        /// <summary>
        ///     Get the result of a condenser api call.
        /// </summary>
        /// <typeparam name="T">The type of the parameter object.</typeparam>
        /// <typeparam name="TU">The type of the api response object.</typeparam>
        /// <param name="apiCall">The apiCall to make.</param>
        /// <returns>The response object.</returns>
        /// <exception cref="TimeoutException">Thrown when the node timeouts on request.</exception>
        /// <exception cref="ApiNodeTimeoutException">Thrown when too many requests are made in a short time
        /// interval.</exception>
        /// <exception cref="JsonException">Thrown when the result cannot be parsed to existing json objects.</exception>
        public async Task<TU> GetCondenserApiCallResultAsync<T, TU>(ICondenserApiCall<T, TU> apiCall)
            where TU : class
        {
            Exception? exception = null;
            for (var i = 0; i < _condenserCallContext.MaxRequestRetries; i++)
            {
                try
                {
                    var result = await GetRawCondenserApiCallAsync(apiCall);
                    await _condenserResponseVerifier.CheckCondenserApiCallResultAsync(result);
                    return result.Result!;
                }
                // We do not catch TimeoutException, since ApiCallManager already tried until MaxConnectionRetries was
                // reached
                // We do not catch ApiNodeTimeoutException either, since that usually means that too many requests were
                // made within a small amount of time.
                catch (ApiNodeErrorException e)
                {
                    exception = e;
                }
                catch (CondenserApiException e)
                {
                    exception = e;
                }
                catch (HttpRequestException e)
                {
                    // Thrown by ApiCallManager if the request could not be done successfully
                    exception = e;
                }
            }

            // Throw exception if no value is returned
            if (exception is null)
                // This should not happen, since all exceptions caught are stored in exception
                throw new CondenserApiException("Invalid request state in CondenserCall!");
            throw new CondenserApiException(
                "Repeated error occurrence in CondenserCall! Last exception: ", exception);
        }
    }
}