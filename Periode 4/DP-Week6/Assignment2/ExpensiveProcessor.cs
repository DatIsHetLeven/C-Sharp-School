using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class ExpensiveProcessor : IProcessor
    {
        public void PerformOperation()
        {
            Console.WriteLine("performing operation very quickly...");
        }
    }
}
