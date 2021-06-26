using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1 {
    public abstract class BigDataLoader {
        public void execute() {
            showStatusMessage("ELT-proces started");

            extract();
            transform();
            load();

            showStatusMessage("ELT-proces finished");
            Console.WriteLine();
        }

        private void showStatusMessage(string message) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[{message}]");
            Console.ResetColor();
        }

        protected abstract void extract();
        protected abstract void transform();
        protected abstract void load();
    }
}
