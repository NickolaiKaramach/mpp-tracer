using System;
using System.Diagnostics;
using System.Threading;
using tracer.Classes;
using tracer.Classes.Model;

namespace UtilApp.Runner
{
    public static class ActionClass
    {
        private static Tracer _tracerInstance = Tracer.GetInstance();
        
        public static void Job1()
        {
            _tracerInstance.StartTrace();
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job1 started");

            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job1 ended");
            _tracerInstance.StopTrace();
        }

        public static void Job2()
        {
            _tracerInstance.StartTrace();
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job2 started");

            Job1();
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job2 ended");
            _tracerInstance.StopTrace();
        }

        public static void Job3()
        {
            _tracerInstance.StartTrace();
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job3 started");

            Thread.Sleep(1000);
            Job2();

            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job3 ended");
            _tracerInstance.StopTrace();
        }
    }
}