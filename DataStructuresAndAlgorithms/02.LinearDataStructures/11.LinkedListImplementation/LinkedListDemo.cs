using System;
using System.Linq;

namespace _11.LinkedListImplementation
{
    class LinkedListDemo
    {
        static void Main(string[] args)
        {
            // AddFirst and AddLast tests
            CustomLinkedList<int> testList1 = new CustomLinkedList<int>(new ListItem<int>(1));
            testList1.AddFirst(5);
            testList1.AddFirst(15);
            testList1.AddLast(12345);
            testList1.AddLast(54321);
            Traverse<int>(testList1);
            Console.WriteLine("Elements count is: {0}", testList1.Count());
            Console.WriteLine("----------------------------------------------------------");

            // AddBefore and AddAfter tests
            CustomLinkedList<int> testList2 = new CustomLinkedList<int>(new ListItem<int>(11));
            testList2.AddLast(111);
            testList2.AddBefore(testList2.FirstElement, 555);
            testList2.AddAfter(testList2.FirstElement.NextItem, 6543);
            Traverse<int>(testList2);
            Console.WriteLine("Elements count is: {0}", testList2.Count());
            Console.WriteLine("----------------------------------------------------------");

            // RemoveFirst and RemoveLastTests
            CustomLinkedList<int> testList3 = new CustomLinkedList<int>(new ListItem<int>(33));
            testList3.AddAfter(testList3.FirstElement, 333);
            testList3.AddAfter(testList3.FirstElement.NextItem, 3333);
            testList3.AddAfter(testList3.FirstElement.NextItem.NextItem, 33333);
            testList3.AddAfter(testList3.FirstElement.NextItem.NextItem.NextItem, 333333);
            testList3.RemoveFirst();
            testList3.RemoveLast();
            Traverse<int>(testList3);
            Console.WriteLine("Elements count is: {0}", testList3.Count());
        }

        private static void Traverse<T>(CustomLinkedList<T> myList)
        {
            ListItem<T> currentElement = myList.FirstElement;
            while (true)
            {
                Console.WriteLine(currentElement.Value);
                if (currentElement.NextItem == null)
                {
                    return;
                }
                else
                {
                    currentElement = currentElement.NextItem;
                }
            }
        }
    }
}
