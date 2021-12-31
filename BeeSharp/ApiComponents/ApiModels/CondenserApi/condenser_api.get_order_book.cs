using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.CondenserApi.get_open_orders;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_order_book
    {
        public class CondenserApiGetOrderBook : ICondenserApiCall<int, CondenserApiOrderBookModel>
        {
            public CondenserApiGetOrderBook([Range(0, 500)] int limit)
            {
                QueryParametersJson = new[] {limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public int[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_order_book";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiOrderBookModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiOrderBookModel
        {
            public CondenserApiOrderBookModel(CondenserApiMarketOrderModel[] bids, CondenserApiMarketOrderModel[] asks)
            {
                Bids = bids;
                Asks = asks;
            }

            [JsonPropertyName("bids")] public CondenserApiMarketOrderModel[] Bids { get; }

            [JsonPropertyName("asks")] public CondenserApiMarketOrderModel[] Asks { get; }
        }

        public class CondenserApiMarketOrderModel
        {
            public CondenserApiMarketOrderModel(OrderPriceModel orderPrice, string realPrice, NumberOrStringModel hive,
                NumberOrStringModel hbd, DateTime created)
            {
                OrderPrice = orderPrice;
                RealPrice = realPrice;
                Hive = hive;
                Hbd = hbd;
                Created = created;
            }

            [JsonPropertyName("order_price")] public OrderPriceModel OrderPrice { get; }

            [JsonPropertyName("real_price")] public string RealPrice { get; }

            [JsonPropertyName("hive")] public NumberOrStringModel Hive { get; }

            [JsonPropertyName("hbd")] public NumberOrStringModel Hbd { get; }

            [JsonPropertyName("created")] public DateTime Created { get; }
        }
    }
}