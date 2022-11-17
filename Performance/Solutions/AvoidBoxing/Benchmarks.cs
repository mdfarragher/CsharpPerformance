using System;
using BenchmarkDotNet.Attributes;

namespace AvoidBoxing
{
    [CsvMeasurementsExporter]
    [RPlotExporter]
	public class Benchmarks
	{
		// constants
		private const int repetitions = 1000000;

        [Benchmark]
		public void MeasureA() 
		{
			int a = 1;
			for (int i = 0; i < repetitions; i++) 
			{
				a = a + 1;
			}
		}

        [Benchmark]
		public void MeasureB() 
		{
			object a = 1;
			for (int i = 0; i < repetitions; i++) 
			{
				a = (int)a + 1;
			}
		}
	}
}