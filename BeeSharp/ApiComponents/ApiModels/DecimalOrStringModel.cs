using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels
{
    [JsonConverter(typeof(DecimalOrStringJsonConverter))]
    public class DecimalOrStringModel : ISerializableElement
    {
        public DecimalOrStringModel(string value)
        {
            Value = value;
            OrigType = typeof(string);
        }

        public DecimalOrStringModel(decimal value)
        {
            Value = value.ToString(CultureInfo.InvariantCulture);
            OrigType = typeof(decimal);
        }

        public string Value { get; }

        public decimal NumericValue => Convert.ToDecimal(Value);

        public Type OrigType { get; }

        public byte[] SerializeOperation()
        {
            var result = new MemoryStream();
            var writer = new BinaryWriter(result, Encoding.UTF8);

            if (OrigType == typeof(string)) writer.Write(Value);
            else writer.Write(NumericValue);

            return result.ToArray();
        }
    }
}