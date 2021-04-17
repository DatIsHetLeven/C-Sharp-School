using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht2
{
    class Pencil : IPencil
    {
        private int maxToWrite; // number of characters to write with a sharpened pencil
        private int nrOfCharsWritten; // number of written characters
        public Pencil(int number)
        {
            this.maxToWrite = number;
        }
        
        public bool CanWrite { get; }

        public void AfterSharpening()
        {
            nrOfCharsWritten = 0;
        }

        public void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var i in message)
            {
                if (nrOfCharsWritten < maxToWrite)
                {
                    Console.Write(i);
                }
                else
                {
                    Console.Write("#");
                }
                nrOfCharsWritten++;
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
