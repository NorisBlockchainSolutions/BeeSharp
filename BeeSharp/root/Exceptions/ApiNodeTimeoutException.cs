using System;
using System.Runtime.Serialization;
using System.Text.Json;
using BeeSharp.ApiComponents.Condenser.CallComponents;

namespace BeeSharp.root.Exceptions
{
    public class ApiNodeTimeoutException : Exception
    {
        private const string Error = "API returned Timeout Error: ";

        public ApiNodeTimeoutException() : base(Error)
        {
        }

        public ApiNodeTimeoutException(string message) : base($"{Error}{message}")
        {
        }

        public ApiNodeTimeoutException(string message, Exception inner) : base($"{Error}{message}", inner)
        {
        }

        public ApiNodeTimeoutException(CondenserApiErrorResponse error, string rawRequest, string rawResponse)
            : base(
                $"\"Error\": {JsonSerializer.Serialize(error)}, RawRequest: {rawRequest}, RawResponse: {rawResponse}")
        {
        }

        protected ApiNodeTimeoutException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}