using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.VirtualOps
{
    namespace fill_order
    {
        [VirtualBroadcastOp("fill_order")]
        public class BroadcastVirtualOpFillOrderModel : VirtualBroadcastOperation
        {
            public BroadcastVirtualOpFillOrderModel(string currentOwner, NumberOrStringModel currentOrderId,
                string currentPays, string openOwner, NumberOrStringModel openOrderId, string openPays)
            {
                CurrentOwner = currentOwner;
                CurrentOrderid = currentOrderId;
                CurrentPays = currentPays;
                OpenOwner = openOwner;
                OpenOrderId = openOrderId;
                OpenPays = openPays;
            }

            [JsonPropertyName("current_owner")] public string CurrentOwner { get; }

            [JsonPropertyName("current_orderid")] public NumberOrStringModel CurrentOrderid { get; }

            [JsonPropertyName("current_pays")] public string CurrentPays { get; }

            [JsonPropertyName("open_owner")] public string OpenOwner { get; }

            [JsonPropertyName("open_orderid")] public NumberOrStringModel OpenOrderId { get; }

            [JsonPropertyName("open_pays")] public string OpenPays { get; }
        }
    }
}