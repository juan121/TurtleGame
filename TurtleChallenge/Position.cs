using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge
{
    public class Position:IPosition
    {
        public int CoorX { get; set; }
        public int CoorY { get; set; }

        public Position(int x, int y)
        {
            CoorX = x;
            CoorY = y;
        }

        public bool SamePosition(IPosition position)
        {
            if (this.CoorX == position.CoorX && this.CoorY == position.CoorY) return true;
            else return false;
        }


    }
}
