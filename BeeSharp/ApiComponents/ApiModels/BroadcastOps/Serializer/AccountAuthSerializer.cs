using System.IO;
using System.Text;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public static class AccountAuthSerializer
    {
        public static byte[] SerializeOperation(AccountAuthElement authModel)
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            // Prefix accountName with nameCount (always one)
            writer.Write((byte) 1);
            writer.Write(authModel.AccountName);
            // AccountThreshold as uint16/ushort
            writer.Write(authModel.Weight);

            return result.ToArray();
        }
    }
}