#nullable enable
using System.Text.Json;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.CustomJson;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.DirectorComponents;
using BeeSharp.root.DebugInfoProvider;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter.BroadcastOp.CustomJson
{
    public static class CustomJsonJsonConverter
    {
        public static CustomJsonOperation? DeserializeCustomJson(string id, string customJson)
        {
            var director = (CustomJsonOpIdDirector)DirectorRegistry.GetDirector(typeof(CustomJsonOpIdDirector));
            var resultType = director.GetStructure(id);
            if (resultType is null) return null;

            try
            {
                var result = (CustomJsonOperation)JsonSerializer.Deserialize(customJson, resultType)!;
                
                // throw event
                director.OnCustomJsonOperationSerialized(result);
                
                return result;
            }
            catch (JsonException e)
            {
                DirectorInfoProvider.OnUnregisteredTypeRequested(typeof(CustomJsonJsonConverter),
                    new UnregisteredTypeEventArgs(nameof(CustomJsonJsonConverter),
                        e.ToString()));
                return null;
            }
        }
    }
}