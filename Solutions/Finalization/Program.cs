using System;

namespace Finalization
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            // create objects
            int counter = 0;
            while (counter < 100000)
            { 
                var obj = new MyObject(counter++);
            }
        }
    }
}
