using System;
using System.Linq;

namespace _15.UseGenericMethods
{
    class UseGenericMethods
    {
        static void Main(string[] args)
        {
            byte[] sequence = { 4, 5, 2 };
            GetMin(sequence);
            GetMax(sequence);
            GetAverage(sequence);
            GetSum(sequence);
            GetProduct(sequence);
        }

        static void GetMin<T>(T[] myArray)
        {
            T result = myArray.Min();
            Console.WriteLine("Minimum: {0}", result);
        }

        static void GetMax<T>(T[] myArray)
        {
            T result = myArray.Max();
            Console.WriteLine("Maximum: {0}", result);
        }

        static void GetAverage<T>(T[] myArray)
        {
            dynamic sum = 0;
            sum = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                sum += myArray[i];
            }
            T result = (T)(sum / myArray.Length);
            Console.WriteLine("Average: {0}", result);
        }

        static void GetSum<T>(T[] myArray)
        {
            dynamic result = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                result += myArray[i];
            }
            Console.WriteLine("Sum: {0}", result);
        }

        static void GetProduct<T>(T[] myArray)
        {
            dynamic result = myArray[0];
            for (int i = 1; i < myArray.Length; i++)
            {
                result *= myArray[i];
            }
            Console.WriteLine("Product: {0}", result);
        }
    }
}
