using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace account_witness_vote
    {
        [BroadcastOp("account_witness_vote")]
        public class BroadcastOpAccountWitnessVoteModel : BroadcastOperation
        {
            /// <summary>
            ///     (Un-)Vote a witness.
            /// </summary>
            /// <param name="account">The voting account.</param>
            /// <param name="witness">The witness account.</param>
            /// <param name="approve">Whether to vote (true) or unvote (false) the witness account.</param>
            public BroadcastOpAccountWitnessVoteModel(string account, string witness, bool approve)
            {
                Account = account;
                Witness = witness;
                Approve = approve;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("witness")] public string Witness { get; }

            [JsonPropertyName("approve")] public bool Approve { get; }
        }
    }
}