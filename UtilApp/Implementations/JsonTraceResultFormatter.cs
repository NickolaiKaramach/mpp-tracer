using Newtonsoft.Json;
using tracer.Classes.Model;

namespace UtilApp.Implementations
{
    public class JsonTraceResultFormatter : Interfaces.ITraceResultFormatter
    {
        public string FormatTraceResult(TraceResult traceResult)
        {
            return JsonConvert.SerializeObject(traceResult, Formatting.Indented);
        }
    }
}