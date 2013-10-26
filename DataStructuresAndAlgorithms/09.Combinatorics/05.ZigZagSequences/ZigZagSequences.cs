using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.ZigZagSequences
{
    class ZigZagSequences
    {
        private static bool[] used;
        private static int n;
        private static int k;
        private static int[] values;
        private static int zigZagSequencesCount = 0;

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] arguments = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            n = int.Parse(arguments[0]);
            k = int.Parse(arguments[1]);
            used = new bool[n];
            int[] array = new int[k];
            FillValues();
            GenerateVariationsNoReps(0, array);

            Console.WriteLine(zigZagSequencesCount);
        }

        private static bool IsZigZag(int[] variation)
        {
            bool isZigZag = true;
            if (variation[0] < variation[1])
            {
                isZigZag = false;
                return isZigZag;
            }

            for (int i = 1; i < variation.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    int current = variation[i];
                    int next = variation[i + 1];
                    if (current < next)
                    {
                        isZigZag = false;
                        break;
                    }
                }
                else
                {
                    int current = variation[i];
                    int next = variation[i + 1];
                    if (current > next)
                    {
                        isZigZag = false;
                        break;
                    }
                }
            }

            return isZigZag;
        }

        private static void FillValues()
        {
            values = new int[n];
            for (int i = 0; i < n; i++)
            {
                values[i] = i;
            }
        }

        static void GenerateVariationsNoReps(int index, int[] arr)
        {
            if (index >= k)
            {
                AddVariation(arr);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        arr[index] = i;
                        GenerateVariationsNoReps(index + 1, arr);
                        used[i] = false;
                    }
                }
            }
        }

        private static void AddVariation(int[] array)
        {
            int[] variation = new int[array.Length];
            for (int i = 0; i < variation.Length; i++)
            {
                variation[i] = values[array[i]];
            }

            bool flag = IsZigZag(variation);
            if (flag)
            {
                zigZagSequencesCount++;
            }
        }
    }
}