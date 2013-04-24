using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.MaxElementInArray
{                                                                                                                                                                                                                       
    class MaxElementInArray
    {
        static int GetMaxElement(int stopPosition, int[] array)
        {
            Array.Sort(array);
            int maxValue = array[stopPosition - 1];
            return maxValue;
        }
        static List<int> SortInDescendingOrder(int[] array)
        {
            List<int> sortedDescending = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
               sortedDescending.Add(GetMaxElement(array.Length - i, array));
            }
            return sortedDescending;
        }
        static List<int> SortInAscendingOrder(int[] array)
        {
            List<int> sortedAscending = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                sortedAscending.Add(GetMinElement(array.Length - i,array));
            }
            return sortedAscending;
        }
  
        static int GetMinElement(int stop, int[] array)
        {
            Array.Sort(array);
            Array.Reverse(array);
            int minValue = array[stop - 1];
            return minValue;   
        }

        static void Main(string[] args)
        {
            int[] myArray = { 5, 3, 2, 4, 7, 15, 7, 0, 8, 3, 2, 6, 24, 636, -1, -14, 41, 335, 46, 92, -535, -760 };
            int stop = myArray.Length;
            int maxElementInArray = GetMaxElement(stop, myArray);
            List<int> ascendingSort = new List<int>(SortInAscendingOrder(myArray));
            List<int> descendingSort = new List<int>(SortInDescendingOrder(myArray));
            Console.WriteLine("Biggest element in the array is: {0}", maxElementInArray);
            Console.Write("Array sorted in ascending order: ");
            foreach (var item in ascendingSort)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.Write("Array sorted in descending order: ");
            foreach (var item in descendingSort)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();

        }
    }
}
