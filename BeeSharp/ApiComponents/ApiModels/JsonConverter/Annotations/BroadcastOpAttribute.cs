using System;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class BroadcastOpAttribute : Attribute
    {
        /// <summary>
        ///     This attribute can be applied to a class, to register it as a BroadcastOp within the BroadcastOpDirector.
        /// </summary>
        /// <param name="operationName">The name of the operation to register.</param>
        /// <param name="operationModel">
        ///     The type of the operationModel to use. Optional, normally just apply the
        ///     attribute to the according model-class.
        /// </param>
        public BroadcastOpAttribute(string operationName, Type? operationModel = null)
        {
            OperationName = operationName;
            OperationModel = operationModel;
        }

        public string OperationName { get; }
        public Type? OperationModel { get; }
    }
}