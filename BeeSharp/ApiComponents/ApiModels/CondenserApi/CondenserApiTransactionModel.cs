using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    public class CondenserApiTransactionModel
    {
        public CondenserApiTransactionModel(NumberOrStringModel refBlockNumber, NumberOrStringModel refBlockPrefix,
            DateTime expiration, BroadcastOpModel[] operation, ExtensionModel[] extensions, string[] signatures,
            string transactionId, NumberOrStringModel blockNumber, NumberOrStringModel transactionNumber)
        {
            RefBlockNumber = refBlockNumber;
            RefBlockPrefix = refBlockPrefix;
            Expiration = expiration;
            Operation = operation;
            Extensions = extensions;
            Signatures = signatures;
            TransactionId = transactionId;
            BlockNumber = blockNumber;
            TransactionNumber = transactionNumber;
        }

        [JsonPropertyName("ref_block_num")] public NumberOrStringModel RefBlockNumber { get; }

        [JsonPropertyName("ref_block_prefix")] public NumberOrStringModel RefBlockPrefix { get; }

        [JsonPropertyName("expiration")] public DateTime Expiration { get; }

        [JsonPropertyName("operations")] public BroadcastOpModel[] Operation { get; }

        [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }

        [JsonPropertyName("signatures")] public string[] Signatures { get; }

        [JsonPropertyName("transaction_id")] public string TransactionId { get; }

        [JsonPropertyName("block_num")] public NumberOrStringModel BlockNumber { get; }

        [JsonPropertyName("transaction_num")] public NumberOrStringModel TransactionNumber { get; }
    }
}