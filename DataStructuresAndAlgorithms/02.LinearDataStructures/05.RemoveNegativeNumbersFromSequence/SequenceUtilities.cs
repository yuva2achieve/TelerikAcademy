using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativeNumbersFromSequence
{
    public static class SequenceUtilities
    {
        static void Main(string[] args)
        {
            List<int> testSequence = new List<int>()
            {
                1, -4, 23, 0, -42, -1, 2, 3, -4
            };

            var positiveSequence = RemoveNegativeNumbers(testSequence);
            PrintSequence(positiveSequence);
        }

        private static List<int> RemoveNegativeNumbers(List<int> sequence)
        {
            var result =
                from value in sequence
                where value >= 0
                select value;

            return result.ToList();
        }

        private static void PrintSequence(List<int> sequence)
        {
            for (int i = 0; i < sequence.Count; i++)
            {
                Console.Write("{0} ", sequence[i]);
            }
        }
    }
}
