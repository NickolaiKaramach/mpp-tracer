using System;
using System.IO;
using mpp_tracer.Classes.Model;
using Util.Interfaces;

namespace Util.Implementations
{
    public class FileWriter : IWriter
    {
        private readonly ITraceResultFormatter _iTraceResultFormatter;

        public FileWriter(ITraceResultFormatter traceResultFormatter, string uriToFile)
        {
            _iTraceResultFormatter = traceResultFormatter;
            UriToFile = uriToFile;
        }

        public string UriToFile { get; set; }

        public void WriteString(string _string)
        {
            try
            {
                var fileStream = File.Open(UriToFile,
                    FileMode.Create, FileAccess.Write);

                var fileWriter = new StreamWriter(fileStream);

                fileWriter.WriteLine(_string);
                fileWriter.Flush();
                fileWriter.Close();
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe);
            }
        }

        public void WriteTraceResult(TraceResult traceResult)
        {
            WriteString(_iTraceResultFormatter.FormatTraceResult(traceResult));
        }
    }
}