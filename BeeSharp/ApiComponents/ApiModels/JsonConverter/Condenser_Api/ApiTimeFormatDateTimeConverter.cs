using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.Condenser_Api
{
    public class ApiTimeFormatDateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString()!, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            // Round up milliseconds to get the expected seconds
            if (value.Millisecond >= 500) value = value.AddSeconds(1);

            var dateString = value.ToString("yyyy-MM-ddTHH:mm:ss");
            JsonSerializer.Serialize(writer, dateString, options);
        }
    }
}