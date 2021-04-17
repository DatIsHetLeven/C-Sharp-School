using System;

namespace Assignement0
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            int value = ReadInt("Enter a value: ");
            Console.WriteLine("You entered {0}.", value);
            int age = ReadInt("How old are you? ", 0, 120);
            Console.WriteLine("You are {0} years old.", age);
            string name = ReadString("What is your name? ");
            Console.WriteLine("Nice meeting you {0}.", name);
            Console.ReadKey();
        }

         int ReadInt(string question)
        {
            Console.WriteLine(question);
            string val = Console.ReadLine();
            return Int32.Parse(val);
        }

        int ReadInt(string question, int min, int max)
        {
            Boolean ask = true;
            int val = -1;
            while (ask)
            {
                val = ReadInt(question);
                if(val>min && val<max)
                {
                    ask = false;
                }
                else
                {
                    continue;
                }
            }
            return val;
        }

        string ReadString(string question)
        {
            Console.WriteLine(question);
            string val = Console.ReadLine();
            return val;
        }

        
    }
}
