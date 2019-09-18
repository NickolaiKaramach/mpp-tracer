using System.Reflection;

namespace mpp_tracer
{
    public class MethodMetadata
    {
        private string Name { get; }
        private string ClassName { get; }
        private int CountParameters { get; }

        internal MethodMetadata(MethodBase methodBase)
        {
            Name = methodBase.Name;
            ClassName = methodBase.DeclaringType?.ToString();
            CountParameters = methodBase.GetParameters().Length;
        }
    }
}