using tracer.Classes.Model;

namespace UtilApp.Interfaces
{
    public interface IWriter
    {
        void WriteString(string _string);
        void WriteTraceResult(TraceResult traceResult);
    }
}