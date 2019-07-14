using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge;
using static Utilities.Utils;

namespace TurtleChallengeTest
{
    public class TurtleTestCaseSource
    {

        const int boardHeigth = 3;
        const int boardWidth = 4;
        static ICollection<Position> minesList = new List<Position>();
        static StartPosition startPosition = new StartPosition(0, 2, Direction.N);
        static EndPosition endPosition = new EndPosition(3, 0);
        static ICollection<Moves> movesList = new List<Moves>();
        private static void SetupMinePos(Position pos)
        {
            minesList.Add(pos);
        }

        public static IEnumerable TestCaseExitPosition
        {
            get
            {
                yield return new TestCaseData(new TurtleGame( new StartPosition(0, 2, Direction.N), new Position(0,2), boardHeigth, boardWidth, new List<Position>(), movesList));
                yield return new TestCaseData(new StartPosition(0, 1, Direction.N), new Position(0, 1), boardHeigth, boardWidth, new List<Position>(), movesList);
                yield return new TestCaseData(new StartPosition(0, 0, Direction.N), new Position(0, 0), boardHeigth, boardWidth, new List<Position>(), movesList);
                yield return new TestCaseData(new StartPosition(2, 1, Direction.N), new Position(2, 1), boardHeigth, boardWidth, new List<Position>(), movesList);
            }
        }

        public static IEnumerable TestCaseMineHit 
        {
            get
            {
                SetupMinePos(new Position(0, 2));
                yield return new TestCaseData(new StartPosition(0, 2, Direction.N), endPosition, boardHeigth,boardWidth, minesList, movesList);
                SetupMinePos(new Position(0, 1));
                yield return new TestCaseData(new StartPosition(0, 1, Direction.N), endPosition, boardHeigth, boardWidth, minesList, movesList);
                SetupMinePos(new Position(0, 0));
                yield return new TestCaseData(new StartPosition(0, 0, Direction.N), endPosition, boardHeigth, boardWidth, minesList, movesList);
                SetupMinePos(new Position(2, 1));
                yield return new TestCaseData(new StartPosition(2, 1, Direction.N), endPosition, boardHeigth, boardWidth, minesList, movesList);
            }
        }
        //public IEnumerable<TestCaseData> TestEvaluatePosition
        //{
        //    get
        //    {
        //        //Setup();
        //        yield return new TestCaseData(new TurtleGame(startPosition, endPosition, boardHeigth, boardWidth, minesList, movesList));
        //    }
        //}
    }
}
