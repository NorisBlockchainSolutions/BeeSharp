using System;

namespace BeeSharp.ApiComponents.Condenser.ErrorResponse
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CondenserErrorResponseAttribute : Attribute
    {
        public int ErrorCode { get; }

        /// <summary>
        /// Register to CondenserErrorResponseDirector as an error handler.
        /// </summary>
        /// <param name="errorCode">The code to register to.</param>
        public CondenserErrorResponseAttribute(int errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}