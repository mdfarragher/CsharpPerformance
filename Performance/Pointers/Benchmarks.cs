using System;

using BenchmarkDotNet.Attributes;

namespace Pointers
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

        [Params(4096)]
        public int ArraySize;

        [Benchmark]
		public void Unoptimized ()
		{
			byte[] image = new byte[ArraySize * ArraySize * 3];
			for (int i = 0; i < image.Length;)
			{
				byte grey = (byte)(.299 * image [i + 2] + .587 * image [i + 1] + .114 * image [i]);
				image [i] = grey;
				image [i + 1] = grey;
				image [i + 2] = grey;
				i += 3;
			}
		}

        [Benchmark]
		public void Optimized ()
		{
			// Put your optimized code here
		}

	}
}