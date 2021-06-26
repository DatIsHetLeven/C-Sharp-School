using System;

namespace Assignment2
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
            ATMMachine machine = new ATMMachine(2000);

            machine.InsertCard();
            machine.RejectCard();

            machine.InsertCard();
            machine.EnterPincode(1234);
            machine.WithdrawCash(1500);

            machine.InsertCard();
            machine.EnterPincode(1234);
            machine.WithdrawCash(750);

            Console.ReadKey();
        }
    }    
}
