using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary
{
    public interface ICollisionFreeEntryAdder<T> where T : notnull
    {
        /// <summary>
        ///     Add a timed apiNodeUrl to the list.
        /// </summary>
        Task AddEntryThreadSafeAsync(EntryToAdd<long, T> request);
    }
}