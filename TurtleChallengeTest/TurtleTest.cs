using NUnit.Framework;
using System;
using System.Collections.Generic;
using TurtleChallenge;
using static Utilities.Utils;

namespace Tests
{
    //TDD. Tests implementation before executing the code
    public class TurtleTest
    {
        private ITurtleGame _turtleGame;
        const int boardHeigth = 3;
        const int boardWidth = 4;
        [SetUp]
        public void Setup()
        {
        }

        [Category("General outcome testing")]
        [Description("Check if the start position is equal to the end position."), Test]
        public void TestCheckIfStartPositionIsEqualToEndPosition()
        {
            ICollection<Position> minesList = new List<Position>();

            var startPosition = new StartPosition(3, 0, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();

            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.Success, _turtleGame.PlayGame());
        }

        [Description("Check if the start position is equal to any of the mines position."), Test]
        [Category("General outcome testing")]
        public void TestCheckIfStartPositionIsEqualToMinesPosition()
        {
            ICollection<Position> minesList = new List<Position>();
            minesList.Add(new Position(0, 2));

            var startPosition = new StartPosition(0, 2, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();
            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.MineHit, _turtleGame.PlayGame());
        }

        [Description("Check if the turtle is out of the bonds."), Test]
        [Category("General outcome testing")]
        public void TestCheckIfStartPositionOutOfBonds()
        {
            ICollection<Position> minesList = new List<Position>();

            minesList.Add(new Position(1, 1));
            var startPosition = new StartPosition(0, 5, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();
            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.OutOfBounds, _turtleGame.PlayGame());
        }

        [Description("Check if the result is success with a list of moves to be successful without mines"), Test]
        [Category("General outcome testing")]
        public void TestFinishSuccessfullWihtoutMines()
        {
            ICollection<Position> minesList = new List<Position>();

            var startPosition = new StartPosition(0, 2, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);
            movesList.Add(Moves.r);
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);
            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.Success,_turtleGame.PlayGame());
        }

        [Description("Check if the result is success with a list of moves to be successful with mines"), Test]
        [Category("General outcome testing")]
        public void TestFinishSuccessfullWithMines()
        {
            ICollection<Position> minesList = new List<Position>();

            minesList.Add(new Position(1, 1));
            var startPosition = new StartPosition(0, 2, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);
            movesList.Add(Moves.r);
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);
            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.Success, _turtleGame.PlayGame());
        }

        [Description("Check if the result is still in Danger"), Test]
        [Category("General outcome testing")]
        public void TestFinishStilInDanger()
        {
            ICollection<Position> minesList = new List<Position>();

            minesList.Add(new Position(1, 1));
            var startPosition = new StartPosition(0, 2, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);
            movesList.Add(Moves.r);
            movesList.Add(Moves.m);
            movesList.Add(Moves.m);

            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.StillInDanger, _turtleGame.PlayGame());
        }

        [Description("Check if the result is Out Of Bounds"), Test]
        [Category("General outcome testing")]
        public void TestFinishOutOfBounds()
        {
            ICollection<Position> minesList = new List<Position>();

            minesList.Add(new Position(1, 1));
            var startPosition = new StartPosition(0, 2, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();
            movesList.Add(Moves.r);
            movesList.Add(Moves.r);
            movesList.Add(Moves.m);
            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.OutOfBounds, _turtleGame.PlayGame());
        }

        [Description("Check if the result is hitting a mine"), Test]
         [Category("General outcome testing")]
        public void TestFinishMineHit()
        {
            ICollection<Position> minesList = new List<Position>();

            minesList.Add(new Position(1, 1));
            var startPosition = new StartPosition(0, 2, Direction.N);
            var endPosition = new EndPosition(3, 0);

            //Reading File with moves
            ICollection<Moves> movesList = new List<Moves>();
            movesList.Add(Moves.m);
            movesList.Add(Moves.r);
            movesList.Add(Moves.m);
            _turtleGame = new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList);

            Assert.AreEqual(Result.MineHit, _turtleGame.PlayGame());
        }
    }
}