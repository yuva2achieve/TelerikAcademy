using System;
using System.Collections.Generic;
using System.Linq;

namespace _16.SubsetSum
{
    class SubsetSum
    {
        static void Main(string[] args)
        {
            /* Program searches for given sum s in given array 
             * if the sum is found in array elements are printed
             * if the sum doesn't exist in the array nothing is printed */
            int[] myArray = {0, 1, 3, 5, 2, 8, 18};
            int n = myArray.Length;
            int s = 8;
            for (int i = 0; i < n; i++)
            {
                int[] combinationsArray = new int[i];
                GetCombinations(0, -1, n - 1, combinationsArray, myArray, s);
            }
        }

        static void GetCombinations(int index, int start, int end, int[] firstArray, int[] secondArray, int sum)
        {
            if (index == firstArray.Length)
            {
                CheckSum(firstArray, secondArray, sum);
            }
            else
            {
                for (int i = start + 1; i <= end; i++)
                {
                    firstArray[index] = i;
                    GetCombinations(index + 1, i, end, firstArray, secondArray, sum);
                }
            }
        }

        static void CheckSum(int[] firstArray, int[] secondArray, int sum)
        {
            List<int> tempList = new List<int>();
            int tempSum = 0;
            foreach (var value in firstArray)
            {
                tempList.Add(value);
            }
            foreach (var item in tempList)
            {
                tempSum += secondArray[item];
            }
            if (tempSum == sum)
            {
                foreach (var item in tempList)
                {
                    Console.Write(secondArray[item] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
