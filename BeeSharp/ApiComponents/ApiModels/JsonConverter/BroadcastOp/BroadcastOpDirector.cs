#nullable enable
using System;
using System.Collections.Generic;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents;
using BeeSharp.root.DebugInfoProvider;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp
{
    public class BroadcastOpDirector : JsonDirector
    {
        private static readonly IDictionary<string, Type> OpRegister = new Dictionary<string, Type>();
        private static readonly IDictionary<Type, string> OpRegisterReverse = new Dictionary<Type, string>();

        public BroadcastOpDirector(ITypeAssignedAttributeFetcher typeAssignedAttributeFetcher,
            string[] assemblies): base(typeAssignedAttributeFetcher, assemblies,
            new []{typeof(BroadcastOpAttribute), typeof(VirtualBroadcastOpAttribute)})
        {}

        public override void Register(Attribute attribute, Type structure)
        {
            string operation;
            if (attribute is BroadcastOpAttribute broadcastOpAttribute)
            {
                operation = broadcastOpAttribute.OperationName!;
                structure = broadcastOpAttribute.OperationModel ?? structure;
            }
            else if (attribute is VirtualBroadcastOpAttribute virtualBroadcastOpAttribute)
            {
                operation = virtualBroadcastOpAttribute.OperationName!;
                structure = virtualBroadcastOpAttribute.OperationModel ?? structure;
            }
            else
            {
                throw new InvalidCastException($"Cannot process attribute of type {attribute.GetType()}!");
            }
            
            if (!OpRegister.TryAdd(operation, structure) || !OpRegisterReverse.TryAdd(structure, operation))
                throw new ArgumentException($"OperationName already registered: {operation}!", nameof(operation));
        }

        public override Type? GetStructure(params string[] identifiers)
        {
            if (identifiers.Length != 1)
                throw new ArgumentException("Invalid identifiers count, has to be 1!");

            var operation = identifiers[0];
            if (OpRegister.TryGetValue(operation, out var result)) return result;

            DirectorInfoProvider.OnUnregisteredTypeRequested(typeof(BroadcastOpDirector),
                new UnregisteredTypeEventArgs(nameof(BroadcastOpDirector),
                    $"Missing operation: {operation}"));
            
            return null;
        }
    }
}