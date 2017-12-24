using DateTimeExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class IsBetweenTests
    {
        [TestMethod]
        public void Tests()
        {
            var now = DateTime.Now;

            Assert.IsTrue(now.IsBetween(DateTime.Today, DateTime.Today.AddDays(1)));
            Assert.IsTrue(now.IsBetween(DateTime.Today.AddDays(1), DateTime.Today));
            Assert.IsFalse(now.IsBetween(DateTime.Today.AddDays(1), DateTime.Today.AddDays(2)));
            Assert.IsFalse(now.IsBetween(now, now));
            Assert.IsTrue(now.IsBetween(now.AddMilliseconds(-1), now));
        }
    }
}
