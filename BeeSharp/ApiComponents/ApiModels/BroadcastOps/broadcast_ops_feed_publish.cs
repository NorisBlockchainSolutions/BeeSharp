using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace feed_publish
    {
        [BroadcastOp("feed_publish")]
        public class BroadcastOpFeedPublishModel : BroadcastOperation
        {
            /// <summary>
            ///     Feed can only be published by the top N (currently 20) witnesses that are included every round.
            /// </summary>
            /// <param name="publisher">The witness that publishes the feed.</param>
            /// <param name="exchangeRateModel">The feed.</param>
            public BroadcastOpFeedPublishModel(string publisher, ExchangeRateModel exchangeRateModel)
            {
                Publisher = publisher;
                ExchangeRateModel = exchangeRateModel;
            }

            [JsonPropertyName("publisher")] public string Publisher { get; }

            [JsonPropertyName("exchange_rate")] public ExchangeRateModel ExchangeRateModel { get; }
        }
    }
}