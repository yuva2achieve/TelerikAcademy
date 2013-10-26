using System;
using System.Linq;

namespace _11.LinkedListImplementation
{
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T value)
            : this(value, null)
        {
        }

        public ListItem(T value, ListItem<T> nextItem)
        {
            this.Value = value;
            this.NextItem = nextItem;
        }

        public override bool Equals(object obj)
        {
            ListItem<T> temp = obj as ListItem<T>;
            if (temp == null)
                return false;
            return this.Equals(temp);
        }

        public bool Equals(ListItem<T> value)
        {
            if (ReferenceEquals(null, value))
            {
                return false;
            }
            if (ReferenceEquals(this, value))
            {
                return true;
            }
            return Equals(this.value, value.value) &&
                   Equals(this.nextItem, value.nextItem);
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem;
            }

            set
            {
                this.nextItem = value;
            }
        }
    }
}
