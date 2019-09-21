using Newtonsoft.Json;

namespace mpp_tracer
{
    public class JsonTraceResultFormatter : ITraceResultFormatter
    {
        public string FormatTraceResult(TraceResult traceResult)
        {
            return JsonConvert.SerializeObject(traceResult, Formatting.Indented);
        }
    }
}