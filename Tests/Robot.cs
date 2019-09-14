using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simulator;

namespace Tests
{
    [TestClass]
    public class Robot
    {
        [TestMethod]
        public void TestCreate()
        {
            var o = new Simulator.Robot();
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void TestNewRobotHasNoDirection()
        {
            var o = new Simulator.Robot();
            Assert.AreEqual(o.Face, Direction.NONE);
        }
    }
}
