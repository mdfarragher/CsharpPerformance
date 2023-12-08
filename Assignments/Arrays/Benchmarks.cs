using System;

using BenchmarkDotNet.Attributes;

namespace Arrays
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

        [Params(5000)]
        public int ArraySize;

        int[,]? list2;

        [GlobalSetup]
        public void Setup()
        {
			list2 = new int[ArraySize, ArraySize];
        }

        [Benchmark]
		public void Unoptimized ()
		{
            if (list2 == null)
                throw new NullReferenceException("list2 cannot be null");
			for (int i = 0; i < ArraySize; i++)
			{
				for (int j = 0; j < ArraySize; j++)
				{
					list2 [i, j] = 1;
				}
			}
		}

        [Benchmark]
		public void Optimized ()
		{
			// Put your optimized code here
		}

	}
}