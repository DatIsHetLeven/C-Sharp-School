using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class CorrectPinState : IATMState
    {
        private ATMMachine machine;
        public CorrectPinState(ATMMachine machine)
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
            Console.WriteLine();
        }
        public void EnterPincode(int pincode)
        {
            Console.WriteLine("You have entered the correct pincode.");
            Console.WriteLine();
        }
        public void WithdrawCash(int amount)
        {
            machine.AmountInMachine -= amount;
            if (machine.AmountInMachine<=0)
            {
                Console.WriteLine("Not enough cash available in machine.");
                //when no money exists in the atm it changes state to no cash
                machine.SetMachineState(machine.GetNoCashState());
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("{0} withdrawn from machine.", amount);
                //when money has been withdrawed the state changes to no card
                machine.SetMachineState(machine.GetNoCardState());
                Console.WriteLine();
            }
            //whether withdraw has been successful or not card gets rejected, like in the example
            RejectCard();
        }
    }
}
