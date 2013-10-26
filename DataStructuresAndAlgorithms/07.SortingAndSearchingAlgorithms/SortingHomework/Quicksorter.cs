namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            IList<T> sortedList = QuickSort(collection);

            for (int i = 0; i < sortedList.Count; i++)
            {
                collection[i] = sortedList[i];
            }
        }

        private IList<T> QuickSort(IList<T> collection)
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

            Random randomValue = new Random();
            T pivot = listToSort[randomValue.Next(listToSort.Count - 1)];
            listToSort.Remove(pivot);
            IList<T> lesser = new List<T>();
            IList<T> bigger = new List<T>();
            foreach (var value in listToSort)
            {
                if (value.CompareTo(pivot) == -1)
                {
                    lesser.Add(value);
                }
                else
                {
                    bigger.Add(value);
                }
            }

            return Merge(QuickSort(lesser), pivot, QuickSort(bigger));
        }

        private IList<T> Merge(IList<T> lesser, T pivot, IList<T> bigger)
        {
            IList<T> sortedList = new List<T>();

            foreach (var value in lesser)
            {
                sortedList.Add(value);
            }

            sortedList.Add(pivot);

            foreach (var value in bigger)
            {
                sortedList.Add(value);
            }

            return sortedList;
        }


    }
}
