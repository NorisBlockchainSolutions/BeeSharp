using System;
using BeeSharp.ApiComponents.ApiModels.BroadcastOps.AccountKey;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Serializable
{
    public class AccountKeyElement
    {
        private AccountAuthModel[] _accountAuths;
        private AccountKeyAuthModel[] _accountKeyAuths;

        public AccountKeyElement(AccountAuthElement[]? accountAuths, KeyAuthElement[]? keyAuths,
            uint weightThreshold = 1)
        {
            WeightThreshold = weightThreshold;

            _accountAuths = Array.Empty<AccountAuthModel>();
            _accountKeyAuths = Array.Empty<AccountKeyAuthModel>();

            AccountAuths = accountAuths ?? Array.Empty<AccountAuthElement>();
            KeyAuths = keyAuths ?? Array.Empty<KeyAuthElement>();
        }

        public uint WeightThreshold { get; }
        public AccountAuthElement[]? AccountAuths { get; }
        public KeyAuthElement[]? KeyAuths { get; }

        public AccountAuthModel[] GetAccountAuthsAsModels()
        {
            if (_accountAuths.Length == 0)
            {
                _accountAuths = new AccountAuthModel[AccountAuths!.Length];
                for (var i = 0; i < AccountAuths.Length; i++)
                    _accountAuths[i] = new AccountAuthModel(AccountAuths[i].AccountName,
                        new NumberOrStringModel(AccountAuths[i].Weight));
            }

            return _accountAuths;
        }

        public AccountKeyAuthModel[] GetAccountKeyAuthsAsModels()
        {
            if (_accountKeyAuths.Length == 0)
            {
                _accountKeyAuths = new AccountKeyAuthModel[KeyAuths!.Length];
                for (var i = 0; i < KeyAuths.Length; i++)
                    _accountKeyAuths[i] = new AccountKeyAuthModel(KeyAuths[i].PublicKey.GetBase58Encoded(),
                        new NumberOrStringModel(KeyAuths[i].Weight));
            }

            return _accountKeyAuths;
        }
    }
}