using tracer.Classes.Model;

namespace tracer.Interfaces
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        TraceResult GetTraceResult();
    }
}