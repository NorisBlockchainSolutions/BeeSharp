using System;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;

namespace BeeSharp.Auth.Provider
{
    public class ChainParameterModel
    {
        /// <summary>
        ///     Create a new ChainParameterModel.
        /// </summary>
        /// <param name="accountCreationFee">The account creation fee. Usually "f.fff UNITS"</param>
        /// <param name="wifPrefix">The prefix of private keys.</param>
        /// <param name="chainPrefix">The prefix of public keys.</param>
        /// <exception cref="ArgumentException">Thrown when accountCreationFee is invalid.</exception>
        public ChainParameterModel(string accountCreationFee, string wifPrefix, string chainPrefix)
        {
            var creationFeeElems = accountCreationFee.Split(' ');
            if (creationFeeElems.Length != 2)
                throw new ArgumentException("Invalid string format!",
                    nameof(accountCreationFee));

            AccountCreationFee = new FeeModelOrStringModel(accountCreationFee);
            // 0.000 has three digits after the period and therefore a precision of three.
            FeePrecision = creationFeeElems[0].Split('.')[1].Length;
            CurrencyUnitName = creationFeeElems[1];

            WifPrefix = wifPrefix;
            ChainPrefix = chainPrefix;
        }

        // Precision of fee elements
        public int FeePrecision { get; }

        // Name of the default cryptocurreny, eg. STEEM, HIVE, TESTS etc.
        public string CurrencyUnitName { get; }

        // Fee required for account creation
        public FeeModelOrStringModel AccountCreationFee { get; }

        // Prefix for private keys
        public string WifPrefix { get; }

        // Prefix for public keys
        public string ChainPrefix { get; }
    }
}