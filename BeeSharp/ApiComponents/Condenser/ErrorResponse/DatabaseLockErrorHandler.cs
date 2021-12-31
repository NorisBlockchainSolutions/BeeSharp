using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiComponents.Condenser.ErrorResponse
{
    [CondenserErrorResponse(-32000)]
    [CondenserErrorResponse(-32003)]
    public class DatabaseLockErrorHandler : ICondenserErrorResponseHandler
    {
        public void HandleError(CondenserApiErrorResponse errorResponse, string rawRequest, string rawResponse)
        {
            // -32000 is a server error
            throw new ApiNodeErrorException(
                $"Server error!\nError: {errorResponse}\n\nRequest: {rawRequest}\n\nResponse: {rawResponse}");
        }
    }
}