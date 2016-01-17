using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntsSimulator
{
    public class WorldBounds
    {
        public int XBound { get; private set; }
        public int YBound { get; private set; }

        public WorldBounds(int xBound, int yBound)
        {
            XBound = xBound;
            YBound = yBound;
        }
    }
}
