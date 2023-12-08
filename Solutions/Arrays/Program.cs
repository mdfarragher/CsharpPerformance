using System;
using BenchmarkDotNet.Running;

namespace Arrays
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
            // run  benchmarks
            BenchmarkRunner.Run<Benchmarks>();
		}
	}
}