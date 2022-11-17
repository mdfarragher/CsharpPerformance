using System;
using System.Collections;

using BenchmarkDotNet.Attributes;

namespace StructsVsClasses
{
    public struct PointStruct
    {
        public int X ;
        public int Y;
    }

    public class PointClass
    {
        public int X = 0;
        public int Y = 0;
    }

    [CsvMeasurementsExporter]
    [RPlotExporter]
	public class Benchmarks
	{
		public int ListSize = 1000000;

        public List<PointStruct>? structList = null;
        public List<PointClass>? classList = null;


        [GlobalSetup]
        public void Setup()
        {
			structList = new List<PointStruct>(ListSize);
			classList = new List<PointClass>(ListSize);
            for (int i=0; i < ListSize; i++)
            {
                structList.Add(new PointStruct());
                classList.Add(new PointClass());
            }
        }

        [Benchmark]
		public void UseStructs() 
		{
            if (structList == null)
                throw new NullReferenceException("structList cannot be null");
            int result = 0;
			for (int i = 0; i < ListSize; i++) 
			{
				var point = structList[i];
                result = result + point.X;
                result = result + point.Y;
			}
		}

        [Benchmark]
		public void UseClasses() 
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

	}
}