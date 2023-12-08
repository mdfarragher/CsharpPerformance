using System;

namespace Dispose
{
    public static class MainClass
    {
		// ==============================================================================
		// Fix  this class so that the WorkObject uses the Dispose pattern
		// ==============================================================================

        public static int Lifetime = 0;

        public static int TotalFinalized = 0;

        public static int ObjectsToCreate = 1_000_000;

        public static void Main(string[] args)
        {
            Console.WriteLine($"Creating {ObjectsToCreate} worker objects...");
            for (int i = 0; i < ObjectsToCreate; i++)
            {
                var obj = new WorkObject();
                obj.DoWork();
            }

	    	// ==============================================================================
            // ^^^ Fix the above code by using the Dispose pattern
    		// ==============================================================================

            Console.WriteLine("Waiting for objects to finalize...");
            Thread.Sleep(1000);

            double avgLifetime = 1.0 * Lifetime / TotalFinalized;
            Console.WriteLine($"{TotalFinalized} objects finalized");
            Console.WriteLine($"On average, an object was alive for {avgLifetime} milliseconds");

	    	// ==============================================================================
            // ^^^ Ensure that the average lifetime per object is reduced significantly
    		// ==============================================================================
        }
    }
}