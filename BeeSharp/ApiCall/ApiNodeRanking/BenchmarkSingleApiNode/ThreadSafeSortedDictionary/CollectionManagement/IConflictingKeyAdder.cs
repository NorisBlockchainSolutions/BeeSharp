using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement
{
    public interface IConflictingKeyAdder<T> where T : notnull
    {
        /// <summary>
        ///     Add an entry to the sorted list that is conflicting with an existing key.
        /// </summary>
        Task AddEntryToList(ConflictingKey<long, T> entryToAdd);
    }
}