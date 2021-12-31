#nullable enable
using System;
using System.Collections.Generic;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents
{
    public interface ITypeAssignedAttributeFetcher
    {
        /// <summary>
        /// Get all types that have one of the given types associated per type.
        /// </summary>
        /// <param name="assemblies">The assemblies to check.</param>
        /// <param name="attributeTypes">The types to check for.</param>
        /// <returns>The types grouped by type.</returns>
        List<Type[]> GetAttributeAssignedTypes(string[] assemblies, Type[] attributeTypes);
    }
}