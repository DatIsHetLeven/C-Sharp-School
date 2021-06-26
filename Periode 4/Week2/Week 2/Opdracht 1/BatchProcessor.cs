using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1 {
    class BatchProcessor {
        List<BigDataLoader> processes = new List<BigDataLoader>();

        public void add(BigDataLoader process) {
            processes.Add(process);
        }

        public void execute() {
            foreach (BigDataLoader process in processes) {
                process.execute();
            }
        }
    }
}
