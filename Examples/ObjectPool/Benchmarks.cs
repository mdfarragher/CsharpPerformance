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

        public bool[] IsInUse = new bool[NumberOfPooledObjects];

        public byte[][] Pool = new byte[NumberOfPooledObjects][];

        public byte[] GetBuffer()
        {
            // allocate and return a new byte buffer
            Interlocked.Increment(ref MainClass.BufferAllocations);
            return new byte[BufferSize];
        }

        public byte[] GetPooledBuffer()
        {
            // find the first free buffer
            for (int i = 0; i < NumberOfPooledObjects; i++)
            {
                if (!IsInUse[i])
                {
                    // allocate buffer on demand
                    if (Pool[i] == null)
                    {
                        Interlocked.Increment(ref MainClass.BufferAllocations);
                        Pool[i] = new byte[BufferSize];
                        return Pool[i];
                    }

                    // or clear an existing buffer and return
                    else
                    {
                        Array.Clear(Pool[i]);
                        return Pool[i];
                    }
                }
            }

            // at this point no free buffer is available so we throw an exception
            throw new InvalidOperationException("All buffers in use, app cannot continue");
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
            // find the buffer and release it
            for (int i = 0; i < NumberOfPooledObjects; i++)
            {
                if (Pool[i] == buffer)
                {
                    IsInUse[i] = false;
                    return;
                }
            }

            // we're trying to release a nonexisting buffer so we throw an exception
            throw new InvalidOperationException("The specified buffer does not exist in the pool");
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
