using System;

namespace mpp_tracer
{
    public interface ITraceResultFormatter
    {
        String FormatTraceResult(TraceResult traceResult);
    }
}