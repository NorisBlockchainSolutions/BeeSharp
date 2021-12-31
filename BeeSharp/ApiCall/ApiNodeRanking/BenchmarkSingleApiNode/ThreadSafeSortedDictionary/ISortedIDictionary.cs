using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary
{
    public interface ISortedIDictionary<T, TU> : IEnumerable<KeyValuePair<T, TU>>
    {
        public int Count { get; }
        public TU this[T index] { get; }
        public IList<T> GetKeys();
        public IEnumerable<KeyValuePair<T, TU>> GetElements();
        public KeyValuePair<T, TU> First();
        public Task AddAsync(T key, TU value);
        public Task RemoveAsync(T key);
        public int GetKeyIndexOfLastFittingKey(Func<KeyValuePair<T, TU>, bool> predicate);

        public Task<ISortedIDictionary<T, TU>> CloneAsync();
    }
}