using System;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;

namespace BeeSharp.ApiComponents.Condenser.Serialization
{
    public interface ITransactionSerializer
    {
        byte[] GetSerializedTransaction(ushort refBlockNum, uint refBlockPrefix, DateTime expiration,
            ISerializableOperation[] operations, ExtensionModel[]? extensions = null);
    }
}