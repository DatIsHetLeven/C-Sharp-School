using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1 {
    class Program {
        static void Main(string[] args) {
            Program program = new Program();
            program.start();
        }

        void start() {
            BatchProcessor batch = new BatchProcessor();

            batch.add(new CallDataLoader());
            batch.add(new TwitterDataLoader());
            batch.add(new SensorDataLoader());

            batch.execute();

            Console.ReadKey();
        }
    }
}
