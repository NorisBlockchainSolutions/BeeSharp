using System.IO;
using System.Text;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable;
using BeeSharp.Auth.ECKeyManagement.KeyProcessing;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public static class AccountKeyElementsSerializer
    {
        public static byte[] SerializeOperation(AccountKeyElement ownerKey, AccountKeyElement activeKey,
            AccountKeyElement postingKey, EcdsaPublicKey memoKey)
        {
            var result = new MemoryStream();

            result.Write(AccountKeySerializer.SerializeOperation(ownerKey));
            result.Write(AccountKeySerializer.SerializeOperation(activeKey));
            result.Write(AccountKeySerializer.SerializeOperation(postingKey));

            result.Write(memoKey.GetEncodedKey());

            return result.ToArray();
        }

        /// <summary>
        ///     Serialize the keys, but as optional elements.
        ///     Optional: prepend true/1 if exists, false/0 if not
        /// </summary>
        /// <returns></returns>
        public static byte[] SerializeOptionalKeys(AccountKeyElement? ownerKey, AccountKeyElement? activeKey,
            AccountKeyElement? postingKey, EcdsaPublicKey? memoKey, bool isMemoKeyOptional = false)
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            // Since all keyElements are optional, they have to be serialized by hand
            // Optional: prepend true/1 if exists, false/0 if not
            writer.Write(ownerKey is not null);
            if (ownerKey is not null)
                result.Write(AccountKeySerializer.SerializeOperation(ownerKey));
            writer.Write(activeKey is not null);
            if (activeKey is not null)
                result.Write(AccountKeySerializer.SerializeOperation(activeKey));
            writer.Write(postingKey is not null);
            if (postingKey is not null)
                result.Write(AccountKeySerializer.SerializeOperation(postingKey));

            // Memo key is only optional for accountUpdate2
            if (isMemoKeyOptional)
                writer.Write(memoKey is not null);
            else
                result.Write(memoKey!.GetEncodedKey());

            return result.ToArray();
        }
    }
}