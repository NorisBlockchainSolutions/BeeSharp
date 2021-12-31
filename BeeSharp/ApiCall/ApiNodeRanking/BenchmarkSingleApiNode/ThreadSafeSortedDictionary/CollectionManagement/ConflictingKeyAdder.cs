using System;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement.
    CollectionVerification;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement
{
    public class ConflictingKeyAdder<T> : IConflictingKeyAdder<T> where T : notnull
    {
        private readonly IEntryAddableVerifier _entryAddableVerifier;

        public ConflictingKeyAdder(IEntryAddableVerifier entryAddableVerifier)
        {
            _entryAddableVerifier = entryAddableVerifier;
        }

        /// <summary>
        ///     Add an entry to the sorted list that is conflicting with an existing key.
        /// </summary>
        // has to be hard-coded to long, since C# does not provide an arithmetic type parameter constraint constraining
        // to all elements that implement +,-,*,/-operators
        public async Task AddEntryToList(ConflictingKey<long, T> entryToAdd)
        {
            var (sortedDictionaryToAddTo, duplicateEntryKeyIndex, valueToInsert) = entryToAdd;

            // Check if struct is null
            if (sortedDictionaryToAddTo == null)
                throw new ArgumentException("Cannot add empty entry to list!", nameof(entryToAdd));

            var collectionToModifyKeys = sortedDictionaryToAddTo.GetKeys();

            // Find an available index in the timedNodeUrls list that is closest and not taken
            while (true)
            {
                var indexToCheckForAvailability = duplicateEntryKeyIndex + 1;
                var previousListKey = collectionToModifyKeys[duplicateEntryKeyIndex];

                var check = new EntryAddable(indexToCheckForAvailability, previousListKey, collectionToModifyKeys);
                if (_entryAddableVerifier.IsEntryAddable(check))
                {
                    await sortedDictionaryToAddTo.AddAsync(previousListKey + 1, valueToInsert);
                    return;
                }

                // Increase duplicateEntryKeyListIndex by 1
                duplicateEntryKeyIndex = ++duplicateEntryKeyIndex;
            }
        }
    }
}