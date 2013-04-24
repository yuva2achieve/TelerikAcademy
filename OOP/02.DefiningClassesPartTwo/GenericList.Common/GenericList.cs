using System;
using System.Linq;
using System.Text;

namespace GenericList.Common
{
    public class GenericList<T> where T: IComparable
    {
        // Fields
        private T[] elementsList;
        private int elementCount;// Stores current element count
        // Constructors
        public GenericList(int size)
        {
            this.elementsList = new T[size];
        }
        // Properties
        public int ElementCount
        {
            get
            {
                return this.elementCount;
            }
        }
        // Methods
        public void Add(T element)
        {
            if (this.elementCount < this.elementsList.Length)// If element count is less than array lenght adds new element
            {
                if (this.elementCount == 0)
                {
                    this.elementsList[0] = element;
                    this.elementCount++;
                }
                else
                {
                    this.elementsList[0 + this.elementCount] = element;
                    this.elementCount++;
                }
            }
            else// If array is full doubles it's size
            {
                T[] extensionArray = new T[this.elementsList.Length * 2];
                for (int i = 0; i < this.elementsList.Length; i++)
                {
                    extensionArray[i] = this.elementsList[i];
                }
                this.elementsList = new T[extensionArray.Length];
                for (int i = 0; i < extensionArray.Length; i++)
                {
                    this.elementsList[i] = extensionArray[i];
                }
                Add(element);
            }
        }
        public T GetElementAtPosition(int position)
        {
            if (position < this.elementsList.Length)
            {
                return this.elementsList[position];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void RemoveElementAtPosition(int position)
        {
            if (position < this.elementsList.Length)
            {
                T[] temporaryArray = new T[this.elementsList.Length - 1];
                bool positionFound = false;
                for (int i = 0; i < this.elementsList.Length; i++)
                {
                    if (positionFound == false)
                    {
                        if (i != position)
                        {
                            temporaryArray[i] = this.elementsList[i];
                        }
                        else
                        {
                            positionFound = true;
                        }
                    }
                    else
                    {
                        temporaryArray[i - 1] = this.elementsList[i];
                    }
                }
                this.elementsList = new T[temporaryArray.Length];
                for (int i = 0; i < this.elementsList.Length; i++)
                {
                    this.elementsList[i] = temporaryArray[i];
                }
                this.elementCount--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void InsertElementAtPosition(int position, T element)
        {
            if (position < this.elementsList.Length)
            {
                T[] temporaryArray = new T[this.elementsList.Length + 1];
                bool positionFound = false;
                for (int i = 0; i < this.elementsList.Length; i++)
                {
                    if (positionFound == false)
                    {
                        if (i != position)
                        {
                            temporaryArray[i] = this.elementsList[i];
                        }
                        else
                        {
                            positionFound = true;
                            temporaryArray[i] = element;
                        }
                    }
                    else
                    {
                        temporaryArray[i] = this.elementsList[i - 1];
                    }
                }
                this.elementsList = new T[temporaryArray.Length];
                for (int i = 0; i < this.elementsList.Length; i++)
                {
                    this.elementsList[i] = temporaryArray[i];
                }
                this.elementCount++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public int FindElementByValue(dynamic value)
        {
            int position = -1;
            for (int i = 0; i < this.elementsList.Length; i++)
            {
                if (elementsList[i] == value)
                {
                    position = i;
                }
            }
            return position;
        }
        public void Clear()
        {
            this.elementsList = new T[this.elementsList.Length];
            this.elementCount = 0;
        }
        public T Min()
        {
            dynamic currentMin = this.elementsList[0];
            for (int i = 1; i < this.elementsList.Length; i++)
            {
                if (this.elementsList[i] != null)
                {
                    if (currentMin.CompareTo(this.elementsList[i]) == 1)
                    {
                        currentMin = this.elementsList[i];
                    }
                }
            }
            return currentMin;
        }
        public T Max()
        {
            dynamic currentMax = this.elementsList[0];
            for (int i = 1; i < this.elementsList.Length; i++)
            {
                if (this.elementsList[i] != null)
                {
                    if (currentMax.CompareTo(this.elementsList[i]) == -1)
                    {
                        currentMax = this.elementsList[i];
                    }
                }
            }
            return currentMax;
        }
        // Overriding ToString()
        public override string ToString()
        {
            StringBuilder myBuilder = new StringBuilder();
            for (int i = 0; i < this.elementsList.Length; i++)
            {
                myBuilder.AppendFormat("{0} ", this.elementsList[i]);
            }
            myBuilder.AppendLine();
            return myBuilder.ToString();
        }
    }
}
