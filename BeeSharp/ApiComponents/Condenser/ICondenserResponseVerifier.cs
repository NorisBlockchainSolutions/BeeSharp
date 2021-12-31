using System;
using System.Threading.Tasks;
using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiComponents.Condenser
{
    public interface ICondenserResponseVerifier
    {
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
        Task CheckCondenserApiCallResultAsync<TU>(CondenserApiResponse<TU> apiResponse)
            where TU : class;
    }
}