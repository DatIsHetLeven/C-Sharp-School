using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public class ComputerShop
    {
        public void AssembleMachine(ComputerFactory factory) 
        {
            IHardDisk hardDisk = factory.MakeHardDisk();
            IProcessor processor = factory.MakeProcessor();
            IMonitor monitor = factory.MakeMonitor();

            processor.PerformOperation();
            hardDisk.StoreData();
            monitor.Display();
        }
    }
}
