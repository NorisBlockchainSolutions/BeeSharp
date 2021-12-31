using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers
{
    public interface IAnySuccessfulTaskHandler
    {
        public Task<bool> AnySuccessfulTaskCompletedAsync(IList<Task> tasks);
    }
}