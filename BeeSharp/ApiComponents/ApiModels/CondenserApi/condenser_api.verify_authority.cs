using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace verify_authority
    {
        public class CondenserApiVerifyAuthority
        {
            [JsonPropertyName("query_parameters_json")]
            public QueryParametersJson[] QueryParametersJson { get; set; }

            [JsonPropertyName("methodName")] public static string MethodName => "condenser_api.verify_authority";

            [JsonPropertyName("expected_response_json")]
            public bool ExpectedResponseJson { get; set; }
        }

        public class QueryParametersJson
        {
            [JsonPropertyName("ref_block_num")] public long RefBlockNum { get; set; }

            [JsonPropertyName("ref_block_prefix")] public long RefBlockPrefix { get; set; }

            [JsonPropertyName("expiration")] public DateTimeOffset Expiration { get; set; }

            [JsonPropertyName("operations")] public object[] Operations { get; set; }

            [JsonPropertyName("extensions")] public object[] Extensions { get; set; }

            [JsonPropertyName("signatures")] public object[] Signatures { get; set; }
        }
    }
}