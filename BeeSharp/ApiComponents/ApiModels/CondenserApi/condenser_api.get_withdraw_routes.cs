using System.Collections.Generic;
using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.Condenser;

namespace BeeSharp.ApiComponents.ApiModels.CondenserApi
{
    namespace get_withdraw_routes
    {
        public class CondenserApiGetWithdrawRoutes : ICondenserApiCall<string, List<CondenserApiWithdrawRouteModel>>
        {
            public CondenserApiGetWithdrawRoutes(string account, string type)
            {
                QueryParametersJson = new[] {account, type};
                ExpectedResponseJson = null;
            }

            [JsonPropertyName("query_parameters_json")]
            public string[] QueryParametersJson { get; }

            [JsonPropertyName("methodName")] public string MethodName => "condenser_api.get_withdraw_routes";

            [JsonPropertyName("expected_response_json")]
            public List<CondenserApiWithdrawRouteModel>? ExpectedResponseJson { get; }
        }

        public class CondenserApiWithdrawRouteModel
        {
            public CondenserApiWithdrawRouteModel(NumberOrStringModel id, string fromAccount, string toAccount,
                NumberOrStringModel percent, bool autoVest)
            {
                Id = id;
                FromAccount = fromAccount;
                ToAccount = toAccount;
                Percent = percent;
                AutoVest = autoVest;
            }

            [JsonPropertyName("id")] public NumberOrStringModel Id { get; }

            [JsonPropertyName("from_account")] public string FromAccount { get; }

            [JsonPropertyName("to_account")] public string ToAccount { get; }

            [JsonPropertyName("percent")] public NumberOrStringModel Percent { get; }

            [JsonPropertyName("auto_vest")] public bool AutoVest { get; }
        }
    }
}