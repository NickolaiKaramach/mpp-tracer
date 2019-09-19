using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace mpp_tracer
{
    public class MethodLog
    {
        public readonly List<MethodLog> NestedMethods = new List<MethodLog>();
        private readonly Stopwatch _watch = new Stopwatch();
        public MethodMetadata Metadata { get; }

        public MethodLog(MethodBase methodBase)
        {
            Metadata = new MethodMetadata(methodBase);
            StartTrace();
        }

        public long TimeSpent => _watch.ElapsedMilliseconds;

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
            NestedMethods.Add(methodLog);
        }
    }
}