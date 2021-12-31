using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace fill_convert_request
    {
        [VirtualBroadcastOp("fill_convert_request")]
        public class BroadcastVirtualOpFillConvertRequestModel : VirtualBroadcastOperation
        {
            /// <summary>
            ///     Fills a HBD to HIVE conversion request (after 3.5 days).
            ///     Fills with a conversion date before the head block time and converts them at the current median price
            ///     feed history price times the premium.
            /// </summary>
            /// <param name="author">The account that sent the conversion request.</param>
            /// <param name="requestId">The request id.</param>
            /// <param name="amountIn">The amount of HBD for conversion.</param>
            /// <param name="amountOut">The amount of HIVE from the conversion.</param>
            public BroadcastVirtualOpFillConvertRequestModel(string author, NumberOrStringModel requestId,
                string amountIn, string amountOut)
            {
                Author = author;
                RequestId = requestId;
                AmountIn = amountIn;
                AmountOut = amountOut;
            }

            [JsonPropertyName("owner")] public string Author { get; }

            [JsonPropertyName("requestid")] public NumberOrStringModel RequestId { get; }

            [JsonPropertyName("amount_in")] public string AmountIn { get; }

            [JsonPropertyName("amount_out")] public string AmountOut { get; }
        }
    }
}