#nullable enable
using System;
using System.Collections.Generic;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents;
using BeeSharp.root.DebugInfoProvider;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public class CustomJsonOpIdDirector : JsonDirector
    {
        private readonly IDictionary<string, Type> _customJsonOpRegister = new Dictionary<string, Type>();

        public CustomJsonOpIdDirector(ITypeAssignedAttributeFetcher typeAssignedAttributeFetcher, 
            string[] assemblies) : base(typeAssignedAttributeFetcher, assemblies, 
            new []{typeof(CustomJsonOpIdAttribute)})
        {}

        public override void Register(Attribute attribute, Type structure)
        {
            if (attribute is not CustomJsonOpIdAttribute customJsonOpIdAttribute)
                throw new InvalidCastException($"Cannot process attribute of type {attribute.GetType()}!");

            var customJsonId = customJsonOpIdAttribute.Id;
            structure = customJsonOpIdAttribute.JsonModel ?? structure;
            
            if (!_customJsonOpRegister.TryAdd(customJsonId!, structure))
                throw new ArgumentException($"CustomJsonId already registered: {customJsonId}!",
                    nameof(customJsonId));
        }

        public override Type? GetStructure(params string[] identifiers)
        {
            if (identifiers.Length != 1)
                throw new ArgumentException("Invalid identifiers count, has to be 1!");
            
            if (_customJsonOpRegister.TryGetValue(identifiers[0], out var result)) return result;

            DirectorInfoProvider.OnUnregisteredTypeRequested(typeof(CustomJsonOpIdDirector),
                new UnregisteredTypeEventArgs(nameof(CustomJsonOpIdDirector),
                    $"Missing customJsonId: {identifiers[0]}"));

            return null;
        }
        
        // Event handling
        public event EventHandler<CustomJsonOperation>?  CustomJsonOperationSerialized;

        internal void OnCustomJsonOperationSerialized(CustomJsonOperation operation)
        {
            CustomJsonOperationSerialized?.Invoke(this, operation);
        }
    }
}