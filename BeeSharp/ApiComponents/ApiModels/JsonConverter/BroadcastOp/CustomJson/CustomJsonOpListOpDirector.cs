#nullable enable
using System;
using System.Collections.Generic;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents;
using BeeSharp.root.DebugInfoProvider;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public class CustomJsonOpListOpDirector : JsonDirector
    {
        private readonly IDictionary<string, Type> _customJsonOpRegister = new Dictionary<string, Type>();

        public CustomJsonOpListOpDirector(ITypeAssignedAttributeFetcher typeAssignedAttributeFetcher,
            string[] assemblies) : base(typeAssignedAttributeFetcher, assemblies,
            new []{typeof(CustomJsonOpListOpAttribute)})
        {}

        public override void Register(Attribute attribute, Type structure)
        {
            if (attribute is not CustomJsonOpListOpAttribute customJsonOpListOpAttribute)
                throw new InvalidCastException($"Cannot process attribute of type {attribute.GetType()}!");

            var operationName = customJsonOpListOpAttribute.OperationName;
            structure = customJsonOpListOpAttribute.JsonModel ?? structure;
            if (!_customJsonOpRegister.TryAdd(operationName!, structure))
                throw new ArgumentException($"OperationName already registered: {operationName}!",
                    nameof(operationName));
        }

        public override Type? GetStructure(params string[] identifiers)
        {
            if (identifiers.Length != 1)
                throw new ArgumentException("Invalid identifiers count, has to be 1!");
            
            if (_customJsonOpRegister.TryGetValue(identifiers[0], out var result)) return result;
            
            DirectorInfoProvider.OnUnregisteredTypeRequested(typeof(CustomJsonOpListOpDirector),
                new UnregisteredTypeEventArgs(nameof(CustomJsonOpListOpDirector),
                    $"Missing operationName: {identifiers[0]}"));

            return null;
        }
    }
}