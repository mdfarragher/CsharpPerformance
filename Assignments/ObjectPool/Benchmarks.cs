using System;

using BenchmarkDotNet.Attributes;

namespace ObjectPool
{
    public class Benchmarks
	{
		// constants
		public int BufferSize = 1000000;
		public int ArrayIterations = 10000;

        public const int NumberOfPooledObjects = 10;

        public byte[] GetBuffer()
        {
            // allocate and return a new byte buffer
            Interlocked.Increment(ref MainClass.BufferAllocations);
            return new byte[BufferSize];
        }

        public byte[] GetPooledBuffer()
        {
            // Put your object pooling implementation here
            throw new NotImplementedException();
        }

        public void UseTheBuffer(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer [i] = (byte)i;
            }
        }

        public void ReleaseBuffer(byte[] buffer)
        {
            // Put your object pooling implementation here
            throw new NotImplementedException();
        }

        [Benchmark]
		public void Unoptimized ()
		{
			for (int i = 0; i < ArrayIterations; i++)
			{
                var buffer = GetBuffer();
                UseTheBuffer(buffer);
			}
		}

        [Benchmark]
		public void Optimized ()
		{
			for (int i = 0; i < ArrayIterations; i++)
			{
                var buffer = GetPooledBuffer();
                UseTheBuffer(buffer);
                ReleaseBuffer(buffer);
			}
		}

	}
}
