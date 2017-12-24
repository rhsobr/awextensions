using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringExtensions.Tests
{
    [TestClass]
    public class FluentFormatTests
    {
        [TestMethod]
        public void Success_Flow()
        {
            var formatStr = "My Format: {0}";

            Assert.IsTrue(formatStr.FluentFormat("This!") == "My Format: This!");

        }

        [TestMethod, TestCategory("StringExtensions")]
        public void More_Objects_Than_Spected()
        {
            var formatStr = "My Format: {0}";

            Assert.IsTrue(formatStr.FluentFormat("This!", 2) == "My Format: This!");
        }

        [TestMethod]
        public void Less_Objects_Than_Spected()
        {
            var formatStr = "My Format: {0}, {1}";

            Assert.ThrowsException<FormatException>(() => formatStr.FluentFormat(2));
        }
    }
}
