using System;

namespace Immutable_strings
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string a = "abc";
			string b = a;

			b += "d";

			// strings are reference types, so this should be true
            bool c = a.Equals(b);

            // write the result
            Console.WriteLine($"This should be true: {c}");
		}
	}
}

// We'll need this later
// Console.WriteLine($"Do a and b point to the same string on the heap? {object.ReferenceEquals(a, b)}");
