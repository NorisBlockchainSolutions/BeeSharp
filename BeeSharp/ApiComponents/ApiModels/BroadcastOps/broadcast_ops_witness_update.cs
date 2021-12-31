using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace witness_update
    {
        [BroadcastOp("witness_update")]
        public class BroadcastOpWitnessUpdateModel : BroadcastOperation
        {
            public BroadcastOpWitnessUpdateModel(string owner, string url, string blockSigningKey,
                WitnessUpdatePropertiesModel properties, FeeModelOrStringModel fee)
            {
                Owner = owner;
                Url = url;
                BlockSigningKey = blockSigningKey;
                Properties = properties;
                Fee = fee;
            }

            [JsonPropertyName("owner")] public string Owner { get; }

            [JsonPropertyName("url")] public string Url { get; }

            [JsonPropertyName("block_signing_key")]
            public string BlockSigningKey { get; }

            [JsonPropertyName("props")] public WitnessUpdatePropertiesModel Properties { get; }

            [JsonPropertyName("fee")] public FeeModelOrStringModel Fee { get; }
        }

        public class WitnessUpdatePropertiesModel
        {
            public WitnessUpdatePropertiesModel(FeeModelOrStringModel accountCreationFee,
                NumberOrStringModel maximumBlockSize, NumberOrStringModel hbdInterestRate)
            {
                AccountCreationFee = accountCreationFee;
                MaximumBlockSize = maximumBlockSize;
                HbdInterestRate = hbdInterestRate;
            }

            [JsonPropertyName("account_creation_fee")]
            public FeeModelOrStringModel AccountCreationFee { get; }

            [JsonPropertyName("maximum_block_size")]
            public NumberOrStringModel MaximumBlockSize { get; }

            [JsonPropertyName("hbd_interest_rate")]
            public NumberOrStringModel HbdInterestRate { get; }
        }
    }
}