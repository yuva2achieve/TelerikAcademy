using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04.FindLongestSubsequenceOfEqualNumbers;
using System.Collections.Generic;

namespace SequenceUtilitiesTests
{
    [TestClass]
    public class GetLongestSubsequenceOfEqualNumbersTests
    {
        [TestMethod]
        public void FirstTest()
        {
            List<int> testSequence = new List<int>()
            {
                5, 2, 3, 5, 5, 2, 2, 2, 2
            };

            var actual = SequenceUtilities.GetLongestSubsequenceOfEqualNumbers(testSequence);
            var expected = new List<int>()
            {
                2, 2, 2, 2
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondTest()
        {
            List<int> testSequence = new List<int>()
            {
                5, 5, 5, 3, 2, 1, 4, 3, 5, 5
            };

            var actual = SequenceUtilities.GetLongestSubsequenceOfEqualNumbers(testSequence);
            var expected = new List<int>()
            {
                5, 5, 5
            };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThirdTest()
        {
            List<int> testSequence = new List<int>()
            {
                1, 1, 2, 5, 11, 4, 4
            };

            var actual = SequenceUtilities.GetLongestSubsequenceOfEqualNumbers(testSequence);
            var expected = new List<int>()
            {
                1, 1
            };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
