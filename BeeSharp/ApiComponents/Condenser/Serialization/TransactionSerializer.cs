using System;
using System.IO;
using System.Text;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.Condenser.Serialization
{
    public class TransactionSerializer : ITransactionSerializer
    {
        public byte[] GetSerializedTransaction(ushort refBlockNum, uint refBlockPrefix, DateTime expiration,
            ISerializableOperation[] operations,
            ExtensionModel[]? extensions = null)
        {
            using var stream = new MemoryStream();
            using var writer = new BinaryWriter(stream, Encoding.UTF8);

            // uint16, length 2
            writer.Write(refBlockNum);

            // uint32, length 4 
            writer.Write(refBlockPrefix);

            // uint32, length 4
            var expirationTime = Convert.ToUInt32(Math.Abs((expiration - DateTime.UnixEpoch).TotalSeconds));
            writer.Write(expirationTime);

            // number of operations
            stream.Write(ByteHelper.IntToShortestUnsignedByteArray(operations.Length));

            // Serialize operations
            foreach (var operation in operations)
            {
                // Write operation id
                stream.Write(ByteHelper.IntToShortestUnsignedByteArray((int) operation.GetOperationId()));

                // Write serialized operation
                stream.Write(operation.SerializeOperation());
            }

            // Add extensions
            if (extensions is null)
            {
                stream.Write(new[] {(byte) 0});
            }
            else
            {
                stream.Write(ByteHelper.IntToShortestUnsignedByteArray(extensions.Length));
                if (extensions.Length == 0) return stream.ToArray();
                foreach (var extension in extensions) writer.Write(extension.GetSerialized());
            }

            return stream.ToArray();
        }
    }
}