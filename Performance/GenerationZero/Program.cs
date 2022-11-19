using System;

namespace GenerationZero
{
	public class MainClass
	{
        public static int NumberOfStrings = 0;

        public static int NumberOfConversions = 1000;

		public static void Main (string[] args)
		{
            string s = "The quick brown fox jumped over the lazy dog";
            var converter = new Piglatinifier();
            string? result = null;

            // convert string a couple of times
            for (int i = 0; i < NumberOfConversions; i++) 
                result = converter.Convert(s);

            // return results
            Console.WriteLine(result);
            Console.WriteLine($"Your code created {NumberOfStrings} short-lived strings in heap gen:0");
		}
	}
}