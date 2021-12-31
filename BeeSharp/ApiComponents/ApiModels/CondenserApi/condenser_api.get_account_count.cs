using System;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_account_count
    {
        /// <summary>
        ///     Returns the number of accounts
        /// </summary>
        public class CondenserApiGetAccountCount : ICondenserApiCall<object, NumberOrStringModel>
        {
            public CondenserApiGetAccountCount()
            {
                QueryParametersJson = Array.Empty<object>();
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public object[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_account_count";

            [JsonPropertyName("expected_response_json")]
            public NumberOrStringModel? ExpectedResponseJson { get; }
        }
    }
}