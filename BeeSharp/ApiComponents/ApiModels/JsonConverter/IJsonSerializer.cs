using System.IO;
using System.Threading.Tasks;

namespace BeeSharp.ApiComponents.ApiModels.JsonConverter
{
    public interface IJsonSerializer<T>
    {
        public Task<T> Deserialize(Stream response);
    }
}