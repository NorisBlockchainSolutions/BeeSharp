using System;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers
{
    public interface IThreadExceptionHandler
    {
        public void Handle(Exception? exception);
    }
}