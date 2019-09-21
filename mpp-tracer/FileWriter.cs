using System;
using System.IO;
using System.Runtime.Serialization;

namespace mpp_tracer
{
    public class FileWriter : IWriter
    {
        private ITraceResultFormatter _iTraceResultFormatter;
        public string UriToFile { get; set; }

        public FileWriter(ITraceResultFormatter traceResultFormatter, string uriToFile)
        {
            _iTraceResultFormatter = traceResultFormatter;
            UriToFile = uriToFile;
        }

        public void WriteString(string _string)
        {
            try
            {
                FileStream fileStream = File.Open(UriToFile,
                    FileMode.Create, FileAccess.Write);

                StreamWriter fileWriter = new StreamWriter(fileStream);

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