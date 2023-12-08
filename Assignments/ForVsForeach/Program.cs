﻿using System;
using BenchmarkDotNet.Running;

namespace ForVsForeach
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