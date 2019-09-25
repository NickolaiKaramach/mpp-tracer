using mpp_tracer;
using mpp_tracer.Classes.Model;

namespace Util.Interfaces
{
    public interface ITraceResultFormatter
    {
        string FormatTraceResult(TraceResult traceResult);
    }
}