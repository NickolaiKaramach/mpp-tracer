using System.Threading;

namespace mpp_tracer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Thread thread1 = new Thread(() => ActionClass.Job3());
            Thread thread2 = new Thread(() => ActionClass.Job3());
            
            thread1.Name = "Thread#1 ";
            thread2.Name = "Thread#2 ";
            
            thread1.Start();
            Thread.Sleep(500);
            thread2.Start();
            
            thread1.Join();
            thread2.Join();
        }
    }
}