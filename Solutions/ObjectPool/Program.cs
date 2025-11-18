using System;
using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace ObjectPool
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