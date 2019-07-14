using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge
{
    public interface IPosition
    {
        int CoorX { get; set; }
        int CoorY { get; set; }

        bool SamePosition(IPosition position);
    }
}
