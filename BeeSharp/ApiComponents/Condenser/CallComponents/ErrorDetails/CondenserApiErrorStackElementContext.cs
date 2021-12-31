using System;
using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.Condenser.CallComponents.ErrorDetails
{
    public class CondenserApiErrorStackElementContext
    {
        public CondenserApiErrorStackElementContext(string level, string file, int line, string method, string hostname,
            DateTime timestamp)
        {
            Level = level;
            File = file;
            Line = line;
            Method = method;
            Hostname = hostname;
            Timestamp = timestamp;
        }

        [JsonPropertyName("level")] public string Level { get; }
        [JsonPropertyName("file")] public string File { get; }
        [JsonPropertyName("line")] public int Line { get; }
        [JsonPropertyName("method")] public string Method { get; }
        [JsonPropertyName("hostname")] public string Hostname { get; }
        [JsonPropertyName("timestamp")] public DateTime Timestamp { get; }
    }
}