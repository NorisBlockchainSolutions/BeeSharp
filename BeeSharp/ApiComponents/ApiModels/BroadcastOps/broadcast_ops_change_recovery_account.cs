using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace change_recovery_account
    {
        [BroadcastOp("change_recovery_account")]
        public class BroadcastOpChangeRecoveryAccountModel : BroadcastOperation
        {
            /// <summary>
            ///     Change the recovery account. Takes 30 Days to complete.
            /// </summary>
            /// <param name="accountToRecover">The account whose recovery account shall be changed.</param>
            /// <param name="newRecoveryAccount">The new recovery account.</param>
            /// <param name="extensions">Extensions.</param>
            public BroadcastOpChangeRecoveryAccountModel(string accountToRecover, string newRecoveryAccount,
                ExtensionModel[]? extensions = null)
            {
                AccountToRecover = accountToRecover;
                NewRecoveryAccount = newRecoveryAccount;
                Extensions = extensions ?? Array.Empty<ExtensionModel>();
            }

            [JsonPropertyName("account_to_recover")]
            public string AccountToRecover { get; }

            [JsonPropertyName("new_recovery_account")]
            public string NewRecoveryAccount { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }
    }
}