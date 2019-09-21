using System;

namespace mpp_tracer
{
    public interface IWriter
    {
        void WriteString(string _string);
        void WriteTraceResult(TraceResult traceResult);
    }
}