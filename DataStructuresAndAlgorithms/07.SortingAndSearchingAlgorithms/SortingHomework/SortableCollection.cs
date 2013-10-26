namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            bool isFound = false;

            foreach (var element in this.Items)
            {
                if (element.CompareTo(item) == 0)
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        } 

        public bool BinarySearch(T item)
        {
            bool isSorted = this.IsSorted();
            if (!isSorted)
            {
                throw new ArgumentException("Values are unsorted");
            }

            bool isFound = false;
            int lowIndex = 0;
            int highIndex = this.Items.Count - 1;
            while (lowIndex < highIndex)
            {
                int midIndex = (lowIndex + highIndex) / 2;
                if (this.Items[midIndex].CompareTo(item) == 1)
                {
                    highIndex = midIndex - 1;
                }
                else if (this.Items[midIndex].CompareTo(item) == -1)
                {
                    lowIndex = midIndex + 1;
                }
                else
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        // Implements Fisher-Yates Shuffle
        public void Shuffle()
        {
            int lastIndex = this.Items.Count - 1;
            for (int i = lastIndex; i > 0; i--)
            {
                Random rand = new Random();
                int randomIndex = rand.Next(0, i);

                T temp = this.Items[randomIndex];
                this.Items[randomIndex] = this.Items[i];
                this.Items[i] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }

        private bool IsSorted()
        {
            bool isSorted = true;
            for (int i = 0; i < this.Items.Count; i++)
            {
                for (int j = i + 1; j < this.Items.Count; j++)
                {
                    if (this.Items[i].CompareTo(this.Items[j]) == 1)
                    {
                        isSorted = false;
                        break;
                    }
                }
            }

            return isSorted;
        }
    }
}
