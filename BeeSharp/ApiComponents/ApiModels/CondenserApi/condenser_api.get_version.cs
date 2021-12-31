using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_version
    {
        public class CondenserApiGetVersion : ICondenserApiCall<object, CondenserApiVersionInfoModel>
        {
            public CondenserApiGetVersion()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_version";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiVersionInfoModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiVersionInfoModel
        {
            public CondenserApiVersionInfoModel(string blockchainVersion, string hiveRevision, string fcRevision,
                string chainId)
            {
                BlockchainVersion = blockchainVersion;
                HiveRevision = hiveRevision;
                FcRevision = fcRevision;
                ChainId = chainId;
            }

            [JsonPropertyName("blockchain_version")]
            public string BlockchainVersion { get; }

            [JsonPropertyName("hive_revision")] public string HiveRevision { get; }

            [JsonPropertyName("fc_revision")] public string FcRevision { get; }

            [JsonPropertyName("chain_id")] public string ChainId { get; }
        }
    }
}