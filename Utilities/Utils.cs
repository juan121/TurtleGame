using System;
using System.ComponentModel;

namespace Utilities
{
    public static class Utils
    {
        public enum Result
        {
            [Description("Well done Turtle, you've reached the exit!")]
            Success = 0,
            [Description("Ohhh, you were blasted! Next time be more careful with mines.")]
            MineHit,
            [Description("I guess it is what it is, you are still on the board, what's next? Reset the game and play!")]
            StillInDanger,
            [Description("Where are you going?? You've got yourself out of the board. Take it easy.")]
            OutOfBounds
        }

        public enum Moves
        {
            [Description("Move Forward")]
            m = 0,
            [Description("Rotation 90 degrees right")]
            r,
        }

        public enum Direction
        {
            N = 0,
            E,
            S,
            W
        }

    }
}
