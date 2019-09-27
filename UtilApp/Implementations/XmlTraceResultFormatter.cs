using System.Collections.Generic;
using System.Xml.Linq;
using tracer.Classes;
using tracer.Classes.Model;

namespace UtilApp.Implementations
{
    public class XmlTraceResultFormatter : Interfaces.ITraceResultFormatter
    {
        public string FormatTraceResult(TraceResult traceResult)
        {
            var xDoc = new XDocument();
            var rootNode = new XElement("threads");

            foreach (var threadLog in traceResult.ThreadsLogs)
            {
                var threadNode = FormatThreadNode(threadLog);

                foreach (var methodLog in threadLog.Value.AllMethods) threadNode.Add(FormatAllMethodNode(methodLog));

                rootNode.Add(threadNode);
            }

            xDoc.Add(rootNode);
            return xDoc.ToString();
        }

        private XElement FormatThreadNode(KeyValuePair<int, ThreadLog> threadInfo)
        {
            var result = new XElement("thread");
            var (key, value) = threadInfo;
            
            result.Add(new XAttribute("id", key));
            result.Add(new XAttribute("time", value.TimeSpent));

            return result;
        }
        
        private XElement FormatAllMethodNode(MethodLog methodLog)
        {
            var result = FormatMethodNode(methodLog);

            foreach (var nestedMethod in methodLog.NestedMethods) result.Add(FormatAllMethodNode(nestedMethod));

            return result;
        }

        private XElement FormatMethodNode(MethodLog methodLog)
        {
            var result = new XElement("method");

            result.Add(new XAttribute("name", methodLog.Metadata.Name));
            result.Add(new XAttribute("time", methodLog.TimeSpent));
            result.Add(new XAttribute("class", methodLog.Metadata.ClassName));
            result.Add(new XAttribute("params", methodLog.Metadata.CountOfParameters));

            return result;
        }
    }
}