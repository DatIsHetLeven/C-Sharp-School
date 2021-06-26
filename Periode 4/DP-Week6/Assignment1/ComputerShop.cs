using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class ComputerShop
    {
        public void AssembleMachine()
        {
            IHardDisk hardDisk = MakeHardDisk();
            IMonitor monitor = MakeMonitor();
            IProcessor processor = MakeProcessor();
            processor.PerformOperation();
            hardDisk.StoreData();
            monitor.Display();
        }
        public virtual IHardDisk MakeHardDisk() { return new CheapHardDisk(); }
        public virtual IMonitor MakeMonitor() { return new CheapMonitor(); }
        public virtual IProcessor MakeProcessor() { return new CheapProcessor(); }        
    }
}
