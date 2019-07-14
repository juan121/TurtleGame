using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Utilities.Utils;

namespace TurtleChallenge
{
    public class TurtleGame : ITurtleGame
    {
        private readonly IFullPosition _initialPosition;
        private readonly IPosition _finalPostion;
        private readonly int _boardHeigth;
        private readonly int _boardWidth;
        private readonly ICollection<Position> _minesList;
        private readonly ICollection<Moves> _movesList;

        //Private properties
        private IFullPosition _turtlePosition { get; set; }
        //Events
        public event EventHandler<MoveEventArgs> moveEvent;
        public event EventHandler<string> taskEvent;

        public TurtleGame(IFullPosition posIni, IPosition posEnd, int boardHeigth, int boardWidth, ICollection<Position> minesList, ICollection<Moves> movesList)
        {
            _initialPosition = posIni;
            _finalPostion = posEnd;
            _boardHeigth = boardHeigth;
            _boardWidth = boardWidth;
            _minesList = minesList;
            _movesList = movesList;
            _turtlePosition = _initialPosition;
        }

        public Result PlayGame()
        {
            var res = evaluatePosition();//We check the initial position first in case _moveList is empty
           
            foreach (var m in _movesList)
            {
                MovePosition(m);
                onMoveEvent(m);
                res = evaluatePosition();
                if (res.ContainsKey(false)) break;
            }

            if (res.ContainsKey(false))
            {
                return res[false];
            }
            else return res[true];
        }

        public Dictionary<bool, Result> evaluatePosition()
        {
            var result = new Dictionary<bool, Result>();

            if (EqualPositionAndMinesPositions())
            {
                result.Add(false, Result.MineHit);
            }
            else if (PostionOutOfBounds())
            {
                result.Add(false, Result.OutOfBounds);
            }
            else if (EqualCurrentPositionAndFinalPositions())
            {
                result.Add(true, Result.Success);
            }
            else result.Add(true, Result.StillInDanger);

            return result;
        }

        public void MovePosition(Moves m)
        {
            //var delay = Task.Delay(2000);
            //await delay.ContinueWith(_ => { onTaskEvent("TaskDelay Finished"); });

            var direction = _turtlePosition.DirectionProp;
            switch (m)
            {
                case Moves.m:
                    switch (direction)
                    {
                        case Direction.N:
                            _turtlePosition.CoorY -= 1;
                            break;
                        case Direction.S:
                            _turtlePosition.CoorY += 1;
                            break;
                        case Direction.E:
                            _turtlePosition.CoorX += 1;
                            break;
                        case Direction.W:
                            _turtlePosition.CoorX -= 1;
                            break;
                        default:
                            break;
                    }
                    break;
                case Moves.r:
                    switch (direction)
                    {
                        case Direction.N:
                            _turtlePosition.DirectionProp = Direction.E;
                            break;
                        case Direction.S:
                            _turtlePosition.DirectionProp = Direction.W;
                            break;
                        case Direction.E:
                            _turtlePosition.DirectionProp = Direction.S;
                            break;
                        case Direction.W:
                            _turtlePosition.DirectionProp = Direction.N;
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

        }

        #region Private Methods
        //public void onTaskEvent(string s)
        //{

        //    if (taskEvent != null)
        //    {
        //        taskEvent(this, s);
        //    }
        //}


        public void onMoveEvent(Moves m)
        {
            //Simulating a delay for the turtle while moving
            System.Threading.Thread.Sleep(1000);

            var delMove = moveEvent as EventHandler<MoveEventArgs>;
            if (delMove != null)
            {
                delMove(this, new MoveEventArgs() { move = m });
            }
        }


        #region Private
        private bool PostionOutOfBounds()
        {
            if (_turtlePosition.CoorX == -1 || _turtlePosition.CoorX >= _boardWidth) return true;

            if (_turtlePosition.CoorY == -1 || _turtlePosition.CoorY >= _boardHeigth) return true;

            return false;
        }

        private bool EqualCurrentPositionAndFinalPositions()
        {
            return _initialPosition.SamePosition(_finalPostion);
        }

        private bool EqualPositionAndMinesPositions()
        {
            var result = false;
            foreach (var pos in _minesList)
            {
                if (pos.SamePosition(_turtlePosition))
                {
                    result = true;
                    break;
                }
            }

            return result;
        }
        #endregion

        #endregion
    }
}
