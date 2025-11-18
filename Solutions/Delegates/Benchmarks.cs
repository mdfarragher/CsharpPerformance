using System;

using BenchmarkDotNet.Attributes;

namespace Delegates
{
	public class Benchmarks
	{
		// declare delegate
		public delegate void AddDelegate (int a, int b, out int result);

        // delegate fields
        public AddDelegate? add1 = null;
        public AddDelegate? add2 = null;
        public AddDelegate? multiAdd = null;

		// set up first addition method
		public void Add1 (int a, int b, out int result)
		{
			result = a + b;
		}

		// set up second addition method
		public void Add2 (int a, int b, out int result)
		{
			result = a + b;
		}

        [GlobalSetup]
        public void Setup()
        {
			add1 = Add1;
			add2 = Add2;
			multiAdd = Add1;
			multiAdd += Add2;
        }


		// Call Add1 and Add2 manually
        [Benchmark(Baseline = true)]
		public void CallDirect ()
		{
            int result;
            Add1 (1234, 2345, out result);
            Add2 (1234, 2345, out result);
		}

		// Call Add1 and Add2 using 2 unicast delegates
        [Benchmark]
		public void UnicastDelegate ()
		{
            int result;
            add1 (1234, 2345, out result);
            add2 (1234, 2345, out result);
		}

		// Call Add1 and Add2 using 1 multicast delegate
        [Benchmark]
		public void MulticastDelegate ()
		{
			int result = 0;
            multiAdd (1234, 2345, out result);
		}

	}
}