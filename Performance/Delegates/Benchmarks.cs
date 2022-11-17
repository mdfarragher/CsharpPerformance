using System;

using BenchmarkDotNet.Attributes;

namespace Delegates
{
    [CsvExporter]
	public class Benchmarks
	{
		// ==============================================================================
		// Benchmarks
		//
		// Complete this benchmark class so that you can measure the performance of:
		//   - Calling a method directly
		//   - Calling a method with a unicast delegate
		//   - Calling a method with a multicast delegate
		//
		// Which is the fastest in C#?
		// ==============================================================================

		public void Add1 (int a, int b, out int result)
		{
			result = a + b;
		}

		public void Add2 (int a, int b, out int result)
		{
			result = a + b;
		}

        [GlobalSetup]
        public void Setup()
        {
			// Put any benchmark setup code here
        }

        [Benchmark]
		public void CallDirect ()
		{
            int result;
            Add1 (1234, 2345, out result);
            Add2 (1234, 2345, out result);
		}

        [Benchmark]
		public void UnicastDelegate ()
		{
			// Put code here that calls Add1 and Add2 with a unicast delegate
		}

		// Call Add1 and Add2 using 1 multicast delegate
        [Benchmark]
		public void MulticastDelegate ()
		{
			// Put code here that calls Add1 and Add2 with a multicast delegate
		}

	}
}