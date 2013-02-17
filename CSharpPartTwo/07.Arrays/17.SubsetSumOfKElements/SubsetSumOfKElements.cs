using System;
using System.Collections.Generic;
using System.Linq;

namespace _17.SubsetSumOfKElements
{
    class SubsetSumOfKElements
    {
        static void Main(string[] args)
        {
            /* Program searches for given sum S of K elements in given array with N elements 
             * if the sum is found in array elements are printed
             * if the sum doesn't exist in the array nothing is printed */
            //int n = 5;
            //int k = 2;
            //int s = 5;
            //int[] myArray = { 0, 3, 5, 2, 8 };
            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter K: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Enter S: ");
            int s = int.Parse(Console.ReadLine());
            int[] myArray = new int[n];
            Console.WriteLine("Enter array values: ");
            for (int i = 0; i < myArray.Length; i++)
            {
                myArray[i] = int.Parse(Console.ReadLine());
            }
            int[] combinationsArray = new int[k];
            GetCombinations(0, -1, n - 1, combinationsArray, myArray, s);
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
