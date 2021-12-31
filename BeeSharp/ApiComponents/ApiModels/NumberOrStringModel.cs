using System;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api;
using BeeSharp.ApiComponents.Condenser.Serialization;

namespace BeeSharp.ApiComponents.ApiModels
{
    [JsonConverter(typeof(NumberOrStringJsonConverter))]
    public class NumberOrStringModel : ISerializableElement
    {
        public NumberOrStringModel(string value)
        {
            Value = value;
            OrigType = typeof(string);
        }

        public NumberOrStringModel(long value)
        {
            Value = value.ToString();
            OrigType = typeof(long);
        }

        public string Value { get; }

        public long NumericValue => Convert.ToInt64(Value);

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