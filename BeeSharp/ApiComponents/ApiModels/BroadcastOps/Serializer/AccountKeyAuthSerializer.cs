using System.IO;
using System.Text;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public static class AccountKeyAuthSerializer
    {
        public static byte[] SerializeOperation(KeyAuthElement keyAuth)
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            result.Write(keyAuth.PublicKey.GetEncodedKey());
            // AccountThreshold as uint16/ushort
            writer.Write(keyAuth.Weight);

            return result.ToArray();
        }
    }
}