using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class CheapProcessor : IProcessor
    {
        public void PerformOperation()
        {
            Console.WriteLine("performing operation not so quickly...");
        }
    }
}
