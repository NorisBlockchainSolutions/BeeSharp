using System;
using System.Runtime.Serialization;
using System.Text.Json;
using BeeSharp.ApiComponents.Condenser.CallComponents;

namespace BeeSharp.root.Exceptions
{
    public class CondenserApiException : Exception
    {
        private const string Error = "Invalid request: API returned Error: ";

        public CondenserApiException() : base(Error)
        {
        }

        public CondenserApiException(string message) : base($"{Error}{message}")
        {
        }

        public CondenserApiException(string message, Exception inner) : base($"{Error}{message}", inner)
        {
        }

        public CondenserApiException(CondenserApiErrorResponse error, string rawRequest, string rawResponse)
            : base(
                $"\"Error\": {JsonSerializer.Serialize(error)}, RawRequest: {rawRequest}, RawResponse: {rawResponse}")
        {
        }

        protected CondenserApiException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}