using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class NoCardState : IATMState
    {
        private ATMMachine machine;
        public NoCardState(ATMMachine machine)
        {
            this.machine = machine;
        }
        public void InsertCard()
        {
            Console.WriteLine("Please enter your pincode");
            machine.SetMachineState(machine.GetCardPresentState());
            Console.WriteLine();
        }
        public void RejectCard()
        {
            Console.WriteLine("Your card has been rejected");
            Console.WriteLine();

        }
        public void EnterPincode(int pincode)
        {
            Console.WriteLine("You have entered the correct pincode.");
            Console.WriteLine();
        }
        public void WithdrawCash(int amount)
        {            
            Console.WriteLine("{0} withdrawn from machine.", amount);
            Console.WriteLine();
        }
    }
}
