using System;

namespace Opdracht2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
            Console.ReadKey();
        }

        void Start()
        {
            IPencil pencil = new Pencil(20);

            check(pencil);
        }

        void check(IPencil pencil)
        {
            PencilSharpener pencilSharpener = new PencilSharpener();
            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter a word: ");
                string inputUser = Console.ReadLine();

                if (inputUser == "stop")
                {
                    Console.WriteLine("End of program");
                    return;
                }
                else if (inputUser == "sharpen")
                {
                    pencilSharpener.Sharpen(pencil);   
                }
                else
                {
                    pencil.Write(inputUser);
                }
            }
        }
    }
}
