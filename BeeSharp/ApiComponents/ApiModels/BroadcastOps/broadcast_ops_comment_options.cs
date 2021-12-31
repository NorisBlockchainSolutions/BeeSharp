using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;
using BeeSharp.root.Helper;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace comment_options
    {
        [BroadcastOp("comment_options")]
        public class BroadcastOpCommentOptionsModel : BroadcastOperation
        {
            public BroadcastOpCommentOptionsModel(string author, string permLink, FeeModelOrStringModel maxAcceptedPayout,
                NumberOrStringModel percentHbd, bool allowVotes, bool allowCurationRewards, ExtensionModel[] extensions)
            {
                Author = author;
                PermLink = permLink;
                MaxAcceptedPayout = maxAcceptedPayout;
                PercentHbd = percentHbd;
                AllowVotes = allowVotes;
                AllowCurationRewards = allowCurationRewards;
                Extensions = extensions;
            }

            [JsonPropertyName("author")] public string Author { get; }

            [JsonPropertyName("permlink")] public string PermLink { get; }

            [JsonPropertyName("max_accepted_payout")]
            public FeeModelOrStringModel MaxAcceptedPayout { get; }

            [JsonPropertyName("percent_hbd")] public NumberOrStringModel PercentHbd { get; }

            [JsonPropertyName("allow_votes")] public bool AllowVotes { get; }

            [JsonPropertyName("allow_curation_rewards")]
            public bool AllowCurationRewards { get; }

            [JsonPropertyName("extensions")] public ExtensionModel[] Extensions { get; }
        }

        [JsonConverter(typeof(ExtensionModelJsonConverter))]
        public class ExtensionModel
        {
            public ExtensionModel(NumberOrStringModel id, BeneficiaryModel[]? beneficiaries = null, string? info = null)
            {
                Id = id;
                Beneficiaries = beneficiaries;
                Info = info;
            }

            public NumberOrStringModel Id { get; }
            [JsonPropertyName("beneficiaries")] public BeneficiaryModel[]? Beneficiaries { get; }
            public string? Info;

            public byte[] GetSerialized()
            {
                var result = new MemoryStream();
                var writer = new BinaryWriter(result, Encoding.UTF8);
                result.Write(ByteHelper.LongToShortestUnsignedByteArray(Id.NumericValue));
                
                if (Info is not null)
                {
                    writer.Write(Info);
                }
                else if (Beneficiaries is not null)
                {
                    result.Write(ByteHelper.IntToShortestUnsignedByteArray(Beneficiaries.Length));
                    foreach (var beneficiary in Beneficiaries) writer.Write(beneficiary.GetSerialized());
                }

                return result.ToArray();
            }
        }

        public class BeneficiaryModel
        {
            public BeneficiaryModel(string account, NumberOrStringModel weight)
            {
                Account = account;
                Weight = weight;
            }

            [JsonPropertyName("account")] public string Account { get; }
            [JsonPropertyName("weight")] public NumberOrStringModel Weight { get; }

            public byte[] GetSerialized()
            {
                var result = new MemoryStream();
                var writer = new BinaryWriter(result, Encoding.UTF8);
                writer.Write(Account);
                result.Write(ByteHelper.LongToShortestUnsignedByteArray(Weight.NumericValue));
                return result.ToArray();
            }
        }
    }
}