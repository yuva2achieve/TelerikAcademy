using System;
using System.Collections.Generic;
using System.Linq;

namespace _13.LinkedQueueImplementation
{
    public class LinkedQueue<T>
    {
        private LinkedList<T> items;

        public LinkedQueue()
        {
            this.items = new LinkedList<T>();
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public void Enqueue(T item)
        {
            items.AddLast(item);
        }

        public T Dequeue()
        {
            T item = this.items.First.Value;
            this.items.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            T item = this.items.First.Value;
            return item;
        }

        public void Clear()
        {
            this.items.Clear();
        }

        public bool Contains(T item)
        {
            bool isFound = this.items.Contains(item);
            return isFound;
        }

        public T[] ToArray()
        {
            T[] tArray = new T[this.items.Count];
            LinkedQueue<T> currentQueue = this;
            for (int i = 0; i < tArray.Length; i++)
            {
                tArray[i] = currentQueue.Dequeue();
            }

            return tArray;
        }
    }
}
