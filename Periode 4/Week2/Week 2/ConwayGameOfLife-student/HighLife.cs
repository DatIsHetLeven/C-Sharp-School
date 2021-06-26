using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife {
    public class HighLife: ConwayGameOfLife {
        protected override bool CellShouldLive(bool livingCell, int neighbourCount) {
            // with 2 or 3 neighbours will die
            if (livingCell && (neighbourCount == 2 || neighbourCount == 3))
                return true;

            // born with 3 or 6
            if (!livingCell && (neighbourCount == 3 || neighbourCount == 6))
                return true;

            // dead cell
            return false;
        }
    }
}
