using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace author_reward
    {
        [VirtualBroadcastOp("author_reward")]
        public class BroadcastVirtualOpAuthorRewardModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpAuthorRewardModel(string author, string permLink, string hbdPayout,
                string hivePayout, string vestingPayout)
            {
                Author = author;
                PermLink = permLink;
                HbdPayout = hbdPayout;
                HivePayout = hivePayout;
                VestingPayout = vestingPayout;
            }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            [JsonPropertyName("hbd_payout")] public string HbdPayout { get; }

            [JsonPropertyName("hive_payout")] public string HivePayout { get; }

            [JsonPropertyName("vesting_payout")] public string VestingPayout { get; }
        }
    }
}