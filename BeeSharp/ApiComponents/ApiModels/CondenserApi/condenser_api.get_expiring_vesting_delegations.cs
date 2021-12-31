using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_expiring_vesting_delegations
    {
        public class
            CondenserApiGetExpiringVestingDelegations : ICondenserApiCall<object,
                List<CondenserApiExpiringVestingDelegationModel>>
        {
            public CondenserApiGetExpiringVestingDelegations(string account, DateTime after)
            {
                QueryParametersJson = new[] {account, (object) after};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")]
            public string MethodName => "condenser_api.get_expiring_vesting_delegations";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiExpiringVestingDelegationModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiExpiringVestingDelegationModel
        {
            public CondenserApiExpiringVestingDelegationModel(NumberOrStringModel id, string delegator,
                string vestingShares,
                DateTime expiration)
            {
                Id = id;
                Delegator = delegator;
                VestingShares = vestingShares;
                Expiration = expiration;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("delegator")] public string Delegator { get; }

            [JsonPropertyName("vesting_shares")] public string VestingShares { get; }

            [JsonPropertyName("expiration")] public DateTime Expiration { get; }
        }
    }
}