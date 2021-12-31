using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.Filter;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_account_history
    {
        /// <summary>
        ///     Returns a history of all operations for a given account.
        /// </summary>
        public class CondenserApiGetAccountHistory : ICondenserApiCall<object, List<CondenserApiAccountHistoryModel>>
        {
            /// <param name="account">The name of the account.</param>
            /// <param name="start">The start offset. -1 for reverse history or any positive numeric.</param>
            /// <param name="limit">the limit of how many history operations to retrieve. Up to 1000.</param>
            /// <param name="operationFilterLow">First 64 operations.</param>
            /// <param name="operationFilterHigh">
            ///     For higher-numbered operations.
            ///     128-bitmask of {filterLow, filterHigh}
            /// </param>
            public CondenserApiGetAccountHistory(string account, int start, ushort limit,
                OperationFilterLow operationFilterLow = OperationFilterLow.None,
                OperationFilterHigh operationFilterHigh = OperationFilterHigh.None)
            {
                var operationFilterLowNbr = (long) operationFilterLow;
                var operationFilterHighNbr = (long) operationFilterHigh;

                if (operationFilterLowNbr == 0 && operationFilterHighNbr == 0)
                    QueryParametersJson = new object[]
                    {
                        account,
                        start,
                        limit
                    };
                else if (operationFilterLowNbr != 0 &&
                         operationFilterHighNbr == 0)
                    QueryParametersJson = new object[]
                    {
                        account,
                        start,
                        limit,
                        operationFilterLowNbr
                    };
                else if (operationFilterHighNbr != 0)
                    QueryParametersJson = new object[]
                    {
                        account,
                        start,
                        limit,
                        operationFilterLowNbr,
                        operationFilterHighNbr
                    };
                else
                    throw new ArgumentException("Cannot set FilterHigh without FilterLow!");

                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_account_history";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiAccountHistoryModel>? ExpectedResponseJson { get; }
        }

        [JsonConverter(typeof(GetAccountHistoryJsonConverter))]
        public class CondenserApiAccountHistoryModel
        {
            public CondenserApiAccountHistoryModel(NumberOrStringModel id,
                CondenserApiHistoryInfoModel condenserApiHistoryInfoModel)
            {
                Id = id;
                CondenserApiHistoryInfoModel = condenserApiHistoryInfoModel;
            }

            public NumberOrStringModel Id { get; }

            public CondenserApiHistoryInfoModel CondenserApiHistoryInfoModel { get; }
        }

        public class CondenserApiHistoryInfoModel
        {
            public CondenserApiHistoryInfoModel(string trxId, NumberOrStringModel block, NumberOrStringModel trxInBlock,
                NumberOrStringModel opInTrx, NumberOrStringModel virtualOp, DateTime timestamp, BroadcastOpModel op)
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