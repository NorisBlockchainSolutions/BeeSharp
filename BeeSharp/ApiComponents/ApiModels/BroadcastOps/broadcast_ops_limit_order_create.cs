using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace limit_order_create
    {
        [BroadcastOp("limit_order_create")]
        public class BroadcastOpLimitOrderCreateModel : BroadcastOperation
        {
            /// <summary>
            ///     Create a limit order and match it against existing open orders.
            ///     The maximum expiration time for any limit order is 28 days from head_block_time.
            /// </summary>
            public BroadcastOpLimitOrderCreateModel(string owner, NumberOrStringModel orderId, string amountToSell,
                string minToReceive, bool fillOrKill, DateTime expiration)
            {
                Owner = owner;
                OrderId = orderId;
                AmountToSell = amountToSell;
                MinToReceive = minToReceive;
                FillOrKill = fillOrKill;
                Expiration = expiration;
            }

            [JsonPropertyName("owner")] public string Owner { get; }

            [JsonPropertyName("orderid")] public NumberOrStringModel OrderId { get; }

            [JsonPropertyName("amount_to_sell")] public string AmountToSell { get; }

            [JsonPropertyName("min_to_receive")] public string MinToReceive { get; }

            [JsonPropertyName("fill_or_kill")] public bool FillOrKill { get; }

            [JsonPropertyName("expiration")] public DateTime Expiration { get; }
        }
    }
}