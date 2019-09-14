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
    }
}
