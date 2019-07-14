using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Utils;

namespace TurtleChallenge
{
    public interface ITurtleGame
    {
        Result PlayGame();
        //bool PositionValid();
        void MovePosition(Moves m);

        void onMoveEvent(Moves m);

        Dictionary<bool, Result> evaluatePosition();
    }
}
