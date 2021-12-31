using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace broadcast_block
    {
        public struct CondenserApiBroadcastBlock
        {
            [JsonPropertyName("query_parameters_json")]
            public QueryParametersJson[] QueryParametersJson { get; set; }

            [JsonPropertyName("methodName")] public static string MethodName => "condenser_api.broadcast_block";

            [JsonPropertyName("expected_response_json")]
            public ExpectedResponseJson ExpectedResponseJson { get; set; }
        }

        public struct ExpectedResponseJson
        {
        }

        public struct QueryParametersJson
        {
            [JsonPropertyName("previous")] public string Previous { get; set; }

            [JsonPropertyName("timestamp")] public DateTime Timestamp { get; set; }

            [JsonPropertyName("witness")] public string Witness { get; set; }

            [JsonPropertyName("transaction_merkle_root")]
            public string TransactionMerkleRoot { get; set; }

            [JsonPropertyName("extensions")] public object[] Extensions { get; set; }

            [JsonPropertyName("witness_signature")]
            public string WitnessSignature { get; set; }

            [JsonPropertyName("transactions")] public object[] Transactions { get; set; }
        }
    }
}