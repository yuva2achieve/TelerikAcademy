using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace SortingHomeworkTests
{
    [TestClass]
    public class LinearSearchTests
    {
        [TestMethod]
        public void SearchValueFoundInUnsortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { 14, 1, 3, -4, 10, 5 });
            bool actual = collection.LinearSearch(3);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void SearchValueNotFoundInUnsortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { 14, 1, 3, -4, 10, 5 });
            bool actual = collection.LinearSearch(33);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SearchValueFoundInSortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { -4, 1, 3, 5, 10, 14 });
            bool actual = collection.LinearSearch(3);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void SearchValueNotFoundInSortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { -4, 1, 3, 5, 10, 14 });
            bool actual = collection.LinearSearch(33);

            Assert.IsFalse(actual);
        }
    }
}
