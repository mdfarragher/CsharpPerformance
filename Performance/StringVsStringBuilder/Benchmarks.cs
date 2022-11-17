using System;
using System.Text;

using BenchmarkDotNet.Attributes;

namespace StringVsStringBuilder
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

		[Params(500)]
        public int Additions;

        [Benchmark]
		public void Unoptimized() 
		{
            string s = string.Empty;
            for (int j = 0; j < Additions; j++) 
            {
                s = s + "a";
            }
		}

        [Benchmark]
		public void Optimized() 
		{
            // Put your optimized code here
		}
	}
}