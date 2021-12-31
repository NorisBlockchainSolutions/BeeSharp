using System.Threading.Tasks;
using BeeSharp.ApiComponents.Condenser.CallComponents;

namespace BeeSharp.ApiComponents.Condenser
{
    public interface ICondenserCall
    {
        /// <summary>
        ///     Get the result of a condenser api call.
        /// </summary>
        /// <typeparam name="T">The type of the parameter object.</typeparam>
        /// <typeparam name="TU">The type of the api response object.</typeparam>
        /// <param name="apiCall">The apiCall to make.</param>
        /// <returns>The response object.</returns>
        Task<CondenserApiResponse<TU>> GetRawCondenserApiCallAsync<T, TU>(ICondenserApiCall<T, TU> apiCall)
            where TU : class;

        /// <summary>
        ///     Get the result of a condenser api call.
        /// </summary>
        /// <typeparam name="T">The type of the parameter object.</typeparam>
        /// <typeparam name="TU">The type of the api response object.</typeparam>
        /// <param name="apiCall">The apiCall to make.</param>
        /// <returns>The response object.</returns>
        Task<TU> GetCondenserApiCallResultAsync<T, TU>(ICondenserApiCall<T, TU> apiCall)
            where TU : class;
    }
}