namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement.
    CollectionVerification
{
    public interface IEntryAddableVerifier
    {
        /// <summary>
        ///     Check whether a index fits into an existing collection (true) or not (false).
        /// </summary>
        /// <returns>Whether the index fits into the list (true) or not (false).</returns>
        bool IsEntryAddable(EntryAddable entry);
    }
}