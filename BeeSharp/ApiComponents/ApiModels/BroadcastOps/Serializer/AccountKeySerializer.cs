using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public static class AccountKeySerializer
    {
        private static void SerializeAccountAuths(BinaryWriter writer,
            IReadOnlyCollection<AccountAuthElement>? accountAuths)
        {
            if (accountAuths is null || accountAuths.Count == 0)
                writer.Write((byte) 0);
            else
                foreach (var accountAuth in accountAuths!.OrderBy(auth => auth.AccountName))
                    writer.Write(AccountAuthSerializer.SerializeOperation(accountAuth!));
        }

        private static void SerializeKeyAuths(BinaryWriter writer,
            IReadOnlyCollection<KeyAuthElement>? keyAuths)
        {
            if (keyAuths is null || keyAuths.Count == 0)
            {
                writer.Write((byte) 0);
            }
            else
            {
                // Prefix keys with keyCount
                writer.Write((byte) keyAuths.Count);
                foreach (var keyAuthElement
                    in keyAuths.OrderBy(auth => auth.PublicKey.GetBase58Encoded()))
                    writer.Write(AccountKeyAuthSerializer.SerializeOperation(keyAuthElement));
            }
        }

        public static byte[] SerializeOperation(AccountKeyElement keys)
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            // WeightThreshold as unsigned int32
            writer.Write(keys.WeightThreshold);

            SerializeAccountAuths(writer, keys.AccountAuths);

            SerializeKeyAuths(writer, keys.KeyAuths);

            return result.ToArray();
        }
    }
}