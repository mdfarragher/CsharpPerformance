using System;
using System.Collections;

using BenchmarkDotNet.Attributes;

namespace StructsVsClasses
{
    public class PointClass
    {
        public int X = 0;
        public int Y = 0;
    }

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

		public int ListSize = 1000000;

        public List<PointClass>? classList = null;


        [GlobalSetup]
        public void Setup()
        {
			classList = new List<PointClass>(ListSize);
            for (int i=0; i < ListSize; i++)
            {
                classList.Add(new PointClass());
            }
        }

        [Benchmark]
		public void Unoptimized() 
		{
            if (classList == null)
                throw new NullReferenceException("classList cannot be null");
            int result = 0;
			for (int i = 0; i < ListSize; i++) 
			{
				var point = classList[i];
                result = result + point.X;
                result = result + point.Y;
			}
		}

        [Benchmark]
		public void Optimized() 
		{
            // Put your optimized code here
		}


	}
}