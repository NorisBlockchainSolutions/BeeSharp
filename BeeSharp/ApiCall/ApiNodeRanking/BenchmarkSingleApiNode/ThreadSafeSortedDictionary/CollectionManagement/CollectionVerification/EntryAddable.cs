using System;
using System.Collections.Generic;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement.
    CollectionVerification
{
#nullable enable
    public readonly struct EntryAddable
    {
        public int IndexToCheck { get; }

        // The key of the previous item
        public long PreviousKey { get; }
        public IList<long> KeysOfCollectionToAddTo { get; }

        /// <summary>
        ///     Create a new entry addable data struct.
        /// </summary>
        /// <param name="indexToCheck">The index to check at.</param>
        /// <param name="previousKey">The value of the previous key.</param>
        /// <param name="keysOfOrderedDictionaryToAddTo">The keys of the ordered dictionary to add to.</param>
        /// <exception cref="ArgumentException">Thrown when a negative index or key is supplied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the keyList is null.</exception>
        public EntryAddable(int indexToCheck, long previousKey, IList<long> keysOfOrderedDictionaryToAddTo)
        {
            if (indexToCheck < 0) throw new ArgumentException("Cannot index list by index < 0!", nameof(indexToCheck));

            if (previousKey < 0) throw new ArgumentException("Cannot contain negative key!", nameof(previousKey));

            IndexToCheck = indexToCheck;
            PreviousKey = previousKey;
            KeysOfCollectionToAddTo =
                keysOfOrderedDictionaryToAddTo ??
                throw new ArgumentNullException(nameof(keysOfOrderedDictionaryToAddTo));
        }

        public void Deconstruct(out int indexToCheck, out long previousKey,
            out IList<long> keysOfCollectionToAddTo)
        {
            indexToCheck = IndexToCheck;
            previousKey = PreviousKey;
            keysOfCollectionToAddTo = KeysOfCollectionToAddTo;
        }
    }
}