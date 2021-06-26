using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1 {
    public class CallDataLoader:BigDataLoader {
        protected override void extract() {
            Console.WriteLine("Extracting call data...");
        }

        protected override void transform() {
            Console.WriteLine("Transforming call data...");
        }

        protected override void load() {
            Console.WriteLine("Loading call data...");
        }
    }
}
