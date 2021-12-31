using System;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement.
    CollectionVerification
{
    public class EntryAddableVerifier : IEntryAddableVerifier
    {
        /// <summary>
        ///     Check whether a index fits into an existing collection (true) or not (false).
        /// </summary>
        /// <returns>Whether the index fits into the list (true) or not (false).</returns>
        /// <exception cref="ArgumentException">Thrown when the given collection is not ordered.</exception>
        public bool IsEntryAddable(EntryAddable entry)
        {
            var (indexToCheck, previousKey, keysOfCollectionToAddTo) = entry;

            // Check if struct is null
            if (keysOfCollectionToAddTo == null)
                throw new ArgumentException("Cannot add empty entry to list!", nameof(keysOfCollectionToAddTo));

            // Check if index is within the list (bounds)
            if (keysOfCollectionToAddTo.Count <= indexToCheck) return true;

            // Check if there is space between the two values
            var currentListKey = keysOfCollectionToAddTo[indexToCheck];
            return IsSpaceBetweenValues(currentListKey, previousKey);
        }

        private static bool IsSpaceBetweenValues(long currentListKey, long previousListKey)
        {
            var difference = currentListKey - previousListKey;
            if (difference < 0) throw new ArgumentException("Given collection is not ordered!");

            return difference > 1;
        }
    }
}