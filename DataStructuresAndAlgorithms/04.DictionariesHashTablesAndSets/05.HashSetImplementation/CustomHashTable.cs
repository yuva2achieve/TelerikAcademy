using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.HashSetImplementation
{
    public class CustomHashTable<K, V> : IEnumerable<KeyValuePair<K, V>>
    {
        // Fields
        private const int DefaultCapacity = 16;
        private int count;
        private int capacity;
        private LinkedList<KeyValuePair<K, V>>[] items;
        private List<K> keys;

        // Constructors
        public CustomHashTable()
            : this(DefaultCapacity)
        {
        }

        public CustomHashTable(int capacity)
        {
            this.Capacity = capacity;
            this.items = new LinkedList<KeyValuePair<K, V>>[this.Capacity];
            this.keys = new List<K>();
            this.Count = 0;
        }

        // Properties
        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                this.capacity = value;
            }
        }

        public List<K> Keys
        {
            get
            {
                return this.keys;
            }

            private set
            {
                this.keys = value;
            }
        }

        public V this[K key]
        {
            get
            {
                return this.Find(key);
            }
            set
            {
                if (this.Keys.Contains(key))
                {
                    this.Remove(key);
                    this.Add(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        // Public methods
        public void Add(K key, V value)
        {
            KeyValuePair<K, V> pair = new KeyValuePair<K, V>(key, value);
            if (this.count == this.capacity)
            {
                this.ResizeTable();
            }

            int itemIndex = CalculateIndex(key);
            if (this.items[itemIndex] == null)
            {
                this.items[itemIndex] = new LinkedList<KeyValuePair<K, V>>();
                this.items[itemIndex].AddFirst(pair);
            }
            else
            {
                this.items[itemIndex].AddLast(pair);
            }

            this.count++;
            this.Keys.Add(key);
        }

        public V Find(K key)
        {
            int itemIndex = CalculateIndex(key);

            if (this.Keys.Contains(key))
            {
                V value = default(V);
                foreach (var pair in this.items[itemIndex])
                {
                    if (pair.Key.Equals(key))
                    {
                        value = pair.Value;
                        break;
                    }
                }

                return value;
            }
            else
            {
                throw new ArgumentException("There is no item with key: " + key);
            }
        }

        public void Remove(K key)
        {
            int itemIndex = CalculateIndex(key);

            if (this.Keys.Contains(key))
            {
                foreach (var pair in this.items[itemIndex])
                {
                    if (pair.Key.Equals(key))
                    {
                        var pairToRemove = pair;
                        this.items[itemIndex].Remove(pairToRemove);
                        this.Count--;
                        break;
                    }
                }

                this.Keys.Remove(key);
            }
            else
            {
                throw new ArgumentException("There is no item with key: " + key);
            }
        }

        public bool ContainsKey(K key)
        {
            bool contains = false;
            if (this.Keys.Contains(key))
            {
                contains = true;
            }

            return contains;
        }

        public void Clear()
        {
            this.items = new LinkedList<KeyValuePair<K, V>>[DefaultCapacity];
            this.Keys.Clear();
            this.Count = 0;
        }

        // Private methods
        private int CalculateIndex(K key)
        {
            int index = Math.Abs((key.GetHashCode() % this.Capacity));
            return index;
        }

        private void ResizeTable()
        {
            LinkedList<KeyValuePair<K, V>>[] oldItems = this.items;
            int newCapacity = this.Capacity * 2;
            LinkedList<KeyValuePair<K, V>>[] newItems = new LinkedList<KeyValuePair<K, V>>[newCapacity];
            for (int i = 0; i < oldItems.Length; i++)
            {
                newItems[i] = oldItems[i];
            }

            this.items = new LinkedList<KeyValuePair<K, V>>[newCapacity];
            for (int i = 0; i < newItems.Length; i++)
            {
                this.items[i] = newItems[i];
            }

            this.Capacity = newCapacity;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var list in this.items)
            {
                if (list != null)
                {
                    foreach (KeyValuePair<K, V> pair in list)
                    {
                        yield return pair;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<K, V>>)this).GetEnumerator();
        }
    }
}
