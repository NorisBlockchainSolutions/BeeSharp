using System;
using System.Runtime.Serialization;
using System.Text.Json;
using BeeSharp.ApiComponents.Condenser.CallComponents;

namespace BeeSharp.root.Exceptions
{
    public class ApiNodeErrorException : Exception
    {
        private const string Error = "Invalid server response: API returned Error: ";

        public ApiNodeErrorException() : base(Error)
        {
        }

        public ApiNodeErrorException(string message) : base($"{Error}{message}")
        {
        }

        public ApiNodeErrorException(string message, Exception inner) : base($"{Error}{message}", inner)
        {
        }

        public ApiNodeErrorException(CondenserApiErrorResponse error, string rawRequest, string rawResponse)
            : base(
                $"\"Error\": {JsonSerializer.Serialize(error)}, RawRequest: {rawRequest}, RawResponse: {rawResponse}")
        {
        }

        protected ApiNodeErrorException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}