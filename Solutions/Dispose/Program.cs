using System;

namespace Dispose
{
    public static class MainClass
    {
        public static int Lifetime = 0;

        public static int TotalFinalized = 0;

        public static int ObjectsToCreate = 1_000_000;

        public static void Main(string[] args)
        {
            Console.WriteLine("Create [1] nondisposable or [2] disposable objects?");
            var input = Console.ReadLine();

            if (input == "1")
            {
                Console.WriteLine($"Creating {ObjectsToCreate} worker objects...");
                for (int i = 0; i < ObjectsToCreate; i++)
                {
                    var obj = new ObjectWithoutDispose();
                    obj.DoWork();
                }
            }
            else if (input == "2")
            {
                Console.WriteLine($"Creating {ObjectsToCreate} disposable worker objects...");
                for (int i = 0; i < ObjectsToCreate; i++)
                {
                    using (var obj = new ObjectWithDispose())
                    {
                        obj.DoWork();
                    }
                }
            }

            Console.WriteLine("Waiting for objects to finalize...");
            Thread.Sleep(1000);

            double avgLifetime = 1.0 * Lifetime / TotalFinalized;
            Console.WriteLine($"{TotalFinalized} objects finalized");
            Console.WriteLine($"On average, an object was alive for {avgLifetime} milliseconds");
        }
    }
}