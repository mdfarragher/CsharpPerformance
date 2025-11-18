using System;
using System.Text;

using BenchmarkDotNet.Attributes;

namespace CopyMemory
{
	public class Benchmarks
	{
        private const int BUFFER_SIZE = 1_000_000;

        private byte[]? buffer1 = null;
        private byte[]? buffer2 = null;

        [GlobalSetup()]
		public void Setup()
		{
            buffer1 = new byte[BUFFER_SIZE];
            buffer2 = new byte[BUFFER_SIZE];
		}

        [Benchmark()]
		public void UseArrays()
		{
            for (int j = 0; j < BUFFER_SIZE; j++)
            {
                buffer2[j] = buffer1[j];
            }
		}

        [Benchmark()]
		public unsafe void UsePointers()
		{
            fixed (byte* fixed1 = &buffer1[0])
            fixed (byte* fixed2 = &buffer2[0])
			{
                var source = fixed1;
                var dest = fixed2;
                for (int j = 0; j < BUFFER_SIZE; j++)
                {
                    *(dest++) = *(source++);
                }
			}
		}

        [Benchmark()]
		public void UseCopy()
		{
            buffer1.CopyTo(buffer2, 0);
		}

	}
}