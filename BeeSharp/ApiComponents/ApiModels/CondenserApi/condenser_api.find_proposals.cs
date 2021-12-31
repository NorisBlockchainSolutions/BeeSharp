using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace find_proposals
    {
        /// <summary>
        ///     Finds proposals by proposal.id
        /// </summary>
        public class CondenserApiFindProposals : ICondenserApiCall<int[], List<CondenserApiProposalModel>>
        {
            public CondenserApiFindProposals(int[] proposalIds)
            {
                QueryParametersJson = new[] {proposalIds};
                ExpectedResponseJson = new List<CondenserApiProposalModel>();
            }

            [JsonPropertyName("query_parameters_json")]
            public int[][] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.find_proposals";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiProposalModel> ExpectedResponseJson { get; }
        }
    }
}