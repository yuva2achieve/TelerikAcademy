using System;
using System.Linq;

namespace _12.StackImplementation
{
    public class StackDemo
    {
        static void Main(string[] args)
        {
            //Push and Peek tests
            CustomStack<int> myStack = new CustomStack<int>(2);
            myStack.Push(5);
            myStack.Push(13);
            myStack.Push(101);
            Console.WriteLine("Current count: {0}", myStack.Count);
            Console.WriteLine(myStack.Peek());// 101
            Console.WriteLine("Current count: {0}", myStack.Count);

            // Initialize from array test
            //int[] testArray = new int[] { 14, 11, 4, 33, 55 };
            //CustomStack<int> myStack = new CustomStack<int>(testArray);
            //Console.WriteLine(myStack.Peek());// 55

            // Pop and Count tests
            //CustomStack<int> myStack = new CustomStack<int>(2);
            //myStack.Push(15);
            //myStack.Push(356);
            //myStack.Push(23);
            //myStack.Push(426);
            //Console.WriteLine("Current count: {0}", myStack.Count);
            //Console.WriteLine(myStack.Pop());// 426
            //Console.WriteLine(myStack.Pop());// 23
            //Console.WriteLine("Current count: {0}", myStack.Count);

            // Clear test
            //CustomStack<int> myStack = new CustomStack<int>(2);
            //myStack.Push(15);
            //myStack.Push(356);
            //myStack.Push(23);
            //myStack.Push(426);
            //Console.WriteLine("Current count: {0}", myStack.Count);
            //myStack.Clear();
            //Console.WriteLine("Current count: {0}", myStack.Count);
            //myStack.Push(1);
            //Console.WriteLine("Current count: {0}", myStack.Count);

            // ToArray test
            //CustomStack<int> myStack = new CustomStack<int>(2);
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //myStack.Push(4);
            //int[] arr = myStack.ToArray();
            //foreach (var element in arr)
            //{
            //    Console.Write("{0} ", element);
            //}
            //Console.WriteLine();

            // Contains test
            //CustomStack<int> myStack = new CustomStack<int>();
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //Console.WriteLine("Contains 1?: {0}", myStack.Contains(1));
            //Console.WriteLine("Contains 5?: {0}", myStack.Contains(5));
        }
    }
}
