#nullable enable
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents
{
    public abstract class JsonDirector
    {
        /// <summary>
        /// Register all types known to a attributeType
        /// </summary>
        /// <param name="assignedTypes"></param>
        /// <param name="attributeType"></param>
        private void RegisterTypes(Type[] assignedTypes, Type attributeType)
        {
            foreach (var registration in assignedTypes)
            {
                // Get OperationName
                var attributes = registration.GetCustomAttributes(attributeType);
                foreach (var attribute in attributes)
                {
                    // Use operationModel if given (optional) or the type of the class the attribute was applied to
                    Register(attribute, registration);
                }
            }
        }

        /// <summary>
        /// Register multiple types for multiple attribute types
        /// </summary>
        /// <param name="assignedTypes">List of assignedTypes-Arrays.</param>
        /// <param name="attributeTypes">Array of attribute types.</param>
        /// <exception cref="ArgumentException">Thrown when length of the arguments mismatch.</exception>
        private void RegisterTypesMultipleAttributes(List<Type[]> assignedTypes, Type[] attributeTypes)
        {
            if (assignedTypes.Count != attributeTypes.Length)
                throw new ArgumentException(
                    $"Invalid arguments! Number of {nameof(assignedTypes)} and {nameof(attributeTypes)} have to match!");

            for (var i = 0; i < assignedTypes.Count; i++)
            {
                RegisterTypes(assignedTypes[i], attributeTypes[i]);
            }
        }

        public JsonDirector(ITypeAssignedAttributeFetcher typeAssignedAttributeFetcher,
            string[] assemblies, Type[] attributeTypes)
        {
            if (assemblies is null)
            {
                throw new ArgumentException("Cannot get operation registrations without assemblies!",
                    nameof(assemblies));
            }

            if (attributeTypes is null)
            {
                throw new ArgumentException("Cannot get operation registrations without valid types!",
                    nameof(attributeTypes));
            }

            // Get all types that want to register with this director
            var attributeAssignedTypes =
                typeAssignedAttributeFetcher.GetAttributeAssignedTypes(assemblies, attributeTypes);

            // Register the types
            RegisterTypesMultipleAttributes(attributeAssignedTypes, attributeTypes);
        }

        public abstract void Register(Attribute attribute, Type structure);

        public abstract Type? GetStructure(params string[] identifiers);
    }
}