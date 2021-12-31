using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey
{
    [JsonConverter(typeof(AccountAuthJsonConverter))]
    public class AccountAuthModel
    {
        /// <summary>
        ///     Create a new account auth model, containing an account name and its threshold (default 1).
        /// </summary>
        /// <param name="accountName">The name of the account.</param>
        /// <param name="accountThreshold">The key threshold (default 1).</param>
        public AccountAuthModel(string accountName, NumberOrStringModel? accountThreshold = null)
        {
            AccountName = accountName;
            AccountThreshold = accountThreshold ?? new NumberOrStringModel(1);
        }

        public string? AccountName { get; }
        public NumberOrStringModel AccountThreshold { get; }
    }
}