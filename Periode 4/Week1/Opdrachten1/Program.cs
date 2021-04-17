using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdrachten1
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
            IStack myStack = new ArrayStack(50);

            AddValues(myStack);
            Console.WriteLine();

            CheckValues(myStack);
            Console.WriteLine();

            ProcessValues(myStack);

            Console.ReadKey();
        }
        void AddValues(IStack stack)
        {
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                int value = rnd.Next(1, 100);
                stack.push(value);
                Console.WriteLine($"*pushed {value,2}, new count: { stack.count}");
            }
        }
        void CheckValues(IStack stack)
        {
            Random random = new Random();
            int checkValue = random.Next(100);
            bool contains = stack.contains(checkValue);

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter a number:");
                int number = int.Parse(Console.ReadLine());
                bool contains2 = stack.contains(number);
                Console.WriteLine($"Stack {(contains2 ? "contains" : "does not contain")} value {number}");
            }

        }
        void ProcessValues(IStack stack)
        {
            while (!stack.isEmpty)
            {
                int value = stack.pop();
                Console.WriteLine($"*popped {value}, new count: {stack.count}");
            }
        }
    }
}
