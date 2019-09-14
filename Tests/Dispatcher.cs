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
            var o = new Simulator.Dispatcher(Substitute.For<IParser>(), Substitute.For<IExecutor>());
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void TestMainLoopFinishOnEmptyCommandWithoutCallingParser()
        {
            var parser = Substitute.For<IParser>();
            var o = new Simulator.Dispatcher(parser, Substitute.For<IExecutor>());
            o.ReadLine = () => string.Empty;
            o.MainLoop();
            parser.DidNotReceive().Parse(Arg.Any<string>());
        }

        [TestMethod]
        public void TestMainLoopCallsParserAndExits()
        {
            var parser = Substitute.For<IParser>();
            var o = new Simulator.Dispatcher(parser, Substitute.For<IExecutor>());
            var commands = new[] {"LEFT", ""};
            var i = 0;
            o.ReadLine = () => commands[i++];
            o.MainLoop();
            parser.Received(1).Parse("LEFT");
        }

        [TestMethod]
        public void TestProcessCallsExecutorWithParametersForPlace()
        {
            var executor = Substitute.For<IExecutor>();

            var parser = Substitute.For<IParser>();
            parser.Parse("PLACE 0,0,NORTH").Returns(CommandType.PLACE);
            parser.XResult.Returns(0);
            parser.YResult.Returns(0);
            parser.DResult.Returns(Direction.NORTH);

            var o = new Simulator.Dispatcher(parser,executor);

            o.Process("PLACE 0,0,NORTH");

            executor.Received(1).Execute(CommandType.PLACE,0,0,Direction.NORTH);
        }
    }
}
