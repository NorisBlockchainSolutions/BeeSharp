using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace recover_account
    {
        [BroadcastOp("recover_account")]
        public class BroadcastOpRecoverAccountModel : BroadcastOperation
        {
            public BroadcastOpRecoverAccountModel(string accountToRecover, AccountKeyModel newOwnerAuthority,
                AccountKeyModel recentOwnerAuthority, ExtensionModel[] extensions)
            {
                AccountToRecover = accountToRecover;
                NewOwnerAuthority = newOwnerAuthority;
                RecentOwnerAuthority = recentOwnerAuthority;
                Extensions = extensions;
            }

            [JsonPropertyName("account_to_recover")]
            public string AccountToRecover { get; }

            [JsonPropertyName("new_owner_authority")]
            public AccountKeyModel NewOwnerAuthority { get; }

            [JsonPropertyName("recent_owner_authority")]
            public AccountKeyModel RecentOwnerAuthority { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }
    }
}