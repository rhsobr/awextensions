using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnumerableExtensions.Tests
{
    [TestClass]
    public class ChunkTests
    {
        [TestMethod]
        public void InvalidArguments()
        {
            IEnumerable<string> list = null;

            Assert.ThrowsException<ArgumentNullException>(() => list.Chunk(10));
            Assert.ThrowsException<ArgumentException>(() => new List<string>().Chunk(-10));
            Assert.ThrowsException<ArgumentException>(() => new List<string>().Chunk(0));

        }

        [TestMethod]
        public void Chunk_With_2_Elements()
        {
            var list = new List<string> { "John", "Chunk" };

            var response = list.Chunk(1);

            Assert.IsTrue(response.First().Count() == 1);
            Assert.IsTrue(response.First().First() == "John");
            Assert.IsTrue(response.Last().Count() == 1);
            Assert.IsTrue(response.Last().First() == "Chunk");
        }

        [TestMethod]
        public void ChunkSize_Greater_Than_List_Count()
        {
            var list = new List<string> { "John", "Chunk" };

            var response = list.Chunk(100);

            Assert.IsTrue(response.First().Count() == list.Count());
            Assert.IsTrue(response.First().All(item => list.Contains(item)));
        }

        [TestMethod]
        public void Chunk_Big_List()
        {
            var list = Enumerable.Range(0, 99999999);

            var response = list.Chunk(100);

            Assert.IsTrue(response.Count() == (list.Count() / 100) + (list.Count() % 100 == 0 ? 0 : 1));
            Assert.IsTrue(response.All(h => h.Count() <= 100));
        }
    }
}
