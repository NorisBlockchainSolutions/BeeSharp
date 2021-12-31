using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public interface IAccountKeySerializer
    {
        byte[] SerializeOperation(AccountKeyModel accountKeyModel);
    }
}