using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RemoveNumbersAppearingOddNumberOfTimes
{
    public static class SequenceUtilities
    {
        static void Main(string[] args)
        {
            List<int> testSequence = new List<int>()
            {
                4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2
            };

            Dictionary<int, int> numberOfAppearances = new Dictionary<int, int>();
            GetNumberOfAppearances(testSequence, numberOfAppearances);
            RemoveNumbersAppearingOddTimes(numberOfAppearances, testSequence);

            PrintSequence(testSequence);
        }
  
        private static void RemoveNumbersAppearingOddTimes(Dictionary<int, int> numberOfAppearances, List<int> testSequence)
        {
            foreach (var keyValuePair in numberOfAppearances)
            {
                if (keyValuePair.Value % 2 == 1)
                {
                    RemoveNumberFromList(keyValuePair.Key, testSequence);
                }
            }
        }
  
        private static void GetNumberOfAppearances(List<int> testSequence, Dictionary<int, int> numberOfAppearances)
        {
            foreach (var value in testSequence)
            {
                if (numberOfAppearances.ContainsKey(value))
                {
                    numberOfAppearances[value]++;
                }
                else
                {
                    numberOfAppearances[value] = 1;
                }
            }
        }

        private static void RemoveNumberFromList(int number, List<int> list)
        {
            list.RemoveAll(x => x == number);
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
