using System;
using GenericList.Common;

namespace GenericListTest
{
    class GenericListTest
    {
        static void Main(string[] args)
        {
            GenericList<string> temp = new GenericList<string>(2);
            temp.Add("z");
            temp.Add("b");
            temp.Add("c");
            temp.Add("a");
            temp.Add("c");
            Console.WriteLine(temp.Min());
            Console.WriteLine(temp.Max());
        }
    }
}
