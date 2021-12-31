﻿using System;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Filter
{
    [Flags]
    public enum OperationFilterLow : ulong
    {
        None = 0,
        VoteOperation = (ulong) 1 << 0,
        CommentOperation = (ulong) 1 << 1,
        TransferOperation = (ulong) 1 << 2,
        TransferToVestingOperation = (ulong) 1 << 3,
        WithdrawVestingOperation = (ulong) 1 << 4,
        LimitOrderCreateOperation = (ulong) 1 << 5,
        LimitOrderCancelOperation = (ulong) 1 << 6,
        FeedPublishOperation = (ulong) 1 << 7,
        ConvertOperation = (ulong) 1 << 8,
        AccountCreateOperation = (ulong) 1 << 9,
        AccountUpdateOperation = (ulong) 1 << 10,
        WitnessUpdateOperation = (ulong) 1 << 11,
        AccountWitnessVoteOperation = (ulong) 1 << 12,
        AccountWitnessProxyOperation = (ulong) 1 << 13,
        PowOperation = (ulong) 1 << 14,
        CustomOperation = (ulong) 1 << 15,
        ReportOverProductionOperation = (ulong) 1 << 16,
        DeleteCommentOperation = (ulong) 1 << 17,
        CustomJsonOperation = (ulong) 1 << 18,
        CommentOptionsOperation = (ulong) 1 << 19,
        SetWithdrawVestingRouteOperation = (ulong) 1 << 20,
        LimitOrderCreate2Operation = (ulong) 1 << 21,
        ClaimAccountOperation = (ulong) 1 << 22,
        CreateClaimedAccountOperation = (ulong) 1 << 23,
        RequestAccountRecoveryOperation = (ulong) 1 << 24,
        RecoverAccountOperation = (ulong) 1 << 25,
        ChangeRecoveryAccountOperation = (ulong) 1 << 26,
        EscrowTransferOperation = (ulong) 1 << 27,
        EscrowDisputeOperation = (ulong) 1 << 28,
        EscrowReleaseOperation = (ulong) 1 << 29,
        Pow2Operation = (ulong) 1 << 30,
        EscrowApproveOperation = (ulong) 1 << 31,
        TransferToSavingsOperation = (ulong) 1 << 32,
        TransferFromSavingsOperation = (ulong) 1 << 33,
        CancelTransferFromSavingsOperation = (ulong) 1 << 34,
        CustomBinaryOperation = (ulong) 1 << 35,
        DeclineVotingRightsOperation = (ulong) 1 << 36,
        ResetAccountOperation = (ulong) 1 << 37,
        SetResetAccountOperation = (ulong) 1 << 38,
        ClaimRewardBalanceOperation = (ulong) 1 << 39,
        DelegateVestingSharesOperation = (ulong) 1 << 40,
        AccountCreateWithDelegationOperation = (ulong) 1 << 41,
        WitnessSetPropertiesOperation = (ulong) 1 << 42,
        AccountUpdate2Operation = (ulong) 1 << 43,
        CreateProposalOperation = (ulong) 1 << 44,
        UpdateProposalVotesOperation = (ulong) 1 << 45,
        RemoveProposalOperation = (ulong) 1 << 46,
        UpdateProposalOperation = (ulong) 1 << 47,

        // SMT operations
        // ClaimRewardBalance2Operation = (ulong) 1 << 48,
        // SmtSetupOperation = (ulong) 1 << 49,
        // SmtSetupEmissionsOperation = (ulong) 1 << 50,
        // SmtSetSetupParametersOperation = (ulong) 1 << 51,
        // SmtSetRuntimeParametersOperation = (ulong) 1 << 52,
        // SmtCreateOperation = (ulong) 1 << 53,
        // SmtContributeOperation = (ulong) 1 << 54,
        // Virtual operations
        FillConvertRequestOperation = (ulong) 1 << 48,
        AuthorRewardOperation = (ulong) 1 << 49,
        CurationRewardOperation = (ulong) 1 << 50,
        CommentRewardOperation = (ulong) 1 << 51,
        LiquidityRewardOperation = (ulong) 1 << 52,
        InterestOperation = (ulong) 1 << 53,
        FillVestingWithdrawOperation = (ulong) 1 << 54,
        FillOrderOperation = (ulong) 1 << 55,
        ShutdownWitnessOperation = (ulong) 1 << 56,
        FillTransferFromSavingsOperation = (ulong) 1 << 57,
        HardforkOperation = (ulong) 1 << 58,
        CommentPayoutUpdateOperation = (ulong) 1 << 59,
        ReturnVestingDelegationOperation = (ulong) 1 << 60,
        CommentBenefactorRewardOperation = (ulong) 1 << 61,
        ProducerRewardOperation = (ulong) 1 << 62,
        ClearNullAccountBalanceOperation = (ulong) 1 << 63
    }
}