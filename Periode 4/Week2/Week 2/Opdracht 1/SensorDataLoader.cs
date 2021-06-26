using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1 {
    public class SensorDataLoader: BigDataLoader {
        protected override void extract() {
            Console.WriteLine("Extracting sensor data...");
        }

        protected override void transform() {
            Console.WriteLine("Transforming sensor data...");
        }

        protected override void load() {
            Console.WriteLine("Loading sensor data...");
        }
    }
}
