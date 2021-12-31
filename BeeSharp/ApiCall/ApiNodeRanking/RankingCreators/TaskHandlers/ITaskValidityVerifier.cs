using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.RankingCreators.TaskHandlers
{
    public interface ITaskValidityVerifier
    {
        void CheckTaskException(Task finishedTask);
    }
}