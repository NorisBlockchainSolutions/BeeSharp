using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.root
{
    public class SortedIDictionaryFactory<T, TU> : ISortedIDictionaryFactory<T, TU> where T : notnull
    {
        private readonly IThreadSafeExecutionFactory _threadSafeExecutionFactory;

        public SortedIDictionaryFactory(IThreadSafeExecutionFactory threadSafeExecutionFactory)
        {
            _threadSafeExecutionFactory = threadSafeExecutionFactory;
        }

        public ISortedIDictionary<T, TU> Create()
        {
            return new SortedIDictionary<T, TU>(_threadSafeExecutionFactory);
        }
    }
}