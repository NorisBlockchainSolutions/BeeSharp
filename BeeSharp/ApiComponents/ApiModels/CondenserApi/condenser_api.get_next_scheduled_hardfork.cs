using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_next_scheduled_hardfork
    {
        public class
            CondenserApiGetNextScheduledHardfork : ICondenserApiCall<object, CondenserApiNextScheduledHardforkModel>
        {
            public CondenserApiGetNextScheduledHardfork()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_next_scheduled_hardfork";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiNextScheduledHardforkModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiNextScheduledHardforkModel
        {
            public CondenserApiNextScheduledHardforkModel(string hfVersion, DateTime liveTime)
            {
                HfVersion = hfVersion;
                LiveTime = liveTime;
            }

            [JsonPropertyName("hf_version")] public string HfVersion { get; }

            [JsonPropertyName("live_time")] public DateTime LiveTime { get; }
        }
    }
}