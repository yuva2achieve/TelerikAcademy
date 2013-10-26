namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sortedCollection = MergeSort(collection);

            for (int i = 0; i < sortedCollection.Count; i++)
            {
                collection[i] = sortedCollection[i];
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            IList<T> listToSort = new List<T>();
            foreach (var value in collection)
            {
                listToSort.Add(value);
            }

            IList<T> left = new List<T>();
            IList<T> right = new List<T>();
            IList<T> result = new List<T>();
            for (int i = 0; i < listToSort.Count / 2; i++)
            {
                left.Add(listToSort[i]);
            }
            for (int i = listToSort.Count / 2; i < listToSort.Count; i++)
            {
                right.Add(listToSort[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            if (left[left.Count - 1].CompareTo(right[0]) == -1)
            {
                return MergeLists(left, right);
            }

            result = PutElementsInOrder(left, right);
            return result;
        }

        private IList<T> PutElementsInOrder(IList<T> leftList, IList<T> rightList)
        {
            var result = new List<T>(leftList.Count + rightList.Count);

            while (leftList.Count > 0 && rightList.Count > 0)
            {
                if (leftList[0].CompareTo(rightList[0]) == 1)
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
                else
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
            }

            while (leftList.Count > 0)
            {
                result.Add(leftList[0]);
                leftList.RemoveAt(0);
            }

            while (rightList.Count > 0)
            {
                result.Add(rightList[0]);
                rightList.RemoveAt(0);
            }

            return result;
        }

        public static IList<T> MergeLists(IList<T> list1, IList<T> list2)
        {
            IList<T> newList = new List<T>(list1);
            foreach (var value in list2)
            {
                newList.Add(value);
            }
            return newList;
        }
    }
}
