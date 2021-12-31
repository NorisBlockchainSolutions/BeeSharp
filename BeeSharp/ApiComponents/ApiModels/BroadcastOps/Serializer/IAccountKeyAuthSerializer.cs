using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializer
{
    public interface IAccountKeyAuthSerializer
    {
        byte[] SerializeOperation(AccountKeyAuthModel authModel);
    }
}