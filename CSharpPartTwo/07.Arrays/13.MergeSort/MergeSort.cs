using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.MergeSort
{
    class MergeSort
    {
        public static List<int> PutElementsInOrder(List<int> list1, List<int> list2)
        {
            List<int> sorted = new List<int>();
            while (list1.Count > 0 && list2.Count > 0)
            {
                if (list1[0] < list2[0])
                {
                    sorted.Add(list1[0]);
                    list1.RemoveAt(0);
                }
                else
                {
                    sorted.Add(list2[0]);
                    list2.RemoveAt(0);
                }
            }
            while (list1.Count > 0)
            {
                sorted.Add(list1[0]);
                list1.RemoveAt(0);
            }
            while (list2.Count > 0)
            {
                sorted.Add(list2[0]);
                list2.RemoveAt(0);
            }
            return sorted;
        }

        public static List<int> MergeLists(List<int> list1, List<int> list2)
        {
            List<int> newList = new List<int>(list1);
            foreach (var value in list2)
            {
                newList.Add(value);
            }
            return newList;
        }
        static List<int> MergeSortAlgoritm(List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            List<int> result = new List<int>();
            for (int i = 0; i < list.Count / 2; i++)
            {
                left.Add(list[i]);
            }
            for (int i = list.Count / 2; i < list.Count; i++)
            {
                right.Add(list[i]);
            }
            left = MergeSortAlgoritm(left);
            right = MergeSortAlgoritm(right);
            if (left[left.Count - 1] < right[0])
            {
                return MergeLists(left, right);
            }
            result = PutElementsInOrder(left, right);
            return result;
        }
        static void Main(string[] args)
        {
            List<int> myList = new List<int> { 5, 2, -3, 7, 0, 15 };
            List<int> sortedList = MergeSortAlgoritm(myList);
            foreach (var element in sortedList)
            {
                Console.Write(element + " ");
            }
        }
    }
}
