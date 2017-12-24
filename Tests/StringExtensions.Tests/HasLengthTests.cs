using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringExtensions.Tests
{
    [TestClass]
    public class HasLengthTests
    {
        [TestMethod]
        public void HasLength_Tests()
        {
            string nil = null;

            Assert.IsFalse(nil.HasLength());
            Assert.IsFalse("".HasLength());
            Assert.IsTrue("hasLength".HasLength());
        }
    }
}
