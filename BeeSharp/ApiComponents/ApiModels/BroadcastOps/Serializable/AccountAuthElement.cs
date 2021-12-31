namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public readonly struct AccountAuthElement
    {
        public ushort Weight { get; }
        public string AccountName { get; }

        public AccountAuthElement(string accountName, ushort weight)
        {
            AccountName = accountName;
            Weight = weight;
        }
    }
}