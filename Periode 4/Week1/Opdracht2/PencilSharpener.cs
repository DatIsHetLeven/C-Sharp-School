using System;
using System.Collections.Generic;
using System.Text;

namespace Opdracht2
{
    class PencilSharpener : IPencilSharpener
    {
        public void Sharpen(IPencil pencil)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("sharpening the pencil...");
            Console.ResetColor();
            pencil.AfterSharpening();
        }
    }
}
