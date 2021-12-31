using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey
{
    [JsonConverter(typeof(KeyAuthJsonConverter))]
    public class AccountKeyAuthModel
    {
        /// <summary>
        ///     Create a new account key auth model, containing a public key and its threshold
        ///     (default 1).
        /// </summary>
        /// <param name="key">The public key as base58-encoded string.</param>
        /// <param name="keyThreshold">The key threshold (default 1).</param>
        public AccountKeyAuthModel(string? key, NumberOrStringModel? keyThreshold = null)
        {
            Key = key;
            KeyThreshold = keyThreshold ?? new NumberOrStringModel(1);
        }

        public string? Key { get; }

        public NumberOrStringModel KeyThreshold { get; }
    }
}