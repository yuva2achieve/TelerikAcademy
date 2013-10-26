using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.StackImplementation
{
    public class CustomStack<T>
    {
        private T[] elements;
        private int currentIndex;

        public CustomStack()
            : this(5)
        {
        }

        public CustomStack(int capacity)
        {
            this.elements = new T[capacity];
            this.currentIndex = -1;
        }

        public CustomStack(IEnumerable<T> collection)
        {
            this.currentIndex = -1;
            CollectionToStack(collection);
        }

        public int Count
        {
            get
            {
                return this.currentIndex + 1;
            }
        }

        public void Push(T item)
        {
            if (currentIndex == elements.Length - 1)
            {
                T[] newArray = ResizeArray();
                CopyArray(this.elements, newArray);
                this.elements = newArray;
            }

            this.currentIndex++;
            elements[currentIndex] = item;

        }

        public T Pop()
        {
            if (this.currentIndex < 0)
            {
                throw new ArgumentOutOfRangeException("There are no items in the stack");
            }

            T element = elements[currentIndex];
            elements[currentIndex] = default(T);
            currentIndex--;
            return element;
        }

        public T Peek()
        {
            if (this.currentIndex < 0)
            {
                throw new ArgumentOutOfRangeException("There are no items in the stack");
            }

            T element = elements[currentIndex];
            return element;
        }

        public bool Contains(T item)
        {
            bool isFound = false;
            for (int i = 0; i < this.elements.Length; i++)
            {
                if (this.elements[i].Equals(item))
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        public void Clear()
        {
            Array.Clear(this.elements, 0, this.elements.Length);
            this.currentIndex = -1;
        }

        public T[] ToArray()
        {
            T[] result = new T[this.Count];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = this.elements[this.Count - i - 1];
            }

            return result;
        }

        public void TrimExcess()
        {
            T[] newArray = new T[this.Count];
            Array.Copy(this.elements, 0, newArray, 0, newArray.Length);
            this.elements = newArray;
        }

        private void CollectionToStack(IEnumerable<T> collection)
        {
            int collectionLength = collection.Count();
            this.elements = new T[collectionLength];
            foreach (var element in collection)
            {
                this.Push(element);
            }
        }

        private T[] ResizeArray()
        {
            int newLength = this.elements.Length + 5;
            T[] resizedArray = new T[newLength];

            return resizedArray;
        }

        private void CopyArray(T[] oldArray, T[] newArray)
        {
            for (int i = 0; i < oldArray.Length; i++)
            {
                newArray[i] = oldArray[i];
            }
        }
    }
}
