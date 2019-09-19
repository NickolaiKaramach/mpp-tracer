using System.Diagnostics;
using System.Threading;

namespace mpp_tracer
{
    public class Tracer : ITracer
    {
        private readonly TraceResult _traceResult;
        private Tracer _instanse;

        public Tracer()
        {
            _traceResult = new TraceResult();
        }

        public void StartTrace()
        {
            var method = new StackTrace(1).GetFrame(0).GetMethod();
            var idThread = Thread.CurrentThread.ManagedThreadId;

            _traceResult.StartTracingThread(idThread, method);
        }

        public void StopTrace()
        {
            var idThread = Thread.CurrentThread.ManagedThreadId;
            _traceResult.StopTracingThread(idThread);
        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }

        public Tracer getInstanse()
        {
            if (_instanse != null) return _instanse;

            lock (this)
            {
                if (_instanse == null) _instanse = new Tracer();
            }

            return _instanse;
        }
    }
}