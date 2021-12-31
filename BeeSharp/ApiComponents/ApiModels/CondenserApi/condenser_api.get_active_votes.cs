using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_active_votes
    {
        public class CondenserApiGetActiveVotes : ICondenserApiCall<string, List<CondenserApiActiveVoteModel>>
        {
            public CondenserApiGetActiveVotes(string account, string permLink)
            {
                QueryParametersJson = new[] {account, permLink};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_active_votes";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiActiveVoteModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiActiveVoteModel
        {
            public CondenserApiActiveVoteModel(string voter, NumberOrStringModel weight, NumberOrStringModel rShares,
                NumberOrStringModel percent, NumberOrStringModel reputation, DateTime time)
            {
                Voter = voter;
                Weight = weight;
                RShares = rShares;
                Percent = percent;
                Reputation = reputation;
                Time = time;
            }

            [JsonPropertyName("percent")] public NumberOrStringModel Percent { get; }

            [JsonPropertyName("reputation")] public NumberOrStringModel Reputation { get; }

            [JsonPropertyName("rshares")] public NumberOrStringModel RShares { get; }

            [JsonPropertyName("time")] public DateTime Time { get; }

            [JsonPropertyName("voter")] public string Voter { get; }

            [JsonPropertyName("weight")] public NumberOrStringModel Weight { get; }
        }
    }
}