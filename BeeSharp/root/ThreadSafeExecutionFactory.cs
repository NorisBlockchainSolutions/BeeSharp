using System;
using System.Linq;
using BeeSharp.ApiCall.ApiNodeRanking.BenchmarkSingleApiNode.ThreadSafeSortedDictionary;

namespace BeeSharp.root
{
    public class ThreadSafeExecutionFactory : IThreadSafeExecutionFactory
    {
        private readonly Type _iThreadSaveExecutionType;

        public ThreadSafeExecutionFactory(Type iThreadSaveExecutionType)
        {
            if (!iThreadSaveExecutionType.GetInterfaces().Contains(typeof(IThreadSafeExecution)) ||
                !iThreadSaveExecutionType.IsClass || iThreadSaveExecutionType.IsAbstract)
                throw new ArgumentException($"Invalid type, must implement {nameof(IThreadSafeExecution)}!");
            _iThreadSaveExecutionType = iThreadSaveExecutionType;
        }

        public IThreadSafeExecution Create()
        {
            return (IThreadSafeExecution)Activator.CreateInstance(_iThreadSaveExecutionType)!;
        }
    }
}