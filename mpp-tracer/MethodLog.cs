using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace mpp_tracer
{
    public class MethodLog
    {
        private MethodMetadata _metadata;

        private readonly List<MethodLog> _methods = new List<MethodLog>();
        
        public long TimeSpent => _watch.ElapsedMilliseconds;
        private readonly Stopwatch _watch = new Stopwatch();

        public MethodLog(MethodBase methodBase)
        {
            _metadata = new MethodMetadata(methodBase);
        }

        public void StartTrace()
        {
            _watch.Start();
        }

        public void StopTrace()
        {
            _watch.Stop();
        }

        public void AddNestedMethods(MethodLog methodLog)
        {
            _methods.Add(methodLog);
        }
    }
}