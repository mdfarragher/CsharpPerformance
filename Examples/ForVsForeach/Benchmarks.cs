using System;
using System.Collections;

using BenchmarkDotNet.Attributes;

namespace ForVsForeach
{
    [CsvMeasurementsExporter]
    [RPlotExporter]
	public class Benchmarks
	{
		[Params(1000000)]
		public int Size;

		// fields
		public List<int>? TheList = null;
		public int[]? TheArray = null;

        [GlobalSetup]
		public void Setup ()
		{
            TheList = new List<int> (Size);
            TheArray = new int[Size];
			Random random = new Random ();
			for (int i = 0; i < Size; i++)
			{
				int number = random.Next (256);
				TheList.Add (number);
				TheArray [i] = number;
			}

		}

        [Benchmark]
		public void ForOnList ()
		{
            if (TheList == null)
                throw new NullReferenceException("TheList cannot be null");
			for (int i = 0; i < Size; i++)
			{
				int result = TheList [i];
			}
		}

        [Benchmark]
		public void ForeachOnList ()
		{
            if (TheList == null)
                throw new NullReferenceException("TheList cannot be null");
			foreach (int i in TheList)
			{
				int result = i;
			}
		}

        [Benchmark]
		public void ForOnArray ()
		{
            if (TheArray == null)
                throw new NullReferenceException("TheArray cannot be null");
			for (int i = 0; i < Size; i++)
			{
				int result = TheArray [i];
			}
		}

        [Benchmark]
		public void ForeachOnArray ()
		{
            if (TheArray == null)
                throw new NullReferenceException("TheArray cannot be null");
			foreach (int i in TheArray)
			{
				int result = i;
			}
		}

	}
}
