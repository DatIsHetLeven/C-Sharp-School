using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment2
{
    public abstract class ComputerFactory
    {
        public abstract IHardDisk MakeHardDisk();
        public virtual IMonitor MakeMonitor() { return new CheapMonitor(); }
        public virtual IProcessor MakeProcessor() { return new CheapProcessor(); }
    }
}
