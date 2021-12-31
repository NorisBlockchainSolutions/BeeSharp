using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_market_history_buckets
    {
        public class CondenserApiGetMarketHistoryBuckets : ICondenserApiCall<object, List<long>>
        {
            public CondenserApiGetMarketHistoryBuckets()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_market_history_buckets";

            [JsonPropertyName("expected_response_json")]
            public List<long>? ExpectedResponseJson { get; }
        }
    }
}