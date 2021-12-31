using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers
{
    public class TaskValidityVerifier : ITaskValidityVerifier
    {
        private readonly IThreadExceptionHandler _threadExceptionHandler;

        public TaskValidityVerifier(IThreadExceptionHandler threadExceptionHandler)
        {
            _threadExceptionHandler = threadExceptionHandler;
        }

        public void CheckTaskException(Task finishedTask)
        {
            // Check, if an exception occured
            if (!finishedTask.IsFaulted || finishedTask.Exception == null) return;

            // Handle exception
            var error = finishedTask.Exception.InnerException;
            if (error != null)
                _threadExceptionHandler.Handle(error);
            else
                throw finishedTask.Exception;
        }
    }
}