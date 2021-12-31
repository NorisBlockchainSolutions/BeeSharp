using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace account_witness_proxy
    {
        [BroadcastOp("account_witness_proxy")]
        public class BroadcastOpAccountWitnessProxyModel : BroadcastOperation
        {
            /// <summary>
            ///     Delegate witness votes to another account.
            ///     If a proxy is specified, all existing witness votes are removed.
            ///     Also applies to CondenserApiHive DHF proposal approval.
            /// </summary>
            /// <param name="account">The user account.</param>
            /// <param name="proxy">The proxy account.</param>
            public BroadcastOpAccountWitnessProxyModel(string account, string proxy)
            {
                Account = account;
                Proxy = proxy;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("proxy")] public string Proxy { get; }
        }
    }
}