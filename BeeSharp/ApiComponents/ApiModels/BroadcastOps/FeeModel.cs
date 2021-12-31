using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    public class FeeModel : ISerializableElement
    {
        public FeeModel(string amount, NumberOrStringModel precision, string nai)
        {
            Amount = amount;
            Precision = precision;
            Nai = nai;
        }

        [JsonPropertyName("amount")] public string Amount { get; }

        [JsonPropertyName("precision")] public NumberOrStringModel Precision { get; }

        [JsonPropertyName("nai")] public string Nai { get; }

        public byte[] SerializeOperation()
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            writer.Write(Amount);
            writer.Write(Precision.NumericValue);
            writer.Write(Nai);

            return result.ToArray();
        }
    }
}