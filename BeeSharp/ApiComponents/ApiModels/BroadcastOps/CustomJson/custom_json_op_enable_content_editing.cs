using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson
{
    namespace enable_content_editing
    {
        [CustomJsonOpId("witness", typeof(ArrayShapedCustomJsonModel))]
        [CustomJsonOpListOp("enable_content_editing")]
        public class CustomJsonOpEnableContentEditingModel : CustomJsonOperation
        {
            public CustomJsonOpEnableContentEditingModel(string account, DateTime relockTime)
            {
                Account = account;
                RelockTime = relockTime;
            }

            [JsonPropertyName("account")] public string Account { get; }

            [JsonPropertyName("relock_time")] public DateTime RelockTime { get; }
        }
    }
}