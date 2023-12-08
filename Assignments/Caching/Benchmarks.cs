using System;
using System.Runtime.Caching;

using BenchmarkDotNet.Attributes;

namespace Caching
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
        
        public int TotalToCalculate = 40;

        public int Fibonacci(int n)
        {
            return n < 2 ? n : Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        [Benchmark()]
		public void UnoptimizedCode()
		{
            for (int j = 0; j < TotalToCalculate; j++)
            {
                var result = Fibonacci(j);
            }
		}

        [Benchmark()]
		public void Optimized()
		{
            // Put your optimized code here
		}

	}
}