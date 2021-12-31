using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace producer_reward
    {
        [VirtualBroadcastOp("producer_reward")]
        public class BroadcastVirtualOpProducerRewardModel : VirtualBroadcastOperation
        {
            /// <summary>
            ///     Witness rewards for block signing.
            /// </summary>
            /// <param name="producer">The witness account that receives the reward.</param>
            /// <param name="vestingShares">The amount of VESTS the witness account receives.</param>
            public BroadcastVirtualOpProducerRewardModel(string producer, string vestingShares)
            {
                Producer = producer;
                VestingShares = vestingShares;
            }

            [JsonPropertyName("producer")] public string Producer { get; }

            [JsonPropertyName("vesting_shares")] public string VestingShares { get; }
        }
    }
}