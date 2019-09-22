using System;
using System.Threading;

namespace Util.Runner
{
    public static class ActionClass
    {
        public static void Job1()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job1 started");

            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job1 ended");
        }

        public static void Job2()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job2 started");

            Job1();
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job2 ended");
        }

        public static void Job3()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}:Job3 started");

            Thread.Sleep(1000);
            Job2();

            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name}:Job3 ended");
        }
    }
}