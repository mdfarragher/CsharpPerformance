using System;
using System.Runtime.Caching;

using BenchmarkDotNet.Attributes;

namespace Caching
{
    [CsvMeasurementsExporter]
    [RPlotExporter]
	public class Benchmarks
	{
        public int TotalToCalculate = 40;

        public MemoryCache? cache = null;

        public int UncachedFibonacci(int n)
        {
            return n < 2 ? n : UncachedFibonacci(n - 1) + UncachedFibonacci(n - 2);
        }

        public int CachedFibonacci(int n)
        {
            if (cache == null)
                throw new NullReferenceException("Cache cannot be null");
            var cacheKey = "Fibonacci:" + n.ToString();
            var cached = cache[cacheKey];
            if (cached != null && cached is int)
                return (int)cached;
            else
            {
                var result = n < 2 ? n : CachedFibonacci(n - 1) + CachedFibonacci(n - 2);
                cache[cacheKey] = result;
                return result;
            }
        }

        [GlobalSetup]
        public void Setup()
        {
            cache = new MemoryCache("MyCache");
        }

        [Benchmark()]
		public void UseUncachedCode()
		{
            for (int j = 0; j < TotalToCalculate; j++)
            {
                var result = UncachedFibonacci(j);
            }
		}

        [Benchmark()]
		public void UseCachedCode()
		{
            for (int j = 0; j < TotalToCalculate; j++)
            {
                var result = CachedFibonacci(j);
            }
		}

	}
}