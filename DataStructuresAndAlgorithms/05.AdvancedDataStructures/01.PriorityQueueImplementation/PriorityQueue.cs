using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.PriorityQueueImplementation
{
    public class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryHeap<T> items;

        public PriorityQueue()
        {
            this.items = new BinaryHeap<T>();
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Add(T item)
        {
            this.items.Add(item);
        }

        public T Peek()
        {
            return this.items.Peek();
        }

        public T Remove()
        {
            return this.items.Remove();
        }

        public void Clear()
        {
            this.items.Clear();
        }
        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in this.items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
