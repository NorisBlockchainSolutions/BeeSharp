using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_ticker
    {
        public class CondenserApiGetTicker : ICondenserApiCall<object, CondenserApiTickerModel>
        {
            public CondenserApiGetTicker()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_ticker";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiTickerModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiTickerModel
        {
            public CondenserApiTickerModel(string latest, string lowestAsk, string highestBid, string percentChange,
                string hiveVolume, string hbdVolume)
            {
                Latest = latest;
                LowestAsk = lowestAsk;
                HighestBid = highestBid;
                PercentChange = percentChange;
                HiveVolume = hiveVolume;
                HbdVolume = hbdVolume;
            }

            [JsonPropertyName("latest")] public string Latest { get; }

            [JsonPropertyName("lowest_ask")] public string LowestAsk { get; }

            [JsonPropertyName("highest_bid")] public string HighestBid { get; }

            [JsonPropertyName("percent_change")] public string PercentChange { get; }

            [JsonPropertyName("hive_volume")] public string HiveVolume { get; }

            [JsonPropertyName("hbd_volume")] public string HbdVolume { get; }
        }
    }
}