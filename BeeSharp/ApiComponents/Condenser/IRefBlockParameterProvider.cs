using System.Net.Http;
using System.Threading.Tasks;

namespace BeeSharp.ApiComponents.Condenser
{
    public interface IRefBlockParameterProvider
    {
        /// <summary>
        ///     Get current refBlockNum and refBlockPrefix.
        /// </summary>
        /// <returns>refBlockNum and refBlockPrefix tuple.</returns>
        /// <exception cref="HttpRequestException">
        ///     Thrown when a request error occurs (no connection or invalid node).
        /// </exception>
        Task<(ushort, uint)> GetRefBlockParams();
    }
}