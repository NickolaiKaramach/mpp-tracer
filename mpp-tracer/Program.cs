﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace mpp_tracer
{
    public class Program
    {
        private static readonly Tracer Tracer = new Tracer();

        public static void Main1(string[] args)
        {
            var thread1 = new Thread(() => ActionClass.Job3());
            var thread2 = new Thread(() => ActionClass.Job3());

            thread1.Name = "Thread#1 ";
            thread2.Name = "Thread#2 ";

            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();

            thread1.Join();
            thread2.Join();
        }

        private static void Main()
        {
            Tracer.StartTrace();
            TestMethod1(10);
            TestMethod(10);

            var threads = new List<Thread>();

            for (var i = 0; i < 20; i++)
            {
                var thread = i % 3 == 0 ? new Thread(TestMethod) : new Thread(TestMethod1);
                threads.Add(thread);
                thread.Start(5);
            }

            TestMethod5();

            foreach (var thread in threads) thread.Join();

            Tracer.StopTrace();

            XmlTraceResultFormatter xmlTraceResultFormatter = new XmlTraceResultFormatter();
            JsonTraceResultFormatter jsonTraceResultFormatter = new JsonTraceResultFormatter();
            FileWriter fileWriter = new FileWriter(jsonTraceResultFormatter, "text.json");
            ConsoleWriter consoleWriter = new ConsoleWriter(xmlTraceResultFormatter);
            
            consoleWriter.WriteTraceResult(Tracer.GetTraceResult());
            
            fileWriter.WriteTraceResult(Tracer.GetTraceResult());
            Console.ReadKey();
        }

        private static void TestMethod(object value)
        {
            Tracer.StartTrace();
            var testInt = 0;
            Thread.Sleep(100);
            TestMethod1(int.MaxValue);
            for (var i = 0; i < (int) value; i++) testInt += i;
            TestMethod3(10);
            Tracer.StopTrace();
        }

        private static void TestMethod3(object value)
        {
            for (var i = 0; i < (int) value; i++)
            {
                Tracer.StartTrace();
                VoidMethod();
                Tracer.StopTrace();
            }
        }

        private static void TestMethod4()
        {
            Tracer.StartTrace();
            Thread.Sleep(10);
            Tracer.StopTrace();
        }

        private static void VoidMethod()
        {
            Tracer.StartTrace();
            Thread.Sleep(10);
            Tracer.StopTrace();
        }

        private static void TestMethod5()
        {
            Tracer.StartTrace();
            for (var i = 0; i < 5; i++)
            {
                var thread = new Thread(TestMethod4);
                thread.Start();
            }

            Tracer.StopTrace();
        }

        private static void TestMethod1(object value)
        {
            Tracer.StartTrace();
            Thread.Sleep(100);
            Tracer.StopTrace();
        }
    }
}