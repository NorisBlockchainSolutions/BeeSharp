using System.Text.Json.Serialization;
using BeeSharp.ApiComponents.ApiModels.JsonConverter.Annotations;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps
{
    namespace set_withdraw_vesting_route
    {
        [BroadcastOp("set_withdraw_vesting_route")]
        public class BroadcastOpSetWithdrawVestingRouteModel : BroadcastOperation
        {
            /// <summary>
            ///     Set a vesting withdraw with funds being transferred directly to another account's balance.
            ///     Those funds can immediately be vested again using autoVest.
            /// </summary>
            /// <param name="fromAccount">Sending account.</param>
            /// <param name="toAccount">Receiving account.</param>
            /// <param name="percent">Percent of account VESTS to power down.</param>
            /// <param name="autoVest">
            ///     Whether the VESTS should immediately be vested again in the target account (true)
            ///     or not (false).
            /// </param>
            public BroadcastOpSetWithdrawVestingRouteModel(string fromAccount, string toAccount,
                NumberOrStringModel percent, bool autoVest)
            {
                FromAccount = fromAccount;
                ToAccount = toAccount;
                Percent = percent;
                AutoVest = autoVest;
            }

            [JsonPropertyName("from_account")] public string FromAccount { get; }

            [JsonPropertyName("to_account")] public string ToAccount { get; }

            [JsonPropertyName("percent")] public NumberOrStringModel Percent { get; }

            [JsonPropertyName("auto_vest")] public bool AutoVest { get; }
        }
    }
}