using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    public class CondenserApiBlogActiveVoteModel
    {
        public CondenserApiBlogActiveVoteModel(NumberOrStringModel percent, NumberOrStringModel reputation,
            NumberOrStringModel rShares, DateTime time, string voter, NumberOrStringModel weight)
        {
            Percent = percent;
            Reputation = reputation;
            RShares = rShares;
            Time = time;
            Voter = voter;
            Weight = weight;
        }

        [JsonPropertyName("percent")] public NumberOrStringModel Percent { get; }

        [JsonPropertyName("reputation")] public NumberOrStringModel Reputation { get; }

        [JsonPropertyName("rshares")] public NumberOrStringModel RShares { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("time")]
        public DateTime Time { get; }

        [JsonPropertyName("voter")] public string Voter { get; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("weight")]
        public NumberOrStringModel Weight { get; }
    }
}