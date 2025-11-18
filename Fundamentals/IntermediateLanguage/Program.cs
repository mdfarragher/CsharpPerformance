using System;

namespace Intermediate_language
{
	class MainClass
	{
		public static void ExampleOne()
		{
            // simple demo
            int i = 456;
            i = i + 1;
		}

		public static void ExampleTwo()
		{
			// calculate powers of two
			int number = 2;
			for (int i = 0; i < 16; i++)
			{
				number = number * 2;
			}
		}

		public static void Main (string[] args)
		{
			ExampleOne();
			ExampleTwo();
		}
	}
}