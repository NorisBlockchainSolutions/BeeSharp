using System;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CustomJsonOpListOpAttribute : Attribute
    {
        /// <summary>
        ///     This attribute can be applied to a class, to mark it as customJson with List operationName structure:
        ///     [ "operationName", { ... } ]
        /// </summary>
        /// <param name="operationName">The name of the operation.</param>
        /// <param name="jsonModel">
        ///     Optional type to provide the model instead of using the associated class the
        ///     attribute is applied on.
        /// </param>
        public CustomJsonOpListOpAttribute(string operationName, Type? jsonModel = null)
        {
            OperationName = operationName;
            JsonModel = jsonModel;
        }

        public string OperationName { get; }
        public Type? JsonModel { get; }
    }
}