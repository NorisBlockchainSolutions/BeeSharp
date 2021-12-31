namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary
{
    public interface IThreadSafeExecutionFactory
    {
        public IThreadSafeExecution Create();
    }
}