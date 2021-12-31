using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_vesting_delegations
    {
        public class
            CondenserApiGetVestingDelegations : ICondenserApiCall<object, List<CondenserApiVestingDelegationModel>>
        {
            public CondenserApiGetVestingDelegations(string delegatorAccount, string? startAccount,
                [Range(-1, 1000)] short limit)
            {
                QueryParametersJson = new[] {delegatorAccount, startAccount!, (object) limit};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_vesting_delegations";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiVestingDelegationModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiVestingDelegationModel
        {
            public CondenserApiVestingDelegationModel(NumberOrStringModel id, string delegator, string delegatee,
                string vestingShares, DateTime minDelegationTime)
            {
                Id = id;
                Delegator = delegator;
                Delegatee = delegatee;
                VestingShares = vestingShares;
                MinDelegationTime = minDelegationTime;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("delegator")] public string Delegator { get; }

            [JsonPropertyName("delegatee")] public string Delegatee { get; }

            [JsonPropertyName("vesting_shares")] public string VestingShares { get; }

            [JsonPropertyName("min_delegation_time")]
            public DateTime MinDelegationTime { get; }
        }
    }
}