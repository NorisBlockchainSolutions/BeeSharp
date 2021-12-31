using BeeSharp.ApiComponents.ApiModels.BroadcastOps.account_create;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public interface IAccountCreateSerializer
    {
        byte[] SerializeOperation(BroadcastOpAccountCreateModel accountCreateModel);
    }
}