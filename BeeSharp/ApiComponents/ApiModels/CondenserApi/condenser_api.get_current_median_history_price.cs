using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_current_median_history_price
    {
        public class
            CondenserApiGetCurrentMedianHistoryPrice : ICondenserApiCall<object,
                CondenserApiCurrentMedianHistoryPriceModel>
        {
            public CondenserApiGetCurrentMedianHistoryPrice()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")]
            public string MethodName => "condenser_api.get_current_median_history_price";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiCurrentMedianHistoryPriceModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiCurrentMedianHistoryPriceModel
        {
            public CondenserApiCurrentMedianHistoryPriceModel(string @base, string quote)
            {
                Base = @base;
                Quote = quote;
            }

            [JsonPropertyName("base")] public string Base { get; }

            [JsonPropertyName("quote")] public string Quote { get; }
        }
    }
}