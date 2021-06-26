using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class LowBudgetShop : ComputerShop
    {
        public override IHardDisk MakeHardDisk()
        {            
            return new CheapHardDisk();
        }
        public override IMonitor MakeMonitor()
        {
            return new CheapMonitor();
        }
        public override IProcessor MakeProcessor()
        {
            return new CheapProcessor();
        }
    }
}
