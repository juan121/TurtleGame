using System;
using System.Collections.Generic;
using System.Text;
using static Utilities.Utils;

namespace TurtleChallenge
{
    public interface IFullPosition:IPosition
    {
        Direction DirectionProp { get; set; }
    }
}
