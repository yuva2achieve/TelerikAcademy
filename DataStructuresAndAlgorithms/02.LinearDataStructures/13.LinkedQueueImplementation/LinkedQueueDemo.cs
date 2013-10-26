using System;
using System.Linq;

namespace _13.LinkedQueueImplementation
{
    class LinkedQueueDemo
    {
        static void Main(string[] args)
        {
            // Enqueue test
            LinkedQueue<int> myQueue = new LinkedQueue<int>();
            Console.WriteLine(myQueue.Count);
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            Console.WriteLine(myQueue.Count);

            // Dequeue test
            //LinkedQueue<int> myQueue = new LinkedQueue<int>();
            //myQueue.Enqueue(11);
            //myQueue.Enqueue(22);
            //myQueue.Enqueue(33);
            //myQueue.Enqueue(44);
            //Console.WriteLine(myQueue.Count);
            //Console.WriteLine(myQueue.Dequeue());
            //Console.WriteLine(myQueue.Count);
            
            // Peek test
            //LinkedQueue<int> myQueue = new LinkedQueue<int>();
            //myQueue.Enqueue(11);
            //myQueue.Enqueue(22);
            //myQueue.Enqueue(33);
            //myQueue.Enqueue(44);
            //Console.WriteLine(myQueue.Count);
            //Console.WriteLine(myQueue.Peek());
            //Console.WriteLine(myQueue.Count);

            // Clear test
            //LinkedQueue<int> myQueue = new LinkedQueue<int>();
            //myQueue.Enqueue(11);
            //myQueue.Enqueue(22);
            //myQueue.Enqueue(33);
            //myQueue.Enqueue(44);
            //Console.WriteLine(myQueue.Count);
            //myQueue.Clear();
            //Console.WriteLine(myQueue.Count);

            // Contains test
            //LinkedQueue<int> myQueue = new LinkedQueue<int>();
            //myQueue.Enqueue(11);
            //myQueue.Enqueue(22);
            //myQueue.Enqueue(33);
            //myQueue.Enqueue(44);
            //Console.WriteLine("Contains 22?: {0}", myQueue.Contains(22));
            //Console.WriteLine("Contains 105?: {0}", myQueue.Contains(105));

            // ToArray test
            //LinkedQueue<int> myQueue = new LinkedQueue<int>();
            //myQueue.Enqueue(11);
            //myQueue.Enqueue(22);
            //myQueue.Enqueue(33);
            //myQueue.Enqueue(44);
            //var testArray = myQueue.ToArray();
            //foreach (var item in testArray)
            //{
            //    Console.Write("{0} ", item);
            //}
            //Console.WriteLine();
        }
    }
}
