using System;
using System.Runtime.Serialization;

namespace BeeSharp.root.Exceptions
{
    public class MathException : Exception
    {
        private const string Error = "Unexpected result of calculation! ";

        public MathException() : base(Error)
        {
        }

        public MathException(string message) : base($"{Error}{message}")
        {
        }

        public MathException(string message, Exception inner) : base($"{Error}{message}", inner)
        {
        }

        protected MathException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}