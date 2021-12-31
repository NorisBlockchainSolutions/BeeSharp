using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace transfer_to_vesting_completed
    {
        [VirtualBroadcastOp("transfer_to_vesting_completed")]
        public class BroadcastVirtualOpTransferToVestingCompletedModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpTransferToVestingCompletedModel(string fromAccount, string toAccount,
                string hiveVested, string vestingSharesReceived)
            {
                FromAccount = fromAccount;
                ToAccount = toAccount;
                HiveVested = hiveVested;
                VestingSharesReceived = vestingSharesReceived;
            }

            [JsonPropertyName("from_account")] public string FromAccount { get; }

            [JsonPropertyName("to_account")] public string ToAccount { get; }

            [JsonPropertyName("hive_vested")] public string HiveVested { get; }

            [JsonPropertyName("vesting_shares_received")]
            public string VestingSharesReceived { get; }
        }
    }
}