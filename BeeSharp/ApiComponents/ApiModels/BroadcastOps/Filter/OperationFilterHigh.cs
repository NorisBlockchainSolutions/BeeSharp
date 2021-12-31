using System;

namespace BeeSharp.ApiComponents.ApiModels.BroadcastOps.Filter
{
    [Flags]
    public enum OperationFilterHigh : ulong
    {
        None = 0,
        ProposalPayOperation = (ulong) 1 << 1,
        SpsFundOperation = (ulong) 1 << 2,
        HardforkHiveOperation = (ulong) 1 << 3,
        HardforkHiveRestoreOperation = (ulong) 1 << 4,
        DelayedVotingOperation = (ulong) 1 << 11,
        ConsolidateTreasuryBalanceOperation = (ulong) 1 << 5,
        EffectiveCommentVoteOperation = (ulong) 1 << 6,
        IneffectiveDeleteCommentOperation = (ulong) 1 << 7,
        SpsConvertOperation = (ulong) 1 << 8
    }
}