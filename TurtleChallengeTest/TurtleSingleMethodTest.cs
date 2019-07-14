using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
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
        [Description("Evaluate if position given is correct based on data"), Test]
        //[TestCase(new Dictionary<bool, Result>() { false, Result.MineHit })]
        public void TestCheckIfStartPositionIsEqualToEndPosition()
        {
            Assert.Pass();
        }

    }
}
