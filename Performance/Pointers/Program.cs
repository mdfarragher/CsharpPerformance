using System;
using BenchmarkDotNet.Running;

namespace Pointers
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
            // run benchmarks
            BenchmarkRunner.Run<Benchmarks>();
		}
	}
}