using BeeSharp.ApiComponents.Condenser.CallComponents;

namespace BeeSharp.ApiComponents.Condenser.ErrorResponse
{
    public interface ICondenserErrorResponseHandler
    {
        public void HandleError(CondenserApiErrorResponse errorResponse, string rawRequest, string rawResponse);
    }
}
