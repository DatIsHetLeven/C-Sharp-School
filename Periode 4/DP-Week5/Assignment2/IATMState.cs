using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public interface IATMState
    {
        public void InsertCard();
        public void EnterPincode(int pincode);
        public void WithdrawCash(int amount);
        public void RejectCard();
    }
}
