using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class ATMMachine
    {
        private int amountInMachine;
        private IATMState cardPresent;
        private IATMState correctPinCode;
        private IATMState noCard;
        private IATMState noCash;
        private IATMState machineState;
        public int AmountInMachine { get { return amountInMachine; } set { amountInMachine = value; } }
        public ATMMachine(int amountInMachine)
        {
            this.amountInMachine = amountInMachine;
            cardPresent = new CardPresentState(this);
            correctPinCode = new CorrectPinState(this);
            noCard = new NoCardState(this);
            noCash = new NoCashState(this);

            //starts with no card state
            machineState = noCard;
        }
        public void EnterPincode(int pincode)
        {
            machineState.EnterPincode(pincode);
        }
        public IATMState GetCardPresentState()
        {
            return cardPresent;
        }
        public IATMState GetCorrectPinState()
        {
            return correctPinCode;
        }
        public IATMState GetNoCardState()
        {
            return noCard;
        }
        public IATMState GetNoCashState()
        {
            return noCash;
        }
        public void InsertCard()
        {
            machineState.InsertCard();
        }
        public void RejectCard()
        {
            machineState.RejectCard();
        }
        public void SetAmountInMachine(int amount)
        {
            AmountInMachine = amount;
        }
        public void SetMachineState(IATMState state)
        {
            machineState = state;
        }
        public void WithdrawCash(int amount)
        {
            machineState.WithdrawCash(amount);
        }
    }
}
