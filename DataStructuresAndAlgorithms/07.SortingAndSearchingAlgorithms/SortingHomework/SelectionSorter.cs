namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            T minValue;
            for (int i = 0; i < collection.Count; i++)
            {
                minValue = collection[i];
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[i].CompareTo(collection[j]) == 1)
                    {
                        minValue = collection[j];
                        collection[j] = collection[i];
                        collection[i] = minValue;
                    }
                }
            }
        }
    }
}
