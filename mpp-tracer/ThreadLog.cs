using System.Collections.Generic;

namespace mpp_tracer
{
    public class ThreadLog
    {
        public int ThreadId { get; set; } 
        public long TimeSpent;

        public List<MethodLog> AllMethods { get; } = new List<MethodLog>();
        private Stack<MethodLog> _methodStackTrace = new Stack<MethodLog>();

        public void StartTracingMethod(MethodLog methodLog)
        {
            if (AllMethods.Count == 0)
            {
                AllMethods.Add(methodLog);
            }
            else
            {
                _methodStackTrace.Peek().AddNestedMethods(methodLog);
            }
            _methodStackTrace.Push(methodLog);
        }

        public void StopTrace()
        {
            _methodStackTrace.Pop().StopTrace();
        }
    }
}