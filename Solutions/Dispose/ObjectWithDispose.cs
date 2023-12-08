using System;
using System.Threading;
using System.Diagnostics;

namespace Dispose
{
    public class ObjectWithDispose : IDisposable
    {
        public Stopwatch stopWatch = new Stopwatch();

        private bool disposed = false;

        // object constructor
        public ObjectWithDispose()
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    stopWatch.Stop();
                }
                Interlocked.Increment(ref MainClass.TotalFinalized);
                Interlocked.Add(ref MainClass.Lifetime, (int)stopWatch.ElapsedMilliseconds);
                disposed = true;
            }
        }

        // object finalizer
        ~ObjectWithDispose()
        {
            Dispose(false);
        }
        
    }
}