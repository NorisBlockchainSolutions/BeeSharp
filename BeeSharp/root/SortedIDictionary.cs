using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.root
{
    public class SortedIDictionary<T, TU> : ISortedIDictionary<T, TU> where T : notnull
    {
        private readonly SortedList<T, TU> _sortedDictionary;
        private readonly IThreadSafeExecution _threadSafeExecutionContext;
        private readonly IThreadSafeExecutionFactory _threadSafeExecutionFactory;

        public SortedIDictionary(IThreadSafeExecutionFactory threadSafeExecutionFactory)
        {
            _threadSafeExecutionFactory = threadSafeExecutionFactory;
            _threadSafeExecutionContext = _threadSafeExecutionFactory.Create();
            _sortedDictionary = new SortedList<T, TU>();
        }

        public IList<T> GetKeys()
        {
            return _sortedDictionary.Keys;
        }

        public IEnumerable<KeyValuePair<T, TU>> GetElements()
        {
            return _sortedDictionary.AsEnumerable();
        }

        public KeyValuePair<T, TU> First()
        {
            return _sortedDictionary.First();
        }

        public int GetKeyIndexOfLastFittingKey(Func<KeyValuePair<T, TU>, bool> predicate)
        {
            return _sortedDictionary.Keys.IndexOf(
                _sortedDictionary
                    .Where(predicate)
                    .Last()
                    .Key
            );
        }

        /// <summary>
        /// Create a copy of this instance.
        /// Warning: This is only a shallow copy!
        /// The entries (T, TU) are still referenced!
        /// </summary>
        /// <returns>The copy of this instance.</returns>
        public async Task<ISortedIDictionary<T, TU>> CloneAsync()
        {
            var result = new SortedIDictionary<T, TU>(_threadSafeExecutionFactory);
            
            // Fill entries
            await _threadSafeExecutionContext.RunAsynchronousFunctionAwaitAsync(async () =>
            {
                foreach (var (key, value) in _sortedDictionary)
                {
                   await result.AddAsync(key, value); 
                }
            });

            return result;
        }

        /// <summary>
        /// Workaround to allow list initializer to work properly
        /// Use AddAsync, when possible!
        /// </summary>
        /// <param name="key">The key to add</param>
        /// <param name="value">The value to add</param>
        /// <exception cref="ArgumentException">Thrown when the key already exists.</exception>
        public void Add(T key, TU value)
        {
            var factory = new TaskFactory();
            factory.StartNew(() => AddAsync(key, value))
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        /// <summary>
        /// Add elements to the SortedIDictionary.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="value">The value to add</param>
        /// <exception cref="ArgumentException">Thrown when the key already exists.</exception>
        public async Task AddAsync(T key, TU value)
        {
            await _threadSafeExecutionContext.RunSynchronousActionAwaitAsync(() => _sortedDictionary.Add(key, value));
        }

        public async Task RemoveAsync(T key)
        {
            await _threadSafeExecutionContext.RunSynchronousActionAwaitAsync(() => _sortedDictionary.Remove(key));
        }

        public int Count => _sortedDictionary.Count;
        public TU this[T index] => _sortedDictionary[index];

        public IEnumerator<KeyValuePair<T, TU>> GetEnumerator()
        {
            return _sortedDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}