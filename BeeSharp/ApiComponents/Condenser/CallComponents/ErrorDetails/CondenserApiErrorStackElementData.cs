using System.Text.Json.Serialization;

namespace BeeSharp.ApiComponents.Condenser.CallComponents.ErrorDetails
{
    public struct CondenserApiErrorStackElementData
    {
        [JsonPropertyName("item->num")] public int ItemNum { get; set; }
        [JsonPropertyName("head")] public long Head { get; set; }
        [JsonPropertyName("max_size")] public int MaxSize { get; set; }
        [JsonPropertyName("new_block")] public CondenserApiErrorStackElementDataBlock NewBlock { get; set; }
    }
}