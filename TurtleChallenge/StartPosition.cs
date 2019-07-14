using System;
using System.Collections.Generic;
using System.Text;
using static Utilities.Utils;

namespace TurtleChallenge
{
    //Multiple inheritance and different types of them, from a class and from an interface. You can see here clearly the difference 
    //between both, where Interface define a squeleton or structure while the baseclass provides more than that, a basic functionality
    public class StartPosition : Position, IFullPosition
    {
        public Direction DirectionProp { get; set; }
        public StartPosition(int x, int y, Direction direction):base(x, y)
        {
            DirectionProp = direction;
        }
    }
}