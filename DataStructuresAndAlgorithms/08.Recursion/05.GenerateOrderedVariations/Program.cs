using System;
using System.Linq;

namespace _05.GenerateOrderedVariations
{
    class Program
    {
        private static string[] setOfWords;

        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            setOfWords = new string[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter word: ");
                setOfWords[i] = Console.ReadLine();
            }

            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            string[] arr = new string[k];
            GenerateVariations(0, n, arr);
        }

        private static void GenerateVariations(int index, int end, string[] array)
        {
            if (index == array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 0; i < end; i++)
                {
                    array[index] = setOfWords[i];
                    GenerateVariations(index + 1, end, array);
                }
            }
        }

        private static void Print(string[] array)
        {
            foreach (var value in array)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }
}
