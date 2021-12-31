using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey
{
    public class AccountKeyModel
    {
        /// <summary>
        ///     Create a new AccountKeyModel
        /// </summary>
        /// <param name="weightThreshold">The weight threshold all signatures have to reach to sign a transaction.</param>
        /// <param name="accountAuths">The auths of other accounts.</param>
        /// <param name="keyAuths">The key auths.</param>
        [JsonConstructor]
        public AccountKeyModel(NumberOrStringModel? weightThreshold, AccountAuthModel[]? accountAuths,
            AccountKeyAuthModel[]? keyAuths)
        {
            WeightThreshold = weightThreshold ?? new NumberOrStringModel(1);
            AccountAuths = accountAuths ?? Array.Empty<AccountAuthModel>();
            KeyAuths = keyAuths ?? Array.Empty<AccountKeyAuthModel>();
        }

        /// <summary>
        ///     Create a new AccountKeyModel with the weight threshold set to default value (1).
        /// </summary>
        /// <param name="keyAuths">The key auths.</param>
        /// <param name="accountAuths">The auths of other accounts.</param>
        public AccountKeyModel(string[] keyAuths,
            string[]? accountAuths = null)
        {
            WeightThreshold = new NumberOrStringModel(1);

            // RegisterNew AccountAuths
            if (accountAuths is not null)
            {
                var accountAuthsFull = new AccountAuthModel[accountAuths.Length];
                for (var i = 0; i < accountAuths.Length; ++i)
                    accountAuthsFull[i] = new AccountAuthModel(accountAuths[i]);

                AccountAuths = accountAuthsFull;
            }
            else
            {
                AccountAuths = Array.Empty<AccountAuthModel>();
            }

            // RegisterNew KeyAuths
            var keyAuthsFull = new AccountKeyAuthModel[keyAuths.Length];
            for (var i = 0; i < keyAuths.Length; ++i)
                keyAuthsFull[i] = new AccountKeyAuthModel(keyAuths[i]);

            KeyAuths = keyAuthsFull;
        }

        [JsonPropertyName("weight_threshold")] public NumberOrStringModel WeightThreshold { get; }
        [JsonPropertyName("account_auths")] public AccountAuthModel[] AccountAuths { get; }
        [JsonPropertyName("key_auths")] public AccountKeyAuthModel[] KeyAuths { get; }
    }
}