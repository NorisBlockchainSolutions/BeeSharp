namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary
{
    public interface ISortedIDictionaryFactory<T, TU> where T : notnull
    {
        ISortedIDictionary<T, TU> Create();
    }
}