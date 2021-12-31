using System;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CustomJsonOpIdAttribute : Attribute
    {
        /// <summary>
        ///     This attribute can be applied to a class, to mark it as customJson model identified by the id json
        ///     attribute.
        /// </summary>
        /// <param name="id">The custom json json id attribute value, upon which the model shall be used.</param>
        /// <param name="jsonModel">
        ///     Optional jsonModel type to register a different type than the class the attribute
        ///     is used on.
        /// </param>
        public CustomJsonOpIdAttribute(string id, Type? jsonModel = null)
        {
            Id = id;
            JsonModel = jsonModel;
        }

        public string Id { get; }
        public Type? JsonModel { get; }
    }
}