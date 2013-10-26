using System;
using System.Linq;

namespace _04.HashTableImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomHashTable<string, int> myTable = new CustomHashTable<string, int>();
            myTable["a"] = 1;
            myTable["b"] = 2;
            myTable["c"] = 3;
            Console.WriteLine(myTable.Find("a"));
            Console.WriteLine("Items count: {0}", myTable.Count);
            //myTable.Remove("a");
            //Console.WriteLine(myTable.Find("a"));// Throws exception
            foreach (var item in myTable)
            {
                Console.WriteLine(item);
            }
            myTable.Clear();
            Console.WriteLine("Items count: {0}", myTable.Count);
            Console.WriteLine(myTable.ContainsKey("a"));
        }
    }
}
