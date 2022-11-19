using System;
using System.Threading;
using System.Diagnostics;

namespace Dispose
{
    public class WorkObject
    {
        public Stopwatch stopWatch = new Stopwatch();

        // object constructor
        public WorkObject()
        {
            stopWatch.Start();
        }

        public void DoWork()
        {
            // simulate work
            int result = 0;
            for (int i = 0; i < 10_000; i++)
                result += i;
        }

        // object finalizer
        ~WorkObject()
        {
            stopWatch.Stop();
            Interlocked.Increment(ref MainClass.TotalFinalized);
            Interlocked.Add(ref MainClass.Lifetime, (int)stopWatch.ElapsedMilliseconds);
        }
        
    }
}