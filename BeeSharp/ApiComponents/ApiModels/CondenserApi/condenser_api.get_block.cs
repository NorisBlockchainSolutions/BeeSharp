using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_block
    {
        public class CondenserApiGetBlock : ICondenserApiCall<long, CondenserApiBlockModel>
        {
            public CondenserApiGetBlock(long blockNumber)
            {
                QueryParametersJson = new[] {blockNumber};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public long[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_block";

            [JsonPropertyName("expected_response_json")]
            public CondenserApiBlockModel? ExpectedResponseJson { get; }
        }

        public class CondenserApiBlockModel
        {
            public CondenserApiBlockModel(string previous, DateTime timestamp, string witness,
                string transactionMerkleRoot, ExtensionModel[] extensions, string witnessSignature,
                CondenserApiTransactionModel[] transactions, string blockId, string signingKey, string[] transactionIds)
            {
                Previous = previous;
                Timestamp = timestamp;
                Witness = witness;
                TransactionMerkleRoot = transactionMerkleRoot;
                Extensions = extensions;
                WitnessSignature = witnessSignature;
                Transactions = transactions;
                BlockId = blockId;
                SigningKey = signingKey;
                TransactionIds = transactionIds;
            }

            [JsonPropertyName("previous")] public string Previous { get; }

            [JsonPropertyName("timestamp")] public DateTime Timestamp { get; }

            [JsonPropertyName("witness")] public string Witness { get; }

            [JsonPropertyName("transaction_merkle_root")]
            public string TransactionMerkleRoot { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }

            [JsonPropertyName("witness_signature")]
            public string WitnessSignature { get; }

            [JsonPropertyName("transactions")] public CondenserApiTransactionModel[] Transactions { get; }

            [JsonPropertyName("block_id")] public string BlockId { get; }

            [JsonPropertyName("signing_key")] public string SigningKey { get; }

            [JsonPropertyName("transaction_ids")] public string[] TransactionIds { get; }
        }
    }
}