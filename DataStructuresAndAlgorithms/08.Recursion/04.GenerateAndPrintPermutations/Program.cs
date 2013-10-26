using System;
using System.Linq;

namespace _04.GenerateAndPrintPermutations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            int[] myArray = new int[n];
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = i + 1;
            }

            GetPermutations(0, myArray.Length, myArray);
        }

        static void GetPermutations(int start, int end, int[] array)
        {
            if (start == end)
            {
                Print(array);
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    Swap(ref array[i], ref array[start]);
                    GetPermutations(start + 1, end, array);
                    Swap(ref array[i], ref array[start]);
                }
            }
        }

        static void Swap(ref int valueA, ref int valueB)
        {
            int temp = valueA;
            valueA = valueB;
            valueB = temp;
        }

        static void Print(int[] array)
        {
            foreach (var value in array)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
    }
}
