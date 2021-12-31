using System;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary.CollectionManagement;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary
{
    public class CollisionFreeEntryAdder<T> : ICollisionFreeEntryAdder<T> where T : notnull
    {
        private readonly IConflictingKeyAdder<T> _conflictingKeyAdder;
        private readonly IThreadSafeExecution _threadEnv;

        public CollisionFreeEntryAdder(IConflictingKeyAdder<T> conflictingKeyAdderAdder,
            IThreadSafeExecutionFactory threadEnvFactory)
        {
            _conflictingKeyAdder = conflictingKeyAdderAdder;
            _threadEnv = threadEnvFactory.Create();
        }

        /// <summary>
        ///     Add a timed apiNodeUrl to the list.
        /// </summary>
        public async Task AddEntryThreadSafeAsync(EntryToAdd<long, T> request)
        {
            // Assert struct is not null
            if (request.SortedIDictionary == null)
                throw new ArgumentException("Cannot add empty entry!", nameof(request));

            await _threadEnv.RunAsynchronousFunctionAwaitAsync(async () =>
            {
                await AddEntryAsync(request.SortedIDictionary, request.Key, request.Value);
            });
        }

        private async Task AddEntryAsync(ISortedIDictionary<long, T> dictionaryToAddTo, long timing, T url)
        {
            var timedUrlsKeys = dictionaryToAddTo.GetKeys();
            var entryIndex = timedUrlsKeys.IndexOf(timing);

            // Check if index is taken
            if (entryIndex >= 0)
            {
                var addCommand = new ConflictingKey<long, T>(dictionaryToAddTo, entryIndex, url);
                await _conflictingKeyAdder.AddEntryToList(addCommand);
            }
            else
            {
                // Index is not taken, add timedNodeUrlString
                await dictionaryToAddTo.AddAsync(timing, url);
            }
        }
    }
}