using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Simulator;

namespace Tests
{
    [TestClass]
    public class Parser
    {
        [TestMethod]
        public void TestCreate()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void TestEmptyParse()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = string.Empty;
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidCommand()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "INVALID";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        #region PLACE command

        [TestMethod]
        public void TestPlaceCommandWithoutParameters()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "PLACE";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithInsufficentParameters()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "PLACE 0,NORTH";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithMissingParameters()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "PLACE 0,,NORTH";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithWrongOrderParameters()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "PLACE 0,NORTH,0";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithInvalidFacing()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "PLACE 0,0,INVALID";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(-1, 0)]
        [DataRow(1, 10)]
        [DataRow(5, -20)]
        public void TestPlaceCommandWithIncorrectCoordinates(int x, int y)
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = string.Format("PLACE {0},{1},NORTH",x,y);
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("0,0,NORTH")]
        [DataRow("0,5,SOUTH")]
        [DataRow("0,1,EAST")]
        [DataRow("5,5,WEST")]
        public void TestValidPlaceCommand(string data)
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "PLACE " + data;
            var expected = Simulator.CommandType.PLACE;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(0, 0)]
        [DataRow(1, 3)]
        [DataRow(5, 5)]
        public void TestPlaceCommandCorrectCoordinates(int x, int y)
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = string.Format("PLACE {0},{1},NORTH", x, y);

            o.Parse(command);

            Assert.AreEqual(x, o.XResult);
            Assert.AreEqual(y, o.YResult);
        }

        [DataTestMethod]
        [DataRow("NORTH")]
        [DataRow("SOUTH")]
        [DataRow("EAST")]
        [DataRow("WEST")]
        public void TestValidPlaceCommandDirection(string data)
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "PLACE 1,1," + data;

            o.Parse(command);

            Assert.AreEqual(data, o.DResult.ToString());
        }

        #endregion

        #region MOVE command

        [TestMethod]
        public void TestMoveCommandBeforePlaceCommand()
        {
            var o = new Simulator.Parser(Substitute.For<IRobot>());
            var command = "MOVE";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoveCommandOnPlacedRobot()
        {
            var robot = Substitute.For<IRobot>();
            robot.X.Returns(2);
            robot.Y.Returns(2);
            robot.Face.Returns(Direction.EAST);
            var o = new Simulator.Parser(robot);
            var command = "MOVE";
            var expected = Simulator.CommandType.MOVE;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
