using System;
using System.Linq;
using System.Collections.Generic;

namespace _14.QuickSort
{
    class QuickSort
    {
        public static List<char> MergeLists(List<char> lesser, char pivot, List<char> bigger)
        {
            List<char> sorted = new List<char>();
            foreach (var value in lesser)
            {
                sorted.Add(value);
            }
            sorted.Add(pivot);
            foreach (var value in bigger)
            {
                sorted.Add(value);
            }
            return sorted;
        }

        static List<char> QuickSortAlgoritm(List<char> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            Random RandomValue = new Random();
            char pivot = list[RandomValue.Next(list.Count - 1)];
            list.Remove(pivot);
            List<char> lesser = new List<char>();
            List<char> bigger = new List<char>();
            foreach (var value in list)
            {
                if (value < pivot)
                {
                    lesser.Add(value);
                }
                else
                {
                    bigger.Add(value);
                }
            }
            return MergeLists(QuickSortAlgoritm(lesser), pivot, QuickSortAlgoritm(bigger));
        }
        static void Main(string[] args) 
        {
            string input = Console.ReadLine();
            List<char> myList = new List<char> { };
            foreach (var letter in input)
            {
                myList.Add(letter);
            }
            List<char> newList = new List<char>(QuickSortAlgoritm(myList));
            foreach (var item in newList)
            {
                Console.Write(item + " ");
            }
        }
    }
}
