using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TurtleChallenge;
using static Utilities.Utils;

namespace TurtleChallengeTest
{
    public class TurtleSingleMethodTest
    {
        [SetUp]
        public void Setup()
        { 
        }

        [Category("SingleMethod")]
        [Description("Evaluate if the result is exit."), Test]
        //[TestCase(nameof(TestEvaluatePosition))]
        [TestCaseSource(typeof(TurtleTestCaseSource), "TestCaseExitPosition")]
        public void BatteryTestEvaluatePositionSuccess(ITurtleGame turtleGame)
        {
            var res = turtleGame.evaluatePosition();

            Assert.IsTrue(res.ContainsKey(true));
            Assert.AreEqual(res[true], Result.Success);
        }

        [Category("SingleMethod")]
        [Description("Evaluate if the result is MineHit"), Test]
        //[TestCase(nameof(TestEvaluatePosition))]
        [TestCaseSource(typeof(TurtleTestCaseSource), "TestCaseMineHit")]
        public void BatteryTestEvaluatePositionMineHit(IFullPosition posIni, IPosition posEnd, int boardHeigth, int boardWidth, ICollection<Position> minesList, ICollection<Moves> movesList)
        {
            var turtle = new TurtleGame( posIni,  posEnd,  boardHeigth,  boardWidth, minesList,  movesList);

            var res = turtle.evaluatePosition();

            Assert.IsTrue(res.ContainsKey(false));
            Assert.AreEqual(res[false], Result.MineHit);
        }

    }
}
