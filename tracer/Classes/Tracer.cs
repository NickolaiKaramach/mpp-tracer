using System;
using System.Diagnostics;
using System.Threading;
using mpp_tracer.Classes.Model;
using mpp_tracer.Interfaces;

namespace mpp_tracer.Classes
{
    public class Tracer : ITracer
    {
        private readonly TraceResult _traceResult;
        private Lazy<Tracer> _instance = new Lazy<Tracer>(() => new Tracer());

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

        public Tracer GetInstance()
        {
            return _instance.Value;
        }
    }
}