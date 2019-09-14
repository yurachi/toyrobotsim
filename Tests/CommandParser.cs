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
    }
}
