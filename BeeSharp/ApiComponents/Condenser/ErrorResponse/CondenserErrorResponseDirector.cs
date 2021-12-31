using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BeeSharp.ApiComponents.Condenser.CallComponents;
using BeeSharp.root.Exceptions;

namespace BeeSharp.ApiComponents.Condenser.ErrorResponse
{
    public static class CondenserErrorResponseDirector
    {
        private static readonly Dictionary<int, ICondenserErrorResponseHandler> ErrorCodes;

        static CondenserErrorResponseDirector()
        {
            ErrorCodes = new Dictionary<int, ICondenserErrorResponseHandler>();
            
            // Run all static constructors using reflection
            var condenserErrorResponseHandlerRegistrations = Assembly.Load(nameof(BeeSharp))
                .GetTypes()
                .Where(t => t.GetCustomAttributes(typeof(CondenserErrorResponseAttribute)).Any() &&
                            t.GetInterfaces().Contains(typeof(ICondenserErrorResponseHandler)))
                .ToArray();


            // Register the types
            foreach (var registration in condenserErrorResponseHandlerRegistrations)
            {
                var instance = (ICondenserErrorResponseHandler)Activator.CreateInstance(registration!)!;
                
                var attributes =
                    registration.GetCustomAttributes<CondenserErrorResponseAttribute>();

                foreach (var attribute in attributes)
                {
                    if(ErrorCodes.Keys.Contains(attribute.ErrorCode))
                        throw new ArgumentException($"ErrorCode already registered: {attribute.ErrorCode}!");
                    ErrorCodes[attribute.ErrorCode] = instance;
                }
            }
        }

        /// <summary>
        /// Handle an erroneous condenser response.
        /// </summary>
        /// <param name="errorResponse">The response.</param>
        /// <param name="rawRequest">The raw request.</param>
        /// <param name="rawResponse">The raw response.</param>
        /// <exception cref="CondenserApiException">Thrown when the error is an unknown error code.</exception>
        public static void HandleErrorResponse(CondenserApiErrorResponse errorResponse, string rawRequest,
            string rawResponse)
        {
            if (ErrorCodes.ContainsKey(errorResponse.Code))
            {
                // known error code
                ErrorCodes[errorResponse.Code].HandleError(errorResponse, rawRequest, rawRequest);
            }
            else
            {
                // unknown error code
                throw new CondenserApiException(errorResponse, rawRequest, rawResponse);
            }
        }
    }
}