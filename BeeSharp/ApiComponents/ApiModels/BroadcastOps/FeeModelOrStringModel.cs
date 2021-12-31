using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;
using BeeSharp.ApiComponents.Condenser.Serialization;
using BeeSharp.Auth.Provider;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    [JsonConverter(typeof(FeeModelOrStringJsonConverter))]
    public class FeeModelOrStringModel : ISerializableElement
    {
        public FeeModelOrStringModel(string? stringValue, FeeModel? feeModelValue = null)
        {
            StringValue = stringValue;
            FeeModelValue = feeModelValue;
        }

        public string? StringValue { get; }

        public FeeModel? FeeModelValue { get; }

        public byte[] SerializeOperation()
        {
            if (string.IsNullOrWhiteSpace(StringValue)) return FeeModelValue!.SerializeOperation();

            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            // Create FeeModel from string
            // String has to be in format: "f.loat UNITS"
            // Requires three components: amount, precision and symbol
            var strParts = StringValue.Split(" ");
            if (strParts.Length != 2) throw new ArgumentException($"Cannot parse invalid string: {StringValue}");

            var amount = decimal.Parse(strParts[0], CultureInfo.InvariantCulture.NumberFormat);
            var precision = ChainParameterProvider.Get().FeePrecision;
            var symbol = strParts[1];

            // Calculate value: Round to given precision, then convert it to int
            var decimalValue = decimal.Round(amount, precision);
            // Direct conversion would cut off the digits right to the decimal point.
            // Since we want to keep this information, we "shift" the numbers precision decimal positions to the left
            // by multiplying it with 10 * precision
            var longValue = (long) (decimalValue * (int) Math.Pow(10, precision));
            writer.Write(longValue);
            writer.Write((char) precision);

            // Using result, because the string length prefix is not needed here
            result.Write(Encoding.ASCII.GetBytes(symbol));

            // symbol requires additional postponed padding with 0-bytes
            result.Write(new byte[7 - symbol.Length]);

            return result.ToArray();
        }
    }
}