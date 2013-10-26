using System;
using System.Linq;

namespace _11.LinkedListImplementation
{
    public class CustomLinkedList<T>
    {
        private ListItem<T> firstElement;

        public CustomLinkedList()
            : this(null)
        {
        }

        public CustomLinkedList(ListItem<T> firstElement)
        {
            this.FirstElement = firstElement;
        }

        public ListItem<T> FirstElement
        {
            get
            {
                return this.firstElement;
            }

            set
            {
                this.firstElement = value;
            }
        }

        public void AddFirst(T value)
        {
            ListItem<T> newFirstElement;
            if (this.FirstElement != null)
            {
                ListItem<T> currentFirstElement = this.FirstElement;
                newFirstElement = new ListItem<T>(value, currentFirstElement);
                this.FirstElement = newFirstElement;
            }
            else
            {
                newFirstElement = new ListItem<T>(value);
                this.FirstElement = newFirstElement;
            }
        }

        public void AddLast(T value)
        {
            ListItem<T> lastElement = GetLastElement();
            lastElement.NextItem = new ListItem<T>(value);
        }

        public void AddBefore(ListItem<T> listItem, T value)
        {
            if (listItem == this.FirstElement)
            {
                this.AddFirst(value);
            }
            else
            {

                ListItem<T> listItemParent = FindListItemParent(listItem);
                if (listItemParent == null)
                {
                    throw new ArgumentException("Item not found in the list");
                }

                listItemParent.NextItem = new ListItem<T>(value);
                listItemParent.NextItem.NextItem = listItem;
            }
        }

        public void AddAfter(ListItem<T> listItem, T value)
        {
            ListItem<T> searchedItem = FindListItem(listItem);
            if (searchedItem == null)
            {
                throw new ArgumentException("Item not found in the list");
            }
            ListItem<T> currentChildren = searchedItem.NextItem;
            searchedItem.NextItem = new ListItem<T>(value, currentChildren);
        }

        public void RemoveFirst()
        {
            if (this.FirstElement == null)
            {
                throw new ArgumentNullException("There are no items in the list");
            }
            ListItem<T> currentChildren = this.FirstElement.NextItem;
            this.FirstElement = currentChildren;
        }

        public void RemoveLast()
        {
            ListItem<T> lastElement = GetLastElement();
            ListItem<T> lastElementParent = FindListItemParent(lastElement);
            lastElementParent.NextItem = null;
        }

        public int Count()
        {
            int counter = 1;
            ListItem<T> currentElement = this.FirstElement;
            while (true)
            {
                if (currentElement.NextItem == null)
                {
                    return counter;
                }
                else
                {
                    counter++;
                    currentElement = currentElement.NextItem;
                }
            }
        }

        private ListItem<T> GetLastElement()
        {
            ListItem<T> currentElement = this.FirstElement;
            while (true)
            {
                if (currentElement.NextItem == null)
                {
                    return currentElement;
                }
                else
                {
                    currentElement = currentElement.NextItem;
                }
            }
        }

        private ListItem<T> FindListItemParent(ListItem<T> element)
        {
            ListItem<T> currentElement = this.FirstElement;
            while (currentElement.NextItem != null)
            {
                if (currentElement.NextItem.Equals(element))
                {
                    return currentElement;
                }
                else
                {
                    currentElement = currentElement.NextItem;
                }
            }

            return null;
        }

        private ListItem<T> FindListItem(ListItem<T> element)
        {
            if (this.FirstElement.Equals(element))
            {
                return this.FirstElement;
            }

            ListItem<T> currentElement = this.FirstElement;

            while (currentElement.NextItem != null)
            {
                if (currentElement.NextItem.Equals(element))
                {
                    return currentElement.NextItem;
                }
                else
                {
                    currentElement = currentElement.NextItem;
                }
            }

            return null;
        }
    }
}
