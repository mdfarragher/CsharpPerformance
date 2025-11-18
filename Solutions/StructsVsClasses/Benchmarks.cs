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

    [MemoryDiagnoser]
	public class Benchmarks
	{
		public int ListSize = 1000000;

        public List<PointStruct>? structList = null;
        public List<PointClass>? classList = null;


        [Benchmark]
		public void UseStructs() 
		{
			structList = new List<PointStruct>(ListSize);
            for (int i=0; i < ListSize; i++)
            {
                structList.Add(new PointStruct());
            }

            int result = 0;
			for (int i = 0; i < ListSize; i++) 
			{
				var point = structList[i];
                result += point.X;
                result += point.Y;
			}
		}

        [Benchmark]
		public void UseClasses() 
		{
			classList = new List<PointClass>(ListSize);
            for (int i=0; i < ListSize; i++)
            {
                classList.Add(new PointClass());
            }

            int result = 0;
			for (int i = 0; i < ListSize; i++) 
			{
				var point = classList[i];
                result += point.X;
                result += point.Y;
			}
		}

	}
}