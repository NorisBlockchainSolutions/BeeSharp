using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_volume
    {
        public class CondenserApiGetVolume : ICondenserApiCall<object, CondenserApiMarketVolumeModel>
        {
            public CondenserApiGetVolume()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_volume";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiMarketVolumeModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiMarketVolumeModel
        {
            public CondenserApiMarketVolumeModel(string hiveVolume, string hbdVolume)
            {
                HiveVolume = hiveVolume;
                HbdVolume = hbdVolume;
            }

            [JsonPropertyName("hive_volume")] public string HiveVolume { get; }

            [JsonPropertyName("hbd_volume")] public string HbdVolume { get; }
        }
    }
}