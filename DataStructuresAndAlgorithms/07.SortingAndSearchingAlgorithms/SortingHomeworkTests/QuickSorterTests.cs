using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace SortingHomeworkTests
{
    [TestClass]
    public class QuickSorterTests
    {
        [TestMethod]
        public void TestSortWithSortedValues()
        {
            var collection = new SortableCollection<int>(new[] { -4, 1, 3, 5, 10, 14 });
            var expected = new SortableCollection<int>(new[] { -4, 1, 3, 5, 10, 14 });

            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count; i++)
            {
                Assert.AreEqual(expected.Items[i], collection.Items[i]);
            }
        }

        [TestMethod]
        public void TestSortWithoutDuplicatedValues()
        {
            var collection = new SortableCollection<int>(new[] { 14, 1, 3, -4, 10, 5 });
            var expected = new SortableCollection<int>(new[] { -4, 1, 3, 5, 10, 14 });

            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count; i++)
            {
                Assert.AreEqual(expected.Items[i], collection.Items[i]);
            }
        }

        [TestMethod]
        public void TestSortWithDuplicatedValues()
        {
            var collection = new SortableCollection<int>(new[] { 14, 1, 10, 3, -4, 10, 5, 3 });
            var expected = new SortableCollection<int>(new[] { -4, 1, 3, 3, 5, 10, 10, 14 });

            collection.Sort(new Quicksorter<int>());

            for (int i = 0; i < collection.Items.Count; i++)
            {
                Assert.AreEqual(expected.Items[i], collection.Items[i]);
            }
        }
    }
}
