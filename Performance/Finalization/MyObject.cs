using System;

namespace Finalization
{
    public class MyObject
    {
        public int Counter { get; set; }

        // object constructor
        public MyObject(int counter)
        {
            Counter = counter;
            Console.WriteLine($"Constructed object {Counter} in generation {GC.GetGeneration(this)}");
        }

        // object finalizer
        ~MyObject()
        {
            Console.WriteLine($"Finalized object {Counter} in generation {GC.GetGeneration(this)}");
        }
        
    }
}