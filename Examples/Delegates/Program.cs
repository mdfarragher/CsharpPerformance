﻿using System;
using BenchmarkDotNet.Running;

namespace Delegates
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