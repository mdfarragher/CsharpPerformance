using System;
using System.Text;

using BenchmarkDotNet.Attributes;

namespace StringVsStringBuilder
{
    public class Benchmarks
	{
		[Params(5000)]
        public int Additions;

        [Benchmark]
		public void AppendToString() 
		{
            string s = string.Empty;
            for (int j = 0; j < Additions; j++) 
            {
                s = s + "a";
            }
		}

        [Benchmark]
		public void AppendToStringBuilder() 
		{
            StringBuilder sb = new StringBuilder ();
            for (int j = 0; j < Additions; j++) 
            {
                sb.Append("a");
            }
		}
	}
}