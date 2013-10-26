using System;
using System.Linq;

namespace _05.HashSetImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomHashSet<int> firstSet = new CustomHashSet<int>();
            firstSet.Add(5);
            firstSet.Add(1);
            firstSet.Add(6);
            CustomHashSet<int> secondSet = new CustomHashSet<int>();
            secondSet.Add(3);
            secondSet.Add(1);
            secondSet.Add(6);

            var union = firstSet.Union(secondSet);
            Console.WriteLine("-------------Union-------------");
            foreach (var item in union)
            {
                Console.WriteLine(item);
            }

            var intersection = firstSet.Intersect(secondSet);
            Console.WriteLine("-------------Intersection-------------");
            foreach (var item in intersection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
