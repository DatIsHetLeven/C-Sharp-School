using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myprogram = new Program();
            myprogram.Start();
        }
        void Start()
        {
            //creating high budget shop
            Console.WriteLine("[shop creating expensive computers]");
            ComputerShop highBudgetShop = new HighBudgetShop();
            highBudgetShop.AssembleMachine();

            Console.WriteLine();

            //creating low budget shop
            Console.WriteLine("[shop creating cheap computers]");
            ComputerShop lowbudgetShop = new LowBudgetShop();
            lowbudgetShop.AssembleMachine();

            Console.ReadKey();
        }
    }
}
