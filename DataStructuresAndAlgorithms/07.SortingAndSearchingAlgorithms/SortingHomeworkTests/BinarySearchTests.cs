using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace SortingHomeworkTests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchValueFoundInUnsortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { 14, 1, 3, -4, 10, 5 });
            bool actual = collection.BinarySearch(3);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SearchValueNotFoundInUnsortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { 14, 1, 3, -4, 10, 5 });
            bool actual = collection.BinarySearch(33);
        }

        [TestMethod]
        public void SearchValueFoundInSortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { -4, 1, 3, 5, 10, 14 });
            bool actual = collection.BinarySearch(3);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void SearchValueNotFoundInSortedCollection()
        {
            var collection = new SortableCollection<int>(new[] { -4, 1, 3, 5, 10, 14 });
            bool actual = collection.BinarySearch(33);

            Assert.IsFalse(actual);
        }
    }
}
