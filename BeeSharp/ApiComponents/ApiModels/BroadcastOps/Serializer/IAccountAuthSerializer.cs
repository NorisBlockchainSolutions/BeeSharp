using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public interface IAccountAuthSerializer
    {
        byte[] SerializeOperation(AccountAuthModel authModel);
    }
}