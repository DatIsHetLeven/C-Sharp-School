using System;

namespace Assignment1
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
            Program p = new Program();
            p.PrintMonths();
            string question = "-1";
            p.PrintMonth(p.ReadMonth(question));
            Console.ReadKey();
        }

        void PrintMonth(Month month)
        {
            Console.Out.WriteLine(month);
        }

        void PrintMonths()
        {
            for (int i = 1; i <= 12 ; i++)
                Console.Out.WriteLine(String.Format("{0,3}", i.ToString())+". "+(Month)i);
        }

        Month ReadMonth(string question)
        {
            while(!(Enum.IsDefined(typeof(Month), (Month)Int32.Parse(question))))
            {
                Console.Out.Write("Enter a month number: ");
                question = Console.ReadLine();
                if (Enum.IsDefined(typeof(Month), (Month)Int32.Parse(question)))
                {
                    Console.Out.Write(Int32.Parse(question)+" => ");
                    return (Month)Int32.Parse(question);
                }
                Console.Out.WriteLine(question+"is not a valid value.");
            }
            return (Month)Int32.Parse(question);
        }
    }
}
