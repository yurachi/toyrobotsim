using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Simulator;

namespace Tests
{
    [TestClass]
    public class Dispatcher
    {
        [TestMethod]
        public void TestCreate()
        {
            var o = new Simulator.Dispatcher(Substitute.For<IRobot>(), Substitute.For<ICommandParser>());
            Assert.IsNotNull(o);
        }
    }
}
