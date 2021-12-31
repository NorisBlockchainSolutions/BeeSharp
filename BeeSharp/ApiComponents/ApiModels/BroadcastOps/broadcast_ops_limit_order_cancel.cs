using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace limit_order_cancel
    {
        [BroadcastOp("limit_order_cancel")]
        public class BroadcastOpLimitOrderCancelModel : BroadcastOperation
        {
            /// <summary>
            ///     Cancels an order and returns the balance to the owner.
            /// </summary>
            /// <param name="owner">Account that owns the order.</param>
            /// <param name="orderId">PostId of the order.</param>
            public BroadcastOpLimitOrderCancelModel(string owner, NumberOrStringModel orderId)
            {
                Owner = owner;
                OrderId = orderId;
            }

            [JsonPropertyName("owner")] public string Owner { get; }

            [JsonPropertyName("orderid")] public NumberOrStringModel OrderId { get; }
        }
    }
}