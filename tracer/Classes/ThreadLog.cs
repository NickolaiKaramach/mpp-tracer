using System.Collections.Generic;
using System.Linq;

namespace mpp_tracer.Classes
{
    public class ThreadLog
    {
        private readonly Stack<MethodLog> _methodStackTrace = new Stack<MethodLog>();
        public int ThreadId { get; set; }
        public long TimeSpent => AllMethods.Select(x => x.TimeSpent).Sum();
        public List<MethodLog> AllMethods { get; } = new List<MethodLog>();


        public void StartTracingMethod(MethodLog methodLog)
        {
            if (AllMethods.Count == 0)
                AllMethods.Add(methodLog);
            else
                _methodStackTrace.Peek().AddNestedMethods(methodLog);

            _methodStackTrace.Push(methodLog);
        }

        public void StopTrace()
        {
            _methodStackTrace.Pop().StopTrace();
        }
    }
}