using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_potential_signatures
    {
        public class CondenserApiGetPotentialSignatures : ICondenserApiCall<
            CondenserApiGetPotentialSignaturesQueryParametersJson, List<string>>
        {
            public CondenserApiGetPotentialSignatures(long refBlockNum, long refBlockPrefix,
                DateTime expiration,
                BroadcastOpModel[] operations)
            {
                QueryParametersJson = new[]
                {
                    new CondenserApiGetPotentialSignaturesQueryParametersJson(refBlockNum, refBlockPrefix, expiration,
                        operations)
                };
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public CondenserApiGetPotentialSignaturesQueryParametersJson[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_potential_signatures";

            [JsonPropertyName("expected_response_json")]
            public List<string>? ExpectedResponseJson { get; }
        }

        public class CondenserApiGetPotentialSignaturesQueryParametersJson
        {
            public CondenserApiGetPotentialSignaturesQueryParametersJson(long refBlockNum, long refBlockPrefix,
                DateTime expiration,
                BroadcastOpModel[] operations)
            {
                RefBlockNum = refBlockNum;
                RefBlockPrefix = refBlockPrefix;
                Expiration = expiration;
                Operations = operations;
                Extensions = Array.Empty<object>();
                Signatures = Array.Empty<object>();
            }

            [JsonPropertyName("ref_block_num")] public long RefBlockNum { get; }

            [JsonPropertyName("ref_block_prefix")] public long RefBlockPrefix { get; }

            [JsonPropertyName("expiration")] public DateTime Expiration { get; }

            [JsonPropertyName("operations")] public BroadcastOpModel[] Operations { get; }

            [JsonPropertyName("extensions")] public object[] Extensions { get; }

            [JsonPropertyName("signatures")] public object[] Signatures { get; }
        }
    }
}