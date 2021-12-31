using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.Condenser.CallComponents.ErrorDetails
{
    public struct CondenserApiErrorStackElementDataBlock
    {
        [JsonPropertyName("previous")] public string Previous { get; set; }
        [JsonPropertyName("timestamp")] public DateTime Timestamp { get; set; }
        [JsonPropertyName("witness")] public string Witness { get; set; }

        [JsonPropertyName("transaction_merkle_root")]
        public string TransactionMerkleRoot { get; set; }

        [JsonPropertyName("extensions")] public List<string> Extensions { get; set; }

        [JsonPropertyName("witness_signature")]
        public string WitnessSignature { get; set; }

        [JsonPropertyName("transactions")] public List<string> Transactions { get; set; }
    }
}