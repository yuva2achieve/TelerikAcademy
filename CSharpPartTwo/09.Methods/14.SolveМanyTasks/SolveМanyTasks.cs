using System;
using System.Linq;

namespace _14.SolveМanyTasks
{
    class SolveМanyTasks
    {
        static void Main(string[] args)
        {
            int[] sequence = { 4, 0, 1, 23, -3, 6 };
            GetMin(sequence);
            GetMax(sequence);
            GetAverage(sequence);
            GetSum(sequence);
            GetProduct(sequence);
        }

        static void GetMin(int[] myArray)
        {
            int result = myArray.Min();
            Console.WriteLine("Minimum: {0}", result);
        }

        static void GetMax(int[] myArray)
        {
            int result = myArray.Max();
            Console.WriteLine("Maximum: {0}", result);
        }

        static void GetAverage(int[] myArray)
        {
            int sum = myArray.Sum();
            int result = sum / myArray.Length;
            Console.WriteLine("Average: {0}", result);
        }

        static void GetSum(int[] myArray)
        {
            int result = myArray.Sum();
            Console.WriteLine("Sum: {0}", result);
        }

        static void GetProduct(int[] myArray)
        {
            int result = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                result *= myArray[i];
            }
            Console.WriteLine("Product: {0}", result);
        }
    }
}
