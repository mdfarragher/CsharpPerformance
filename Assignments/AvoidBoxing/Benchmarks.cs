using System;
using BenchmarkDotNet.Attributes;

namespace AvoidBoxing
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

		private const int Repetitions = 1000000;

        [Benchmark]
		public void Unoptimized() 
		{
			object a = 1;
			for (int i = 0; i < Repetitions; i++) 
			{
				a = (int)a + 1;
			}
		}

        [Benchmark]
		public void Optimized() 
		{
			// Put your optimized code here
		}
	}
}