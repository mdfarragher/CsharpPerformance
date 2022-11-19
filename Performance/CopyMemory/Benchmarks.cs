using System;
using System.Text;

using BenchmarkDotNet.Attributes;

namespace CopyMemory
{
    [CsvExporter]
	public class Benchmarks
	{
		// ==============================================================================
		// Benchmarks
		//
		// Complete this benchmark class so that you can measure the performance of:
		//   - The unoptimized code
		//   - The optimized code
		//
		// How much faster can you make the code?
		// ==============================================================================

        private const int BUFFER_SIZE = 1_000_000;

        private byte[]? sourceBuffer = null;
        private byte[]? destinationBuffer = null;

        [GlobalSetup()]
		public void Setup()
		{
            sourceBuffer = new byte[BUFFER_SIZE];
            destinationBuffer = new byte[BUFFER_SIZE];
            for (int i = 0; i < BUFFER_SIZE; i++)
                sourceBuffer[i] = (byte) (i % 255);
		}

        [Benchmark()]
		public void Unoptimized()
		{
            if (sourceBuffer == null || destinationBuffer == null)
                throw new NullReferenceException("Buffer1 or buffer2 cannot be null");
            for (int j = 0; j < BUFFER_SIZE; j++)
            {
                destinationBuffer[j] = sourceBuffer[j];
            }
		}

        [Benchmark()]
		public void Optimized()
		{
            // Put your optimized code here
		}

	}
}