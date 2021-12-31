using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace broadcast_transaction_synchronous
    {
        public struct CondenserApiBroadcastTransactionSynchronous
        {
            [JsonPropertyName("query_parameters_json")]
            public QueryParametersJson[] QueryParametersJson { get; set; }

            [JsonPropertyName("methodName")]
            public static string MethodName => "condenser_api.broadcast_transaction_synchronous";

            [JsonPropertyName("expected_response_json")]
            public ExpectedResponseJson ExpectedResponseJson { get; set; }
        }

        public struct ExpectedResponseJson
        {
            [JsonPropertyName("id")] public string Id { get; set; }

            [JsonPropertyName("block_num")] public long BlockNum { get; set; }

            [JsonPropertyName("trx_num")] public long TrxNum { get; set; }

            [JsonPropertyName("expired")] public bool Expired { get; set; }
        }

        public struct QueryParametersJson
        {
            [JsonPropertyName("ref_block_num")] public long RefBlockNum { get; set; }

            [JsonPropertyName("ref_block_prefix")] public long RefBlockPrefix { get; set; }

            [JsonPropertyName("expiration")] public DateTime Expiration { get; set; }

            [JsonPropertyName("operations")] public object[] Operations { get; set; }

            [JsonPropertyName("extensions")] public object[] Extensions { get; set; }

            [JsonPropertyName("signatures")] public object[] Signatures { get; set; }
        }
    }
}