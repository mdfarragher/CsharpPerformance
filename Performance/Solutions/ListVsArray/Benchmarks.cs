using System;
using System.Collections;

using BenchmarkDotNet.Attributes;

namespace ListVsArray
{
    [CsvMeasurementsExporter]
    [RPlotExporter]
	public class Benchmarks
	{
        [Params(1000000)]
		public int ArraySize;

        [Benchmark]
		public void GenericList() 
		{
			List<int> list = new List<int> (ArraySize);
			for (int i = 0; i < ArraySize; i++) 
			{
				list.Add(i);
			}
		}

        [Benchmark]
		public void Array() 
		{
			int[] list = new int[ArraySize];
			for (int i = 0; i < ArraySize; i++) 
			{
				list [i] = i;
			}
		}
	}
}