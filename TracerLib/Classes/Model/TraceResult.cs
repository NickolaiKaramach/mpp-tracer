using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace tracer.Classes.Model
{
    public class TraceResult
    {
        private readonly ConcurrentDictionary<int, ThreadLog> _threadsLogs = new ConcurrentDictionary<int, ThreadLog>();

        public ConcurrentDictionary<int, ThreadLog> GetThreadLogs()
        {
            return _threadsLogs;
        }
        public void StartTracingThread(int idThread, MethodBase methodBase)
        {
            var threadLog = new ThreadLog {ThreadId = idThread};

            var threadInfo = _threadsLogs.GetOrAdd(idThread, threadLog);
            threadInfo.StartTracingMethod(new MethodLog(methodBase));
        }

        public void StopTracingThread(int idThread)
        {
            if (_threadsLogs.TryGetValue(idThread, out var threadInfo)) threadInfo.StopTrace();
        }
    }
}