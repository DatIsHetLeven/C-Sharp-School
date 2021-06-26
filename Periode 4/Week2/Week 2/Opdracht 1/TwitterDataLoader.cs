using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1 {
    public class TwitterDataLoader: BigDataLoader {
        protected override void extract() {
            Console.WriteLine("Extracting Twitter data...");
        }

        protected override void transform() {
            Console.WriteLine("Transforming Twitter data...");
        }

        protected override void load() {
            Console.WriteLine("Loading Twitter data...");
        }
    }
}
