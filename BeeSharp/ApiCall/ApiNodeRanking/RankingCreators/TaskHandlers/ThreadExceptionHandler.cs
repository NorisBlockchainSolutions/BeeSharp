using System;
using System.Net.Http;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers
{
    public class ThreadExceptionHandler : IThreadExceptionHandler
    {
        public void Handle(Exception? exception)
        {
            if (exception == null) return;
            switch (exception)
            {
                case HttpRequestException:
                    // invalid request
                    break;
                case TimeoutException:
                    // request timeout
                    break;
                default:
                    // Unrecognized exception
                    throw exception;
            }
        }
    }
}