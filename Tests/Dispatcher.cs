using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core.Arguments;
using Simulator;

namespace Tests
{
    [TestClass]
    public class Dispatcher
    {
        [TestMethod]
        public void TestCreate()
        {
            var o = new Simulator.Dispatcher(Substitute.For<ICommandParser>(), Substitute.For<IExecutor>());
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void TestMainLoopFinishOnEmptyCommandWithoutCallingParser()
        {
            var parser = Substitute.For<ICommandParser>();
            var o = new Simulator.Dispatcher(parser, Substitute.For<IExecutor>());
            o.ReadLine = () => string.Empty;
            o.MainLoop();
            parser.DidNotReceive().Parse(Arg.Any<string>());
        }

        [TestMethod]
        public void TestMainLoopCallsParserAndExits()
        {
            var parser = Substitute.For<ICommandParser>();
            var o = new Simulator.Dispatcher(parser, Substitute.For<IExecutor>());
            var commands = new[] {"LEFT", ""};
            var i = 0;
            o.ReadLine = () => commands[i++];
            o.MainLoop();
            parser.Received().Parse("LEFT");
        }


    }
}
