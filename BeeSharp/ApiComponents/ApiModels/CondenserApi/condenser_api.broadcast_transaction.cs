using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api;
using BeeSharp.ApiComponents.Condenser;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace broadcast_transaction
    {
        public class
            CondenserApiBroadcastTransaction : ICondenserApiCall<CondenserApiBroadcastTransactionQueryParametersJson,
                object>
        {
            public CondenserApiBroadcastTransaction(ushort refBlockNum, uint refBlockPrefix, DateTime expiration,
                IReadOnlyList<ISerializableOperation> operations, string[] signatures,
                ExtensionModel[]? extensions = null)
            {
                QueryParametersJson = new[]
                {
                    new CondenserApiBroadcastTransactionQueryParametersJson(
                        refBlockNum, refBlockPrefix, expiration,
                        GetJsonReadableOperations(operations), extensions ?? Array.Empty<ExtensionModel>(), signatures)
                };
                ExpectedResponseJson = null!;
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiBroadcastTransactionQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.broadcast_transaction";

            [JsonPropertyName("expected_response_json")]
            public object ExpectedResponseJson { get; }

            private static object[][] GetJsonReadableOperations(IReadOnlyList<ISerializableOperation> operations)
            {
                // Operations have the structure [ [ opName, {OperationName} ] ]
                var result = new object[operations.Count][];
                for (var i = 0; i < operations.Count; i++)
                {
                    result[i] = new object[2];
                    result[i][0] = operations[i].GetOperationName();
                    result[i][1] = operations[i].GetOperationModel();
                }

                return result;
            }
        }

        public class CondenserApiBroadcastTransactionQueryParametersJson
        {
            public CondenserApiBroadcastTransactionQueryParametersJson(ushort refBlockNum, uint refBlockPrefix,
                DateTime expiration, object[][] operations, ExtensionModel[] extensions,
                string[] signatures)
            {
                RefBlockNum = refBlockNum;
                RefBlockPrefix = refBlockPrefix;
                Expiration = expiration;
                Operations = operations;
                Extensions = extensions;
                Signatures = signatures;
            }

            [JsonPropertyName("ref_block_num")] public ushort RefBlockNum { get; }

            [JsonPropertyName("ref_block_prefix")] public uint RefBlockPrefix { get; }

            [JsonConverter(typeof(ApiTimeFormatDateTimeConverter))]
            [JsonPropertyName("expiration")]
            public DateTime Expiration { get; }

            [JsonPropertyName("operations")] public object[][] Operations { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }

            [JsonPropertyName("signatures")] public string[] Signatures { get; }
        }
    }
}