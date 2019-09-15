using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simulator;

namespace Tests
{
    [TestClass]
    public class Calculator
    {
        [DataTestMethod]
        [DataRow(CommandType.LEFT, Direction.NORTH, Direction.WEST)]
        [DataRow(CommandType.LEFT, Direction.WEST, Direction.SOUTH)]
        [DataRow(CommandType.LEFT, Direction.SOUTH, Direction.EAST)]
        [DataRow(CommandType.LEFT, Direction.EAST, Direction.NORTH)]
        [DataRow(CommandType.RIGHT, Direction.NORTH, Direction.EAST)]
        [DataRow(CommandType.RIGHT, Direction.EAST, Direction.SOUTH)]
        [DataRow(CommandType.RIGHT, Direction.SOUTH, Direction.WEST)]
        [DataRow(CommandType.RIGHT, Direction.WEST, Direction.NORTH)]
        public void TestTurn(CommandType leftOrRight, Direction facing, Direction expected)
        {
            var actual = facing;
            Simulator.Calculator.CalculateTurn(ref actual, leftOrRight);
            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow(Direction.NORTH, 2, 2, 2, 3)]
        [DataRow(Direction.EAST, 2, 2, 3, 2)]
        [DataRow(Direction.SOUTH, 2, 2, 2, 1)]
        [DataRow(Direction.WEST, 2, 2, 1, 2)]
        public void TestMove(Direction facing, int x, int y, int expectedX, int expectedY)
        {
            var actualX = x;
            var actualY = y;
            Simulator.Calculator.CalculateMove(ref actualX, ref actualY, facing);
            Assert.AreEqual(expectedX, actualX);
            Assert.AreEqual(expectedY, actualY);
        }
    }
}
