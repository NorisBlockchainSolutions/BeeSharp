using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.comment_options;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace witness_set_properties
    {
        [BroadcastOp("witness_set_properties")]
        public class BroadcastOpWitnessSetPropertiesModel : BroadcastOperation
        {
            public BroadcastOpWitnessSetPropertiesModel(string owner, WitnessPropertiesModel properties,
                ExtensionModel[] extensions)
            {
                Owner = owner;
                Properties = properties;
                Extensions = extensions;
            }

            [JsonPropertyName("owner")] public string Owner { get; }

            [JsonConverter(typeof(WitnessPropertiesJsonConverter))]
            [JsonPropertyName("props")] public WitnessPropertiesModel Properties { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }

        public class WitnessPropertiesModel
        {
            [JsonPropertyName("account_creation_fee")]
            public string? AccountCreationFee { get; set; }

            [JsonPropertyName("account_subsidy_budget")]
            public NumberOrStringModel? AccountSubsidyBudget { get; set; }

            [JsonPropertyName("account_subsidy_decay")]
            public NumberOrStringModel? AccountSubsidyDecay { get; set; }

            [JsonPropertyName("maximum_block_size")]
            public NumberOrStringModel? MaximumBlockSize { get; set; }

            [JsonPropertyName("hbd_interest_rate")]
            public string? HbdInterestRate { get; set; }

            [JsonPropertyName("hbd_exchange_rate")]
            public string? HbdExchangeRate { get; set; }

            [JsonPropertyName("url")] public string? Url { get; set; }

            [JsonPropertyName("key")] public string? Key { get; set; }
            [JsonPropertyName("new_signing_key")] public string? NewSigningKey { get; set; }
            
            public WitnessPropertiesModel(string? accountCreationFee = null,
                NumberOrStringModel? accountSubsidyBudget = null,
                NumberOrStringModel? accountSubsidyDecay = null,
                NumberOrStringModel? maximumBlockSize = null,
                string? hbdInterestRate = null,
                string? hbdExchangeRate = null,
                string? url = null,
                string? key = null,
                string? newSigningKey = null)
            {
                AccountCreationFee = accountCreationFee;
                AccountSubsidyBudget = accountSubsidyBudget;
                AccountSubsidyDecay = accountSubsidyDecay;
                MaximumBlockSize = maximumBlockSize;
                HbdInterestRate = hbdInterestRate;
                HbdExchangeRate = hbdExchangeRate;
                Url = url;
                Key = key;
                NewSigningKey = newSigningKey;
            }
        }

        public class HbdExchangeRateModel
        {
            public HbdExchangeRateModel(string @base, string quote)
            {
                Base = @base;
                Quote = quote;
            }

            [JsonPropertyName("base")] public string Base { get; }
            [JsonPropertyName("quote")] public string Quote { get; }
        }
    }
}