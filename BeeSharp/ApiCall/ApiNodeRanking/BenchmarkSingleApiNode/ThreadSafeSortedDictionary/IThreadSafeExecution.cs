using System;
using System.Threading.Tasks;

namespace BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary
{
    public interface IThreadSafeExecution
    {
        /// <summary>
        /// This method is used to run asynchronous actions (async () => ...).
        /// For async tasks, use RunSynchronousActionAwaitAsync respectively.
        /// </summary>
        /// <param name="action">The action to run.</param>
        public Task RunAsynchronousFunctionAwaitAsync(Func<Task> action);
        
        /// <summary>
        /// This method is used to run synchronous actions (() => ...).
        /// For async tasks, use RunSynchronousActionAwaitAsync respectively.
        /// </summary>
        /// <param name="action">The action to run.</param>
        Task RunSynchronousActionAwaitAsync(Action action);
    }
}