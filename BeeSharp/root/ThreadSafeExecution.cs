using System;
using System.Threading;
using System.Threading.Tasks;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.root
{
    public class ThreadSafeExecution : IThreadSafeExecution
    {
        private readonly SemaphoreSlim _lock;

        public ThreadSafeExecution()
        {
            _lock = new SemaphoreSlim(1);
        }

        /// <summary>
        /// This method is used to run asynchronous actions (async () => ...).
        /// For async tasks, use RunSynchronousActionAwaitAsync respectively.
        /// </summary>
        /// <param name="action">The action to run.</param>
        public async Task RunAsynchronousFunctionAwaitAsync(Func<Task> action)
        {
            // lock execution
            await _lock.WaitAsync();
            try
            {
                var task = action();
                await task;
                if (task.IsFaulted)
                {
                    if (task.Exception != null && task.Exception.InnerException != null)
                    {
                        throw task.Exception.InnerException;
                    }
                    throw new TaskCanceledException("Faulted task returned! ");
                }
            }
            finally
            {
                _lock.Release();
            }
        }
        
        /// <summary>
        /// This method is used to run synchronous actions (() => ...).
        /// For async tasks, use RunSynchronousActionAwaitAsync respectively.
        /// </summary>
        /// <param name="action">The action to run.</param>
        public async Task RunSynchronousActionAwaitAsync(Action action)
        {
            // lock execution
            await _lock.WaitAsync();
            try
            {
                var task = Task.Run(action);
                await task;
                if (task.IsFaulted)
                {
                    if (task.Exception != null && task.Exception.InnerException != null)
                    {
                        throw task.Exception.InnerException;
                    }
                    throw new TaskCanceledException("Faulted task returned! ");
                }
            }
            finally
            {
                _lock.Release();
            }
        }
    }
}