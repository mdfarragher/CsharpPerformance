using System;
using System.Collections;

using BenchmarkDotNet.Attributes;

namespace ListVsArray
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

        [Params(1000000)]
		public int ArraySize;

        [Benchmark]
		public void Unoptimized() 
		{
			List<int> list = new List<int> (ArraySize);
			for (int i = 0; i < ArraySize; i++) 
			{
				list.Add(i);
			}
		}

        [Benchmark]
		public void Optimized() 
		{
			// Put your optimized code here
		}
	}
}