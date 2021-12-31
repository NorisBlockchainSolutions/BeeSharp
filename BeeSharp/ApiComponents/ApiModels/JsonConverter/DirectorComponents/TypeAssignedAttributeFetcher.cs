#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents
{
    public class TypeAssignedAttributeFetcher : ITypeAssignedAttributeFetcher
    {
        /// <summary>
        /// Get all types within the assemblies that have the attribute type assigned to them.
        /// </summary>
        /// <param name="assemblies">The name of the assemblies to check.</param>
        /// <param name="attributeType">The type of the assigned attribute.</param>
        /// <returns>A list of all types that have the attribute assigned to them.</returns>
        /// <exception cref="ArgumentException">Thrown when a parameter is null.</exception>
        private Type[] GetAttributeAssignedTypesPerType(string[] assemblies, Type attributeType)
        {
            var result = new List<Type>();
            
            foreach (var assembly in assemblies)
            {
                var operationRegistrationAssignedTypes = Assembly.Load(assembly)
                    .GetTypes()
                    .Where(t => t.GetCustomAttributes(attributeType).Any());

                result.AddRange(operationRegistrationAssignedTypes);
            }

            return result.ToArray();
        }

        /// <summary>
        /// Get all types that have one of the given types associated per type.
        /// </summary>
        /// <param name="assemblies">The assemblies to check.</param>
        /// <param name="attributeTypes">The types to check for.</param>
        /// <returns>The types grouped by type.</returns>
        public List<Type[]> GetAttributeAssignedTypes(string[] assemblies, Type[] attributeTypes)
        {
            var operationAssignedTypesPerType = new List<Type[]>();
            foreach (var attributeType in attributeTypes)
            {
                var operationAssignedTypes = GetAttributeAssignedTypesPerType(assemblies, attributeType);
                operationAssignedTypesPerType.Add(operationAssignedTypes);
            }

            return operationAssignedTypesPerType;
        }
    }
}