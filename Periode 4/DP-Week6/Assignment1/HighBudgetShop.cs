using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class HighBudgetShop : ComputerShop
    {
        public override IHardDisk MakeHardDisk()
        {
            return new ExpensiveHardDisk();
        }
        public override IMonitor MakeMonitor()
        {
            return new ExpensiveMonitor();
        }
        public override IProcessor MakeProcessor()
        {
            return new ExpensiveProcessor();
        }
    }
}
