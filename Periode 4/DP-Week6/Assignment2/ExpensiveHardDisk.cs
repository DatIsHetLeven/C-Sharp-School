using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class ExpensiveHardDisk : IHardDisk
    {
        public void StoreData()
        {
            Console.WriteLine("storing data very quickly...");
        }
    }
}
