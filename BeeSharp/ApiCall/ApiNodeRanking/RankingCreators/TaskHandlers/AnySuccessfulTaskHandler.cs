using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers
{
    public class AnySuccessfulTaskHandler : IAnySuccessfulTaskHandler
    {
        private readonly ITaskValidityVerifier _taskValidityVerifier;

        public AnySuccessfulTaskHandler(ITaskValidityVerifier taskValidityVerifier)
        {
            _taskValidityVerifier = taskValidityVerifier;
        }

        public async Task<bool> AnySuccessfulTaskCompletedAsync(IList<Task> tasks)
        {
            Task finishedTask;
            // Wait until first task completes, return when it was successful
            do
            {
                finishedTask = await Task.WhenAny(tasks);
                tasks.Remove(finishedTask);

                _taskValidityVerifier.CheckTaskException(finishedTask);
            } while ((finishedTask.IsFaulted || finishedTask.IsCanceled) && tasks.Count > 0);

            return finishedTask.IsCompletedSuccessfully;
        }
    }
}