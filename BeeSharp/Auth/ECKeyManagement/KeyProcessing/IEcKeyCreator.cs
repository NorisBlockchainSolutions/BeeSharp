using Org.BouncyCastle.Crypto;

namespace BeeSharp.Auth.ECKeyManagement.KeyProcessing
{
    public interface IEcKeyCreator
    {
        AsymmetricCipherKeyPair CreateKeyPair();
    }
}