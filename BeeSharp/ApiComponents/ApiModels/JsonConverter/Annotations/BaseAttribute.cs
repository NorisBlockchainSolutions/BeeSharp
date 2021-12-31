#nullable enable
using System;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations
{
    public abstract class BaseAttribute : Attribute
    {
        public string Name { get; }
        public Type? Model { get; }
        
        public string[] AdditionalParams { get; }

        protected BaseAttribute(string name, Type? model, string[]? additionalParams = null)
        {
            Name = name;
            Model = model;
            AdditionalParams = additionalParams;
        }
    }
}