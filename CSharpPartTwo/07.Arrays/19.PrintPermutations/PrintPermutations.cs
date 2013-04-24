using System;
using System.Linq;

namespace _19.PrintPermutations
{
    class PrintPermutations
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
            int temp = 0;
            if (start == end)
            {
                Print(array);
            }
            else
            {
                for (int i = start; i < end; i++)
                {
                    temp = Swap(array, i, start, temp);
                    GetPermutations(start + 1, end, array);
                    temp = Swap(array, i, start, temp);
                }
            }
        }
  
        static int Swap(int[] array, int i, int start, int temp)
        {
            temp = array[i];
            array[i] = array[start];
            array[start] = temp;
            return temp;
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