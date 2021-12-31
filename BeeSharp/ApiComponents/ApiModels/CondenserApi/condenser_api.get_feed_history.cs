using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_feed_history
    {
        public class CondenserApiGetFeedHistory : ICondenserApiCall<object, CondenserApiFeedHistoryModel>
        {
            public CondenserApiGetFeedHistory()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_feed_history";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiFeedHistoryModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiFeedHistoryModel
        {
            public CondenserApiFeedHistoryModel(NumberOrStringModel id, PriceHistoryEntryModel currentMedianHistory,
                PriceHistoryEntryModel[] priceHistory)
            {
                Id = id;
                CurrentMedianHistory = currentMedianHistory;
                PriceHistory = priceHistory;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("current_median_history")]
            public PriceHistoryEntryModel CurrentMedianHistory { get; }

            [JsonPropertyName("price_history")] public PriceHistoryEntryModel[] PriceHistory { get; }
        }

        public class PriceHistoryEntryModel
        {
            public PriceHistoryEntryModel(string @base, string quote)
            {
                Base = @base;
                Quote = quote;
            }

            [JsonPropertyName("base")] public string Base { get; }

            [JsonPropertyName("quote")] public string Quote { get; }
        }
    }
}