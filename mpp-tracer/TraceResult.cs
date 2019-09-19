using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace mpp_tracer
{
    public class TraceResult
    {
        private readonly ConcurrentDictionary<int, ThreadLog> _threadsLogs = new ConcurrentDictionary<int, ThreadLog>();

        public IEnumerable<KeyValuePair<int, ThreadLog>> ThreadsLogs => _threadsLogs;

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