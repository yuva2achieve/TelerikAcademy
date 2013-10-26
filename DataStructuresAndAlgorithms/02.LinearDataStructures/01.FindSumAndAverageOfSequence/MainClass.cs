namespace _01.FindSumAndAverageOfSequence
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class MainClass
    {
        public static void Main(string[] args)
        {
            List<int> sequence = new List<int>();
            GetSequence(sequence);

            BigInteger sum = GetSumOfSequence(sequence);
            decimal average = GetAverageOfSequence(sequence, sum);

            PrintSumAndAverage(sum, average);
        }

        private static void GetSequence(List<int> sequence)
        {
            bool sequenceFinished = false;
            while (!sequenceFinished)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    sequenceFinished = true;
                }
                else
                {
                    int inputValue = int.Parse(input);
                    if (inputValue >= 0)
                    {
                        sequence.Add(inputValue);
                    }
                }
            }
        }

        private static BigInteger GetSumOfSequence(List<int> sequence)
        {
            BigInteger sum = 0;
            for (int i = 0; i < sequence.Count; i++)
            {
                sum += sequence[i];
            }

            return sum;
        }

        private static decimal GetAverageOfSequence(List<int> sequence, BigInteger sequenceSum)
        {
            decimal average = (decimal)sequenceSum / sequence.Count;
            return average;
        }

        private static void PrintSumAndAverage(BigInteger sequenceSum, decimal sequenceAverage)
        {
            Console.WriteLine("Sum of the sequence is: {0}", sequenceSum);
            Console.WriteLine("Average of the sequence is: {0}", sequenceAverage);
        }
    }
}
