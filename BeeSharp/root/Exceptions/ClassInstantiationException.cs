using System;
using System.Runtime.Serialization;

namespace BeeSharp.root.Exceptions
{
    public class ClassInstantiationException : Exception
    {
        private const string Error = "Class instance creation failed or still in progress! ";

        public ClassInstantiationException() : base(Error)
        {
        }

        public ClassInstantiationException(string message) : base($"{Error}{message}")
        {
        }

        public ClassInstantiationException(string message, Exception inner) : base($"{Error}{message}", inner)
        {
        }

        protected ClassInstantiationException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}