using System;
using System.Diagnostics.CodeAnalysis;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary
{
    public readonly struct EntryToAdd<T, TU> where T : notnull where TU : notnull
    {
        public ISortedIDictionary<T, TU> SortedIDictionary { get; }
        public T Key { get; }
        public TU Value { get; }

        /// <param name="sortedIDictionary">The existing dictionary that shall be added upon.</param>
        /// <param name="key">The key that should be added.</param>
        /// <param name="value">The value to add.</param>
        public EntryToAdd(ISortedIDictionary<T, TU> sortedIDictionary, T key, TU value)
        {
            SortedIDictionary = sortedIDictionary ?? throw new ArgumentNullException(nameof(sortedIDictionary));

            // key and value can be null! nullable does only prevent type parameters to be null, but not a nullable
            // value set to null, e.g. a string set to null!
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public void Deconstruct(out ISortedIDictionary<T, TU> timedUrls, out T key, out TU value)
        {
            timedUrls = SortedIDictionary;
            key = Key;
            value = Value;
        }
    }
}