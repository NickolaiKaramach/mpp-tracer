using mpp_tracer.Classes.Model;

namespace mpp_tracer.Interfaces
{
    public interface ITracer
    {
        void StartTrace();

        void StopTrace();

        TraceResult GetTraceResult();
    }
}