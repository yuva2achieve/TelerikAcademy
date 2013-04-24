using System;
using System.Linq;

namespace _06.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            int[] newNumbers = new int[k];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter element value: ");
                numbers[n] = int.Parse(Console.ReadLine());
            }
            Array.Sort(numbers);
            Array.Reverse(numbers);
            for (int i = 0; i < k; i++)
            {
                newNumbers[i] = numbers[i];
            }
            Array.Reverse(newNumbers);
            foreach (var number in newNumbers)
            {
                Console.Write("{0} ", number);
            }
        }
    }
}
