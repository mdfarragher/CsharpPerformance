using System;
using System.Collections;

using BenchmarkDotNet.Attributes;

namespace ForVsForeach
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
		public int Size;

		// fields
		public List<int>? TheList = null;

        [GlobalSetup]
		public void Setup ()
		{
            TheList = new List<int> (Size);
			Random random = new Random ();
			for (int i = 0; i < Size; i++)
			{
				int number = random.Next (256);
				TheList.Add (number);
			}

		}

        [Benchmark]
		public void Unoptimized ()
		{
            if (TheList == null)
                throw new NullReferenceException("TheList cannot be null");
			foreach (int i in TheList)
			{
				int result = i;
			}
		}

        [Benchmark]
		public void Optimized ()
		{
			// Put your optimized code here
		}

	}
}
