using BeeSharp.Auth.Provider;
using Org.BouncyCastle.Security;

namespace BeeSharp.root.Auth
{
    public class SecureRandomProvider : ISecureRandomProvider
    {
        private readonly SecureRandom _secureRandom;

        public SecureRandomProvider()
        {
            _secureRandom = new SecureRandom();
        }

        public SecureRandom Get()
        {
            return _secureRandom;
        }
    }
}