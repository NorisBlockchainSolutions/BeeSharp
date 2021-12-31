using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_market_history
    {
        public class CondenserApiGetMarketHistory : ICondenserApiCall<object, List<CondenserApiMarketHistoryEntryModel>>
        {
            public CondenserApiGetMarketHistory(int bucketSeconds, DateTime start, DateTime end)
            {
                QueryParametersJson = new[] {(object) bucketSeconds, start, end};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_market_history";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiMarketHistoryEntryModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiMarketHistoryEntryModel
        {
            public CondenserApiMarketHistoryEntryModel(NumberOrStringModel id, DateTime open,
                NumberOrStringModel seconds, CondenserApiHiveMarketHistoryModel condenserApiHive,
                CondenserApiHiveMarketHistoryModel nonCondenserApiHive)
            {
                Id = id;
                Open = open;
                Seconds = seconds;
                CondenserApiHive = condenserApiHive;
                NonCondenserApiHive = nonCondenserApiHive;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("open")] public DateTime Open { get; }

            [JsonPropertyName("seconds")] public NumberOrStringModel Seconds { get; }

            [JsonPropertyName("hive")] public CondenserApiHiveMarketHistoryModel CondenserApiHive { get; }

            [JsonPropertyName("non_hive")] public CondenserApiHiveMarketHistoryModel NonCondenserApiHive { get; }
        }

        public class CondenserApiHiveMarketHistoryModel
        {
            public CondenserApiHiveMarketHistoryModel(NumberOrStringModel high, NumberOrStringModel low,
                NumberOrStringModel open, NumberOrStringModel close, NumberOrStringModel volume)
            {
                High = high;
                Low = low;
                Open = open;
                Close = close;
                Volume = volume;
            }

            [JsonPropertyName("high")] public NumberOrStringModel High { get; }

            [JsonPropertyName("low")] public NumberOrStringModel Low { get; }

            [JsonPropertyName("open")] public NumberOrStringModel Open { get; }

            [JsonPropertyName("close")] public NumberOrStringModel Close { get; }

            [JsonPropertyName("volume")] public NumberOrStringModel Volume { get; }
        }
    }
}