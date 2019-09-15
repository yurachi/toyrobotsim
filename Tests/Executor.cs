using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Simulator;

namespace Tests
{
    [TestClass]
    public class Executor
    {
        [TestMethod]
        public void TestExecuteSetsCoordinatesAndDirectionOnPlace()
        {
            var robot = Substitute.For<IRobot>();
            var o = new Simulator.Executor(robot);
            o.Execute(CommandType.PLACE,0,0,Direction.NORTH);
            robot.Received(1).X = 0;
            robot.Received(1).Y = 0;
            robot.Received(1).FacingDirection = Direction.NORTH;
        }

        [TestMethod]
        public void TestExecuteSetsCoordinatesAndNotDirectionOnMove()
        {
            var robot = Substitute.For<IRobot>();
            robot.X.Returns(0);
            robot.Y.Returns(0);
            robot.FacingDirection.Returns(Direction.NORTH);
            var o = new Simulator.Executor(robot);

            o.Execute(CommandType.MOVE);

            robot.Received(1).X = 0;
            robot.Received(1).Y = 1;
            robot.DidNotReceive().FacingDirection = Arg.Any<Direction>();
        }

        [TestMethod]
        public void TestExecuteSetsDirectionAndNotCoordinatesOnLeft()
        {
            var robot = Substitute.For<IRobot>();
            robot.X.Returns(0);
            robot.Y.Returns(0);
            robot.FacingDirection.Returns(Direction.NORTH);
            var o = new Simulator.Executor(robot);

            o.Execute(CommandType.LEFT);

            robot.DidNotReceive().X = Arg.Any<int>();
            robot.DidNotReceive().Y = Arg.Any<int>();
            robot.Received(1).FacingDirection = Direction.WEST;
        }

        [TestMethod]
        public void TestExecuteSetsDirectionAndNotCoordinatesOnRight()
        {
            var robot = Substitute.For<IRobot>();
            robot.X.Returns(0);
            robot.Y.Returns(0);
            robot.FacingDirection.Returns(Direction.NORTH);
            var o = new Simulator.Executor(robot);

            o.Execute(CommandType.RIGHT);

            robot.DidNotReceive().X = Arg.Any<int>();
            robot.DidNotReceive().Y = Arg.Any<int>();
            robot.Received(1).FacingDirection = Direction.EAST;
        }

        [TestMethod]
        public void TestExecuteNotSetDirectionNorCoordinatesOnReport()
        {
            var robot = Substitute.For<IRobot>();
            robot.X.Returns(0);
            robot.Y.Returns(0);
            robot.FacingDirection.Returns(Direction.NORTH);
            var o = new Simulator.Executor(robot);

            o.Execute(CommandType.RIGHT);

            robot.DidNotReceive().X = Arg.Any<int>();
            robot.DidNotReceive().Y = Arg.Any<int>();
            robot.DidNotReceive().FacingDirection = Arg.Any<Direction>();
        }
    }
}
