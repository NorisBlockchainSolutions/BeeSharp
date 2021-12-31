using BeeSharp.ApiComponents.Condenser;
using BeeSharp.root.Exceptions;

namespace BeeSharp.Auth.Provider
{
    /// <summary>
    ///     This class acts as a cache of chainParameters.
    ///     Once initialized, the parameters can be fetched.
    ///     New registrations will override the old ones.
    /// </summary>
    public static class ChainParameterProvider
    {
        private static ChainParameterModel? _chainParameters;

        /// <summary>
        ///     Register new ChainParameters.
        /// </summary>
        /// <param name="accountCreationFee">The account creation fee. Usually "f.fff UNITS"</param>
        /// <param name="context">The blockchain parameters.</param>
        /// <returns>The chainParameters model.</returns>
        public static ChainParameterModel RegisterNew(string accountCreationFee,
            BlockChainParametersContext context)
        {
            _chainParameters =
                new ChainParameterModel(accountCreationFee, context.WifPrefix, context.ChainPrefix);

            return _chainParameters;
        }

        /// <summary>
        ///     Register new ChainParameters, if not already registered.
        /// </summary>
        /// <param name="accountCreationFee">The account creation fee. Usually "f.fff UNITS"</param>
        /// <param name="context">The blockchain parameters.</param>
        /// <returns>The chainParameters model.</returns>
        public static ChainParameterModel RegisterNewIfUnknown(string accountCreationFee,
            BlockChainParametersContext context)
        {
            return _chainParameters ?? RegisterNew(accountCreationFee, context);
        }

        /// <summary>
        ///     Can be used after the builder has been called once. ONLY USEFUL FOR CONDENSER-CALLS!
        /// </summary>
        /// <returns>The current ChainParameterModel.</returns>
        /// <exception cref="ClassInstantiationException">
        ///     Thrown when ChainParameterModel has not yet been set.
        /// </exception>
        public static ChainParameterModel Get()
        {
            if (_chainParameters is null)
                throw new ClassInstantiationException("ChainParameterModel has not been initialized yet!");
            return _chainParameters;
        }
    }
}