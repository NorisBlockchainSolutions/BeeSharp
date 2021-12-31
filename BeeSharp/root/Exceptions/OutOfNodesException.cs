using System;
using System.Runtime.Serialization;

namespace BeeSharp.root.Exceptions
{
    public class OutOfNodesException : Exception
    {
        private const string Error = "No ranked nodes remaining! ";

        public OutOfNodesException() : base(Error)
        {
        }

        public OutOfNodesException(string message) : base($"{Error}{message}")
        {
        }

        public OutOfNodesException(string message, Exception inner) : base($"{Error}{message}", inner)
        {
        }

        protected OutOfNodesException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}