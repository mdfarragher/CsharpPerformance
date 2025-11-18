using System;

namespace Immutable_strings
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string a = "abc";
			string b = a;

			Console.WriteLine("Before assignment:");

			Console.WriteLine($"Do a and b point to the same string on the heap? {object.ReferenceEquals(a, b)}");
            Console.WriteLine($"Are a and b equal? {a.Equals(b)}");

			b += "d";

			Console.WriteLine("After assignment:");

			Console.WriteLine($"Do a and b point to the same string on the heap? {object.ReferenceEquals(a, b)}");
            Console.WriteLine($"Are a and b equal? {a.Equals(b)}");
		}
	}
}
