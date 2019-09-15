using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Integration
    {
        [TestMethod]
        public void TestSimpleMove()
        {
            var expected = "0,1,NORTH";
            var actual = string.Empty;
            var robot = new Simulator.Robot();
            var parser = new Simulator.Parser(robot);
            var executor = new Simulator.Executor(robot);
            executor.WriteLine = (s) => actual = s;
            var dispatcher = new Simulator.Dispatcher(parser, executor);
            var commands = new[] { "PLACE 0,0,NORTH", "MOVE", "REPORT", ""};
            var i = 0;
            dispatcher.ReadLine = () => { return commands[i++]; };

            dispatcher.MainLoop();

            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestSimpleTurn()
        {
            var expected = "0,0,WEST";
            var actual = string.Empty;
            var robot = new Simulator.Robot();
            var parser = new Simulator.Parser(robot);
            var executor = new Simulator.Executor(robot);
            executor.WriteLine = (s) => actual = s;
            var dispatcher = new Simulator.Dispatcher(parser, executor);
            var commands = new[] { "PLACE 0,0,NORTH", "LEFT", "REPORT", "" };
            var i = 0;
            dispatcher.ReadLine = () => { return commands[i++]; };

            dispatcher.MainLoop();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCombinationMovesAndTurn()
        {
            var expected = "3,3,NORTH";
            var actual = string.Empty;
            var robot = new Simulator.Robot();
            var parser = new Simulator.Parser(robot);
            var executor = new Simulator.Executor(robot);
            executor.WriteLine = (s) => actual = s;
            var dispatcher = new Simulator.Dispatcher(parser, executor);
            var commands = new[] { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT", "" };
            var i = 0;
            dispatcher.ReadLine = () => { return commands[i++]; };

            dispatcher.MainLoop();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLongCombinationMovesWithSomeFallsAndTurns()
        {
            var expected = "0,1,NORTH";
            var actual = string.Empty;
            var robot = new Simulator.Robot();
            var parser = new Simulator.Parser(robot);
            var executor = new Simulator.Executor(robot);
            executor.WriteLine = (s) => actual = s;
            var dispatcher = new Simulator.Dispatcher(parser, executor);
            var commands = new[] { "PLACE 0,0,NORTH", "MOVE", "MOVE", "LEFT", "MOVE", "MOVE", "LEFT", "MOVE", "MOVE", "RIGHT", "MOVE", "MOVE", "LEFT", "MOVE", "MOVE", "LEFT", "MOVE", "MOVE", "RIGHT", "MOVE", "MOVE", "RIGHT", "MOVE", "MOVE", "RIGHT", "MOVE", "REPORT", "" };
            var i = 0;
            dispatcher.ReadLine = () => { return commands[i++]; };

            dispatcher.MainLoop();

            Assert.AreEqual(expected, actual);
        }
    }
}
