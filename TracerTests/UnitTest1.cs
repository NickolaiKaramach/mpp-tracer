using System.Linq;
using System.Threading;
using NUnit.Framework;
using tracer.Classes;
using tracer.Interfaces;
using UtilApp.Runner;

namespace TracerTests
{
    public class Tests
    {
        private static readonly ITracer Tracer = tracer.Classes.Tracer.GetInstance();

        [TearDown]
        public void Cleanup()
        {
            Tracer.ClearTraceResult();
        }

        [Test]
        public void TestTraceTimeIsGreaterZeroOnWorkingCode()
        {
            Tracer.StartTrace();
            var sum = 0;

            for (var i = 0; i < 10000; i++)
            {
                for (var j = 0; j < 10000; j++)
                {
                    sum++;
                }
            }

            Tracer.StopTrace();

            Assert.Greater(GetTotalTimeSpent(), 0, "Total time spent should be greater zero.");
        }

        [Test]
        public void TestTracerTimeIsZeroOnDoNothingCode()
        {
            Tracer.StartTrace();
            //Do noting
            Tracer.StopTrace();

            Assert.Zero(GetTotalTimeSpent(), "Total time spent should be equal zero.");
        }

        [Test]
        public void TestTracerTimeIsGreaterThenSleepingTimeInsideTraceInterval()
        {
            Tracer.StartTrace();
            var sleepingTime = 1000;

            Thread.Sleep(sleepingTime + 1);
            Tracer.StopTrace();

            Assert.Greater(GetTotalTimeSpent(), sleepingTime,
                "Total time spent should be greater than time spent on sleeping.");
        }

        [Test]
        public void TestTracerResultHaveNestedMethods()
        {
            Tracer.StartTrace();

            ActionClass.Job1();
            ActionClass.Job2();

            Tracer.StopTrace();

            Assert.Less(
                1, Tracer.GetTraceResult()
                    .GetThreadLogs()[Thread.CurrentThread.ManagedThreadId]
                    .AllMethods[0]
                    .NestedMethods.Count,
                "Total amount of Nested method should be greater than 1");
        }

        private static long GetTotalTimeSpent()
        {
            return Tracer.GetTraceResult()
                .GetThreadLogs()
                .Select(map => map.Value)
                .ToList()
                .Select(threadLog => threadLog.TimeSpent)
                .Sum();
        }
    }
}