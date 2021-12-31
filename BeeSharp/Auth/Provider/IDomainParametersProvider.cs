using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.Auth.Provider
{
    public interface IDomainParametersProvider
    {
        ECDomainParameters Get();
    }
}