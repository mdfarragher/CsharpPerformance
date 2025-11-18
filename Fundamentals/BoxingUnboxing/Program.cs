using System;

namespace BoxingUnboxing
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			int a = 1234;
			int b = a;
			int c = (int)b;

			Console.WriteLine (c);
	
		}
	}
}