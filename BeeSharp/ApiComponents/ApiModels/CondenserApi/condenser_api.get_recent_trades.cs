using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_recent_trades
    {
        public class CondenserApiGetRecentTrades : ICondenserApiCall<int, List<CondenserApiRecentTradesModel>>
        {
            public CondenserApiGetRecentTrades([Range(-1, 1000)] int limit)
            {
                QueryParametersJson = new[] {limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public int[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_recent_trades";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiRecentTradesModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiRecentTradesModel
        {
            public CondenserApiRecentTradesModel(DateTime date, string currentPays, string openPays)
            {
                Date = date;
                CurrentPays = currentPays;
                OpenPays = openPays;
            }

            [JsonPropertyName("date")] public DateTime Date { get; }

            [JsonPropertyName("current_pays")] public string CurrentPays { get; }

            [JsonPropertyName("open_pays")] public string OpenPays { get; }
        }
    }
}