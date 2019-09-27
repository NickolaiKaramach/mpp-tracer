using tracer.Classes.Model;

namespace UtilApp.Interfaces
{
    public interface ITraceResultFormatter
    {
        string FormatTraceResult(TraceResult traceResult);
    }
}