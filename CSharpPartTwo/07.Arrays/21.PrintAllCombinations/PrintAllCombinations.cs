using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.PrintAllCombinations
{
    class PrintAllCombinations
    {
        static void GetCombinations(int index, int start, int end, int[] array)
        {
            if (index == array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = start + 1; i <= end ; i++)
                {
                    array[index] = i;
                    GetCombinations(index + 1, i, end, array);
                }
            }
        }
  
        static void Print(int[] array)
        {
            foreach (var value in array)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            int startIndex = 0;
            int numStart = 0;
            int[] myArray = new int[k];
            GetCombinations(startIndex, numStart, n, myArray);
        }
    }
}
