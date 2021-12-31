using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace proposal_pay
    {
        [VirtualBroadcastOp("proposal_pay")]
        public class BroadcastVirtualOpProposalPayModel : VirtualBroadcastOperation
        {
            /// <summary>
            ///     Receive a proposal payment.
            /// </summary>
            /// <param name="receiver">The account that received the payment.</param>
            /// <param name="payment">The payment received.</param>
            /// <param name="trxId">The transaction id.</param>
            /// <param name="opInTrx">operation index in transaction.</param>
            public BroadcastVirtualOpProposalPayModel(string receiver, string payment, string trxId,
                NumberOrStringModel opInTrx)
            {
                Receiver = receiver;
                Payment = payment;
                TrxId = trxId;
                OpInTrx = opInTrx;
            }

            [JsonPropertyName("receiver")] public string Receiver { get; }

            [JsonPropertyName("payment")] public string Payment { get; }

            [JsonPropertyName("trx_id")] public string TrxId { get; }

            [JsonPropertyName("op_in_trx")] public NumberOrStringModel OpInTrx { get; }
        }
    }
}