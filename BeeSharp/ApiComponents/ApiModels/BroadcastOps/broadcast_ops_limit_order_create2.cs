using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace limit_order_create2
    {
        [BroadcastOp("limit_order_create2")]
        public class BroadcastOpLimitOrderCreate2Model : BroadcastOperation
        {
            /// <summary>
            ///     Serializes price rather than calculating it from other fields.
            /// </summary>
            public BroadcastOpLimitOrderCreate2Model(string owner, NumberOrStringModel orderId,
                FeeModelOrStringModel amountToSell, ExchangeRateModel exchangeRate, bool fillOrKill,
                DateTime expiration)
            {
                Owner = owner;
                OrderId = orderId;
                AmountToSell = amountToSell;
                ExchangeRate = exchangeRate;
                FillOrKill = fillOrKill;
                Expiration = expiration;
            }

            [JsonPropertyName("owner")] public string Owner { get; set; }

            [JsonPropertyName("orderid")] public NumberOrStringModel OrderId { get; set; }

            [JsonPropertyName("amount_to_sell")] public FeeModelOrStringModel AmountToSell { get; set; }

            [JsonPropertyName("exchange_rate")] public ExchangeRateModel ExchangeRate { get; set; }

            [JsonPropertyName("fill_or_kill")] public bool FillOrKill { get; set; }

            [JsonPropertyName("expiration")] public DateTime Expiration { get; set; }
        }
    }
}