using System;
using System.Linq;

namespace _01.SimulateNestedLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int[] results = new int[n];
            Permute(0, n, results);
        }
        
        private static void Permute(int index, int n, int[] arr)
        {
            if (index >= n)
            {
                Print(arr);
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                arr[index] = i;
                Permute(index + 1, n, arr);
            }
        }

        private static void Print(int[] array)
        {
            foreach (var value in array)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }
}
