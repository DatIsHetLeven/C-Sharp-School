using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    class Dice
    {
        public int value;
        static Random rnd = new Random();

        public void Throw()
        {
            value = rnd.Next(6) + 1;
        }

        public void DisplayValue()
        {
            Console.Write(value+" ");
        }
    }
}
