using System;
using mpp_tracer;
using mpp_tracer.Classes.Model;
using ITraceResultFormatter = Util.Interfaces.ITraceResultFormatter;
using IWriter = Util.Interfaces.IWriter;

namespace Util.Implementations
{
    public class ConsoleWriter : IWriter
    {
        private readonly ITraceResultFormatter _formatter;

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