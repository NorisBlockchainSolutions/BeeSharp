using BeeSharp.Auth.ECKeyManagement.KeyProcessing;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public readonly struct KeyAuthElement
    {
        public ushort Weight { get; }
        public EcdsaPublicKey PublicKey { get; }

        public KeyAuthElement(EcdsaPublicKey publicKey, ushort weight)
        {
            PublicKey = publicKey;
            Weight = weight;
        }
    }
}