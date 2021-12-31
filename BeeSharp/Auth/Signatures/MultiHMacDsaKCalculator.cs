using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Signers;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;

namespace BeeSharp.Auth.Signatures
{
    public class MultiHMacDsaKCalculator : IDsaKCalculator
    {
        private readonly HMacDsaKCalculator _kCalculator;

        /// <summary>
        ///     This class is a wrapper for HMacDsaKCalculator.
        ///     It stubs the init call, so that it will not be overwritten by the signature creator.
        ///     Init2 has to be used instead.
        /// </summary>
        /// <param name="digest">The digest to use.</param>
        public MultiHMacDsaKCalculator(IDigest digest)
        {
            _kCalculator = new HMacDsaKCalculator(digest);
        }

        public bool IsDeterministic => _kCalculator.IsDeterministic;

        public void Init(BigInteger n, SecureRandom random)
        {
            _kCalculator.Init(n, random);
        }

        /// <summary>
        ///     Stubbed init function. THIS FUNCTION DOES NOTHING, DO NOT USE!
        /// </summary>
        public void Init(BigInteger n, BigInteger d, byte[] message)
        {
            // Do nothing
        }

        public BigInteger NextK()
        {
            return _kCalculator.NextK()!;
        }

        /// <summary>
        ///     Actual init function. USE THIS ONE INSTEAD OF INIT!
        /// </summary>
        public void Init2(BigInteger n, BigInteger d, byte[] message)
        {
            _kCalculator.Init(n, d, message);
        }
    }
}