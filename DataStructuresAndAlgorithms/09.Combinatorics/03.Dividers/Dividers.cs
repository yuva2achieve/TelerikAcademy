using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.Dividers
{
    class Dividers
    {
        private static HashSet<string> permutations = new HashSet<string>();
        private static List<int> parsedPermutations = new List<int>();
        private static int minDividersCount = int.MaxValue;
        private static int currentMinValue = 0;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] digits = new int[n];
            for (int i = 0; i < n; i++)
            {
                digits[i] = int.Parse(Console.ReadLine());
            }

            Array.Sort(digits);

            GetPermutations(0, digits);
            ParsePermutations();
            GetDividersCount(parsedPermutations[0]);
            for (int i = 1; i < parsedPermutations.Count; i++)
            {
                GetDividersCount(parsedPermutations[i]);
            }

            Console.WriteLine(currentMinValue);
        }

        static void GetPermutations(int start, int[] array)
        {
            if (start == array.Length)
            {
                AddPermutation(array);
            }
            else
            {
                for (int i = start; i < array.Length; i++)
                {
                    Swap(ref array[i], ref array[start]);
                    GetPermutations(start + 1, array);
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

        static void AddPermutation(int[] array)
        {
            StringBuilder permutation = new StringBuilder();

            foreach (var value in array)
            {
                permutation.Append(value.ToString());
            }

            if (!permutations.Contains(permutation.ToString()))
            {
                permutations.Add(permutation.ToString());
            }
        }

        private static void ParsePermutations()
        {
            foreach (var permutation in permutations)
            {
                parsedPermutations.Add(int.Parse(permutation));
            }
        }

        private static void GetDividersCount(int permutation)
        {
            int currentDividersCount = 0;
            for (int i = 1; i <= permutation; i++)
            {
                if (permutation % i == 0)
                {
                    currentDividersCount++;
                }
            }

            if (currentDividersCount < minDividersCount)
            {
                minDividersCount = currentDividersCount;
                currentMinValue = permutation;
            }
        }
    }
}