using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.HashSetImplementation
{
    public class CustomHashSet<T> : IEnumerable<T>
    {
        // Fields
        private readonly CustomHashTable<T, T> elements;

        // Constructor
        public CustomHashSet()
        {
            this.elements = new CustomHashTable<T, T>();
        }
        
        // Properties
        public int Count
        {
            get
            {
                return this.elements.Count;
            }
        }

        // Public methods
        public void Add(T element)
        {
            this.elements.Add(element, element);
        }

        public void Remove(T element)
        {
            this.elements.Remove(element);
        }

        public T Find(T element)
        {
            T value = this.elements.Find(element);
            return value;
        }

        public bool Contains(T element)
        {
            bool contains = false;
            if (this.elements.ContainsKey(element))
            {
                contains = true;
            }

            return contains;
        }

        public void Clear()
        {
            this.elements.Clear();
        }

        public IEnumerable<T> Union(IEnumerable<T> otherHashSet)
        {
            CustomHashSet<T> union = new CustomHashSet<T>();
            foreach (var element in this)
            {
                bool isFound = otherHashSet.Contains(element);
                if (!isFound)
                {
                    union.Add(element);
                }
            }

            foreach (var element in otherHashSet)
            {
                bool isFound = this.Contains(element);
                if (!isFound)
                {
                    union.Add(element);
                }
            }

            return union;
        }

        public IEnumerable<T> Intersect(IEnumerable<T> otherHashSet)
        {
            CustomHashSet<T> intersection = new CustomHashSet<T>();
            foreach (var element in this)
            {
                bool isFound = otherHashSet.Contains(element);
                if (isFound)
                {
                    intersection.Add(element);
                }
            }

            return intersection;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var keyValuePair in this.elements)
            {
                yield return keyValuePair.Key;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}
