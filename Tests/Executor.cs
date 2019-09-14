using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Simulator;

namespace Tests
{
    [TestClass]
    public class Executor
    {
        [TestMethod]
        public void TestExecutorSetsCoordinatesAndDirectionOnPlace()
        {
            var robot = Substitute.For<IRobot>();
            var o = new Simulator.Executor(robot);
            o.Execute(CommandType.PLACE,0,0,Direction.NORTH);
            robot.Received(1).X = 0;
            robot.Received(1).Y = 0;
            robot.Received(1).Face = Direction.NORTH;
        }

        [TestMethod]
        public void TestExecutorSetsCoordinatesAndNotDirectionOnMove()
        {
            var robot = Substitute.For<IRobot>();
            robot.X.Returns(0);
            robot.Y.Returns(0);
            robot.Face.Returns(Direction.NORTH);
            var o = new Simulator.Executor(robot);

            o.Execute(CommandType.MOVE);

            robot.Received(1).X = 0;
            robot.Received(1).Y = 1;
            robot.DidNotReceive().Face = Arg.Any<Direction>();
        }
    }
}
