using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _04.SequenceOfColoredBalls
{
    class SequenceOfColoredBalls
    {
        private static Dictionary<char, int> colorsCount = new Dictionary<char, int>();

        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char color = input[i];
                if (!colorsCount.ContainsKey(color))
                {
                    colorsCount.Add(color, 1);
                }
                else
                {
                    colorsCount[color]++;
                }
            }

            BigInteger numberOfPermutations = CalculateNumberOfPermutations();
            Console.WriteLine(numberOfPermutations);
        }

        private static BigInteger CalculateFactorial(int n)
        {
            BigInteger result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            return result;
        }

        private static BigInteger CalculateNumberOfPermutations()
        {
            BigInteger divisor = 1;
            int coloredBallsCount = 0;
            foreach (var keyValuePair in colorsCount)
            {
                coloredBallsCount += keyValuePair.Value;
                divisor *= CalculateFactorial(keyValuePair.Value);
            }

            BigInteger numerator = CalculateFactorial(coloredBallsCount);
            return numerator / divisor;
        }
    }
}
