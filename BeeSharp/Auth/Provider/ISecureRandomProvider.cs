using Org.BouncyCastle.Security;

namespace BeeSharp.Auth.Provider
{
    public interface ISecureRandomProvider
    {
        SecureRandom Get();
    }
}