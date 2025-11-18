using System;

using BenchmarkDotNet.Attributes;

namespace Arrays
{
	public class Benchmarks
	{
        [Params(5000)]
        public int ArraySize;

        int[]? list1;
        int[,]? list2;
        int[][]? listj;

        [GlobalSetup]
        public void Setup()
        {
			list1 = new int[ArraySize * ArraySize];
			list2 = new int[ArraySize, ArraySize];
			listj = new int[ArraySize][];
			for (int i = 0; i < ArraySize; i++)
			{
				listj [i] = new int[ArraySize];
			}

        }

        [Benchmark]
		public void OneDimension ()
		{
            if (list1 == null)
                throw new NullReferenceException("list1 cannot be null");
			for (int i = 0; i < ArraySize * ArraySize; i++)
			{
				list1 [i] = i;
			}
		}

        [Benchmark]
		public void TwoDimensions ()
		{
            if (list2 == null)
                throw new NullReferenceException("list2 cannot be null");
			for (int i = 0; i < ArraySize; i++)
			{
				for (int j = 0; j < ArraySize; j++)
				{
					list2 [i, j] = i;
				}
			}
		}

        [Benchmark]
		public void Jagged ()
		{
            if (listj == null)
                throw new NullReferenceException("listj cannot be null");
			for (int i = 0; i < ArraySize; i++)
			{
				for (int j = 0; j < ArraySize; j++)
				{
					listj [i] [j] = i;
				}
			}
		}

        [Benchmark]
		public void Flattened() 
		{
            if (list1 == null)
                throw new NullReferenceException("list1 cannot be null");
            for (int i = 0; i < ArraySize; i++) 
            {
                for (int j = 0; j < ArraySize; j++) 
                {
                    int index = ArraySize * i + j;
                    list1 [index] = i;
                }
            }
        }

	}
}