using System;
using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiComponents.Condenser.ErrorResponse
{
    [CondenserErrorResponse(1000)]
    public class RequestTimeoutHandler : ICondenserErrorResponseHandler
    {
        public void HandleError(CondenserApiErrorResponse errorResponse, string rawRequest, string rawResponse)
        {
            // 1000 is a request timeout
            throw new ApiNodeTimeoutException(
                $"Request Timeout!\nError: {errorResponse}\n\nRequest: {rawRequest}\n\nResponse: {rawResponse}");
        }
    }
}