using mpp_tracer;
using mpp_tracer.Classes.Model;

namespace Util.Interfaces
{
    public interface IWriter
    {
        void WriteString(string _string);
        void WriteTraceResult(TraceResult traceResult);
    }
}