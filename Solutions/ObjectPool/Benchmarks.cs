using System;

using BenchmarkDotNet.Attributes;

namespace ObjectPool
{
    [MemoryDiagnoser]
    public class Benchmarks
	{
		// constants
		public int BufferSize = 1000000;

		public int ArrayIterations = 1000;

        public const int NumberOfPooledObjects = 10;

        public int poolIndex = 0;

        public bool[]? IsInUse = null;

        public byte[][]? Pool = null;

        [GlobalSetup]
        public void Setup()
        {
            IsInUse = new bool[NumberOfPooledObjects];
            Pool = new byte[NumberOfPooledObjects][];
        }

        public byte[] GetBuffer()
        {
            // allocate and return a new byte buffer
            return new byte[BufferSize];
        }

        public byte[] GetPooledBuffer()
        {
            // grab the next buffer (it's always free)
            var i = poolIndex++ % NumberOfPooledObjects;

            if (!IsInUse[i])
            {
                // allocate buffer on demand
                if (Pool[i] == null)
                {
                    Pool[i] = new byte[BufferSize];
                    IsInUse[i] = true;
                    return Pool[i];
                }

                // or clear an existing buffer and return
                else
                {
                    Array.Clear(Pool[i]);
                    IsInUse[i] = true;
                    return Pool[i];
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
