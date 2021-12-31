using BeeSharp.Auth.Provider;
using BeeSharp.root.Exceptions;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Parameters;

namespace BeeSharp.root.Auth
{
    public class DomainParametersProvider : IDomainParametersProvider
    {
        private readonly ECDomainParameters _domainParameters;

        public DomainParametersProvider()
        {
            var curve = ECNamedCurveTable.GetByName("secp256k1");
            if (curve is null)
                throw new ClassInstantiationException(
                    "Cannot create domain parameters without secp256k1 support!");
            _domainParameters = new ECDomainParameters(curve.Curve!, curve.G!, curve.N!, curve.H!, curve.GetSeed()!);
        }

        public ECDomainParameters Get()
        {
            return _domainParameters;
        }
    }
}