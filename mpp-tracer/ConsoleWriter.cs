using System;

namespace mpp_tracer
{
    public class ConsoleWriter : IWriter
    {
        private ITraceResultFormatter _formatter;

        public ConsoleWriter(ITraceResultFormatter formatter)
        {
            _formatter = formatter;
        }

        public void WriteString(string _string)
        {
            Console.WriteLine(_string);
        }

        public void WriteTraceResult(TraceResult traceResult)
        {
            WriteString(_formatter.FormatTraceResult(traceResult));
        }
    }
}