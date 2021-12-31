using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_open_orders
    {
        public class CondenserApiGetOpenOrders : ICondenserApiCall<string, List<CondenserApiOpenOrderModel>>
        {
            public CondenserApiGetOpenOrders(string account)
            {
                QueryParametersJson = new[] {account};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_open_orders";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiOpenOrderModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiOpenOrderModel
        {
            public CondenserApiOpenOrderModel(NumberOrStringModel id, DateTime created, DateTime expiration,
                string seller,
                NumberOrStringModel orderId, NumberOrStringModel forSale, OrderPriceModel sellPrice, string realPrice,
                bool rewarded)
            {
                Id = id;
                Created = created;
                Expiration = expiration;
                Seller = seller;
                OrderId = orderId;
                ForSale = forSale;
                SellPrice = sellPrice;
                RealPrice = realPrice;
                Rewarded = rewarded;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("created")] public DateTime Created { get; }

            [JsonPropertyName("expiration")] public DateTime Expiration { get; }

            [JsonPropertyName("seller")] public string Seller { get; }

            [JsonPropertyName("orderid")] public NumberOrStringModel OrderId { get; }

            [JsonPropertyName("for_sale")] public NumberOrStringModel ForSale { get; }

            [JsonPropertyName("sell_price")] public OrderPriceModel SellPrice { get; }

            [JsonPropertyName("real_price")] public string RealPrice { get; }

            [JsonPropertyName("rewarded")] public bool Rewarded { get; }
        }

        public class OrderPriceModel
        {
            public OrderPriceModel(string @base, string quote)
            {
                Base = @base;
                Quote = quote;
            }

            [JsonPropertyName("base")] public string Base { get; }

            [JsonPropertyName("quote")] public string Quote { get; }
        }
    }
}