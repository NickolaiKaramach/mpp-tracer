using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using mpp_tracer.Classes.Model;

namespace mpp_tracer.Classes
{
    public class MethodLog
    {
        private readonly Stopwatch _watch = new Stopwatch();
        public readonly List<MethodLog> NestedMethods = new List<MethodLog>();

        public MethodLog(MethodBase methodBase)
        {
            Metadata = new MethodMetadata(methodBase);
            StartTrace();
        }

        public MethodMetadata Metadata { get; }

        public long TimeSpent => _watch.ElapsedMilliseconds;

        private void StartTrace()
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