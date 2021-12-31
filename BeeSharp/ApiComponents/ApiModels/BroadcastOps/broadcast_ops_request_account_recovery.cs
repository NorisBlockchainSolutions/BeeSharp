using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace request_account_recovery
    {
        [BroadcastOp("request_account_recovery")]
        public class BroadcastOpRequestAccountRecoveryModel : BroadcastOperation
        {
            /// <summary>
            ///     Request an account recovery for an account that set you as recovery account.
            ///     The account to recover has 24h to respond before the request expires and is invalidated.
            ///     There can only be one active recovery request per account at once. Pushing a second request will:
            ///     - Update request to new owner authority and extend the expiration to 24h from the current head block
            ///     time.
            ///     - Delete the request by setting the weight threshold of the new owner authority to 0, making it an open
            ///     authority.
            ///     Sum of key weights must be >= weight threshold.
            /// </summary>
            /// <param name="recoveryAccount">Account with recovery authority.</param>
            /// <param name="accountToRecover">The account to recover.</param>
            /// <param name="newOwnerAuthority">The new owner authority/key.</param>
            /// <param name="extensions">Additional extensions.</param>
            public BroadcastOpRequestAccountRecoveryModel(string recoveryAccount, string accountToRecover,
                AccountKeyModel newOwnerAuthority, ExtensionModel[] extensions)
            {
                RecoveryAccount = recoveryAccount;
                AccountToRecover = accountToRecover;
                NewOwnerAuthority = newOwnerAuthority;
                Extensions = extensions;
            }

            [JsonPropertyName("recovery_account")] public string RecoveryAccount { get; }

            [JsonPropertyName("account_to_recover")]
            public string AccountToRecover { get; }

            [JsonPropertyName("new_owner_authority")]
            public AccountKeyModel NewOwnerAuthority { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }
    }
}