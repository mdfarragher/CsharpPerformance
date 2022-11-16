using System;

namespace Finalization
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // create objects
            int counter = 0;
            Console.WriteLine("Creating objects...");
            while (!Console.KeyAvailable)
            { 
                var obj = new MyObject(counter++);

                // print progress
                if (counter % 10000 == 0)
                    Console.WriteLine($"{counter} objects created");
            }
        }
    }
}
