using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountOccurrencesOfEachValue
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            Dictionary<double, int> occurrencesCount = new Dictionary<double, int>();

            foreach (var value in input)
            {
                if (occurrencesCount.ContainsKey(value))
                {
                    occurrencesCount[value]++;
                }
                else
                {
                    occurrencesCount.Add(value, 1);
                }
            }

            foreach (var keyValuePair in occurrencesCount)
            {
                Console.WriteLine("{0}: {1} times", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
