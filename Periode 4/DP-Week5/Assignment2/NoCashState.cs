using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class NoCashState : IATMState
    {
        private ATMMachine machine;
        public NoCashState(ATMMachine machine)
        {
            this.machine = machine;
        }
        public void InsertCard()
        {
            Console.WriteLine("Please enter your pincode");
            Console.WriteLine();
        }
        public void RejectCard()
        {
            Console.WriteLine("Your card has been rejected");
            machine.SetMachineState(machine.GetNoCardState());
            Console.WriteLine();
        }
        public void EnterPincode(int pincode)
        {
            Console.WriteLine("You have entered the correct pincode.");
            Console.WriteLine();
        }
        public void WithdrawCash(int amount)
        {
            Console.WriteLine("Not enough cash available in machine.");
            Console.WriteLine();
        }
    }
}
