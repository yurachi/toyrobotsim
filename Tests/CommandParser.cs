using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CommandParser
    {
        [TestMethod]
        public void TestCreate()
        {
            var o = new Simulator.CommandParser();
            Assert.IsNotNull(o);
        }

        [TestMethod]
        public void TestEmptyParse()
        {
            var o = new Simulator.CommandParser();
            var command = string.Empty;
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestInvalidCommand()
        {
            var o = new Simulator.CommandParser();
            var command = "INVALID";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        #region PLACE command

        [TestMethod]
        public void TestPlaceCommandWithoutParameters()
        {
            var o = new Simulator.CommandParser();
            var command = "PLACE";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithInsufficentParameters()
        {
            var o = new Simulator.CommandParser();
            var command = "PLACE 0,NORTH";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithMissingParameters()
        {
            var o = new Simulator.CommandParser();
            var command = "PLACE 0,,NORTH";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithWrongOrderParameters()
        {
            var o = new Simulator.CommandParser();
            var command = "PLACE 0,NORTH,0";
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPlaceCommandWithInvalidFacing()
        {
            var o = new Simulator.CommandParser();
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
            var o = new Simulator.CommandParser();
            var command = string.Format("PLACE {0},{1},NORTH",x,y);
            var expected = Simulator.CommandType.NOP;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("0,0,NORTH")]
        public void TestValidPlaceCommand(string data)
        {
            var o = new Simulator.CommandParser();
            var command = "PLACE " + data;
            var expected = Simulator.CommandType.PLACE;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region MOVE command

        [TestMethod]
        public void TestMoveCommandBeforePlaceCommand()
        {
            var o = new Simulator.CommandParser();
            var command = "MOVE";
            var expected = Simulator.CommandType.MOVE;

            var actual = o.Parse(command);

            Assert.AreEqual(expected, actual);
        }


        #endregion
    }
}
