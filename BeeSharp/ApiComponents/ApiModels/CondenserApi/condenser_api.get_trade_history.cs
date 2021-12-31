using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_trade_history
    {
        public class CondenserApiGetTradeHistory : ICondenserApiCall<object, List<CondenserApiTradeHistoryModel>>
        {
            public CondenserApiGetTradeHistory(DateTime start, DateTime end, [Range(-1, 1000)] short limit)
            {
                QueryParametersJson = new[] {start, end, (object) limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_trade_history";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiTradeHistoryModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiTradeHistoryModel
        {
            public CondenserApiTradeHistoryModel(DateTime date, string currentPays, string openPays)
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