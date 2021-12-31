using System;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement
{
    public readonly struct ConflictingKey<T, TU> where T : notnull where TU : notnull
    {
        public ISortedIDictionary<T, TU> DictionaryToAddTo { get; }
        public int DuplicateEntryKeyIndex { get; }
        public TU ValueToInsert { get; }

        /// <param name="iDictionaryToAddTo">The collection the element should be added to.</param>
        /// <param name="duplicateEntryKeyIndex">The keyCollection index that refers to the duplicate entry.</param>
        /// <param name="valueToInsert">The value to insert into the sortedIDictionary.</param>
        public ConflictingKey(ISortedIDictionary<T, TU> iDictionaryToAddTo,
            int duplicateEntryKeyIndex, TU valueToInsert)
        {
            DictionaryToAddTo = iDictionaryToAddTo ?? throw new ArgumentNullException(nameof(iDictionaryToAddTo));

            if (duplicateEntryKeyIndex < 0)
                throw new ArgumentException("Cannot index with index < 0!", nameof(duplicateEntryKeyIndex));

            DuplicateEntryKeyIndex = duplicateEntryKeyIndex;

            ValueToInsert = valueToInsert ?? throw new ArgumentNullException(nameof(valueToInsert));
        }

        public void Deconstruct(out ISortedIDictionary<T, TU> iDictionaryToAddTo, out int duplicateEntryKeyIndex,
            out TU valueToInsert)
        {
            iDictionaryToAddTo = DictionaryToAddTo;
            duplicateEntryKeyIndex = DuplicateEntryKeyIndex;
            valueToInsert = ValueToInsert;
        }
    }
}