using System;
using System.Diagnostics;
using System.Threading;
using tracer.Classes.Model;
using tracer.Interfaces;

namespace tracer.Classes
{
    public class Tracer : ITracer
    {
        private TraceResult _traceResult;
        private static readonly Lazy<Tracer> Instance = new Lazy<Tracer>(() => new Tracer());

        private Tracer()
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

        public static ITracer GetInstance()
        {
            return Instance.Value;
        }

        public void ClearTraceResult()
        {
            _traceResult = new TraceResult();
        }
    }
}