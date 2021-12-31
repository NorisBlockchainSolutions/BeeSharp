using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace fill_vesting_withdraw
    {
        [VirtualBroadcastOp("fill_vesting_withdraw")]
        public class BroadcastVirtualOpFillVestingWithdrawModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpFillVestingWithdrawModel(string fromAccount, string toAccount, string withdrawn,
                string deposited)
            {
                FromAccount = fromAccount;
                ToAccount = toAccount;
                Withdrawn = withdrawn;
                Deposited = deposited;
            }

            [JsonPropertyName("from_account")] public string FromAccount { get; }

            [JsonPropertyName("to_account")] public string ToAccount { get; }

            [JsonPropertyName("withdrawn")] public string Withdrawn { get; }

            [JsonPropertyName("deposited")] public string Deposited { get; }
        }
    }
}