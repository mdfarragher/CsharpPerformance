using System;

using BenchmarkDotNet.Attributes;

namespace Pointers
{
	public class Benchmarks
	{
        [Params(4096)]
        public int ArraySize;

        [Benchmark]
		public void UseArray ()
		{
			byte[] image = new byte[ArraySize * ArraySize * 3];
			for (int i = 0; i < image.Length;)
			{
				byte grey = (byte)(.299 * image [i + 2] + .587 * image [i + 1] + .114 * image [i]);
				image [i] = grey;
				image [i + 1] = grey;
				image [i + 2] = grey;
				i += 3;
			}
		}

        [Benchmark]
		public void UsePointerIndex ()
		{
			byte[] image = new byte[ArraySize * ArraySize * 3];
			unsafe
			{
				fixed (byte* p = &image[0])
				{
					for (int i = 0; i < image.Length;)
					{
						byte grey = (byte)(.299 * p [i + 2] + .587 * p [i + 1] + .114 * p [i]);
						p [i] = grey;
						p [i + 1] = grey;
						p [i + 2] = grey;
						i += 3;
					}
				}
			}
		}

        [Benchmark]
		public void UsePointer ()
		{
			byte[] image = new byte[ArraySize * ArraySize * 3];
			unsafe
			{
				fixed (byte* imgPtr = &image[0])
				{
					byte* p = imgPtr;
					int stopAddress = (int)p + ArraySize * ArraySize * 3;
					while ((int)p != stopAddress)
					{
                        var pRed = p;
                        p++;
                        var pGreen = p;
                        p++;
                        var pBlue = p;
						byte grey = (byte)(.299 * (*pBlue) + .587 * (*pGreen) + .114 * (*pRed));
						*pRed = grey;
						*pGreen = grey;
						*pBlue = grey;
						p++;
					}
				}
			}
		}

	}
}