using System;
using System.Threading;
using tracer.Classes;
using tracer.Interfaces;

namespace UtilApp.Runner
{
    public static class ActionClass
    {
        private static readonly ITracer TracerInstance = Tracer.GetInstance();
        
        public static void Job1()
        {
            TracerInstance.StartTrace();
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job1 started");

            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job1 ended");
            TracerInstance.StopTrace();
        }

        public static void Job2()
        {
            TracerInstance.StartTrace();
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job2 started");

            Job1();
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job2 ended");
            TracerInstance.StopTrace();
        }

        public static void Job3()
        {
            TracerInstance.StartTrace();
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job3 started");

            Thread.Sleep(1000);
            Job2();

            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job3 ended");
            TracerInstance.StopTrace();
        }
    }
}