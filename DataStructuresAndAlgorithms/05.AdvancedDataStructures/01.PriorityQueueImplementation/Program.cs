using System;
using System.Linq;

namespace _01.PriorityQueueImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> pq = new PriorityQueue<int>();
            pq.Add(5);
            pq.Add(-1);
            pq.Add(4);
            pq.Add(1);
            pq.Add(0);
            Console.WriteLine(pq.Contains(4));
            Console.WriteLine(pq.Contains(-4));
            while (pq.Count > 0)
            {
                Console.WriteLine(pq.Remove());
            }

        }
    }
}
