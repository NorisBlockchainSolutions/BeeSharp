using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_block_header
    {
        public class CondenserApiGetBlockHeader : ICondenserApiCall<long, CondenserApiBlockHeaderModel>
        {
            public CondenserApiGetBlockHeader(long blockNumber)
            {
                QueryParametersJson = new[] {blockNumber};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public long[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_block_header";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiBlockHeaderModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiBlockHeaderModel
        {
            public CondenserApiBlockHeaderModel(string previous, DateTime timestamp, string witness,
                string transactionMerkleRoot,
                ExtensionModel[] extensions)
            {
                Previous = previous;
                Timestamp = timestamp;
                Witness = witness;
                TransactionMerkleRoot = transactionMerkleRoot;
                Extensions = extensions;
            }

            [JsonPropertyName("previous")] public string Previous { get; }

            [JsonPropertyName("timestamp")] public DateTime Timestamp { get; }

            [JsonPropertyName("witness")] public string Witness { get; }

            [JsonPropertyName("transaction_merkle_root")]
            public string TransactionMerkleRoot { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }
    }
}