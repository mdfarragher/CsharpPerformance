using System;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace ObjectPool
{
	public class MainClass
	{
        public static int BufferAllocations = 0;

		public static void Main (string[] args)
		{
            // run unoptimized code
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine($"Running unoptimized code...");
            var b = new Benchmarks();
            b.Unoptimized();
            stopwatch.Stop();
            Console.WriteLine($"Allocated {BufferAllocations} buffers in {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine();

            // run optimized code
            stopwatch.Reset();
            stopwatch.Start();
            Console.WriteLine($"Running optimized code...");
            BufferAllocations = 0;
            b.Optimized();
            stopwatch.Stop();
            Console.WriteLine($"Allocated {BufferAllocations} buffers in {stopwatch.ElapsedMilliseconds} ms");
		}
	}
}