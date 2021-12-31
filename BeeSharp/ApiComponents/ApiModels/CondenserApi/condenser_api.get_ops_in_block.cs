using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_ops_in_block
    {
        public class CondenserApiGetOpsInBlock : ICondenserApiCall<object, List<CondenserApiBlockOperationModel>>
        {
            public CondenserApiGetOpsInBlock(NumberOrStringModel blockNumber, bool onlyVirtual)
            {
                QueryParametersJson = new[] {(object) blockNumber, onlyVirtual};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_ops_in_block";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiBlockOperationModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiBlockOperationModel
        {
            public CondenserApiBlockOperationModel(string trxId, NumberOrStringModel block,
                NumberOrStringModel trxInBlock, NumberOrStringModel opInTrx, NumberOrStringModel virtualOp,
                DateTime timestamp, BroadcastOpModel op)
            {
                TrxId = trxId;
                Block = block;
                TrxInBlock = trxInBlock;
                OpInTrx = opInTrx;
                VirtualOp = virtualOp;
                Timestamp = timestamp;
                Op = op;
            }

            [JsonPropertyName("trx_id")] public string TrxId { get; }

            [JsonPropertyName("block")] public NumberOrStringModel Block { get; }

            [JsonPropertyName("trx_in_block")] public NumberOrStringModel TrxInBlock { get; }

            [JsonPropertyName("op_in_trx")] public NumberOrStringModel OpInTrx { get; }

            [JsonPropertyName("virtual_op")] public NumberOrStringModel VirtualOp { get; }

            [JsonPropertyName("timestamp")] public DateTime Timestamp { get; }

            [JsonPropertyName("op")] public BroadcastOpModel Op { get; }
        }
    }
}