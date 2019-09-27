using System;
using tracer.Classes.Model;
using ITraceResultFormatter = UtilApp.Interfaces.ITraceResultFormatter;

namespace UtilApp.Implementations
{
    public class ConsoleWriter : Interfaces.IWriter
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