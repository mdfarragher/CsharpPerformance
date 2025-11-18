using System;

using BenchmarkDotNet.Attributes;

namespace Exceptions
{
    public class Benchmarks
	{
		// constants
        [Params(1000000)]
		public int ListSize;

		// fields
		public List<int> Numbers = new List<int> ();

		public Dictionary<int,string> Lookup = new Dictionary<int, string> 
        {
			{ 0, "zero" },
			{ 1, "one" },
			{ 2, "two" },
			{ 3, "three" },
			{ 4, "four" },
			{ 5, "five" },
			{ 6, "six" },
			{ 7, "seven" },
			{ 8, "eight" },
			{ 9, "nine" }
		};

        [GlobalSetup]
		public void Setup ()
		{
			Random random = new Random ();
			for (int i = 0; i < ListSize; i++)
			{
				Numbers.Add (random.Next (11)); // 9% is out of bounds
			}
		}

        [Benchmark]
		public void WithException ()
		{
			for (int i = 0; i < ListSize; i++)
			{
				string? s = null;
				try
				{
					s = Lookup [Numbers [i]];
				}
				catch (KeyNotFoundException)
				{
				}
			}
		}

        [Benchmark]
		public void WithoutException ()
		{
			for (int i = 0; i < ListSize; i++)
			{
				string? s = null;
				int key = Numbers [i];
				if (Lookup.ContainsKey (key))
					s = Lookup [key];
			}
		}

	}
}
