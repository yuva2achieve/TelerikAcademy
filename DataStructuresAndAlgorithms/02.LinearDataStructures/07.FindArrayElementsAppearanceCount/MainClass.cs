using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FindArrayElementsAppearanceCount
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int[] testSequence = new int[]
            {
                3, 4, 4, 2, 3, 3, 4, 3, 2,
                3, 2, 1, 1, 3, 4, 2, 1, 10
            };

            Dictionary<int, int> numberOfAppearances = new Dictionary<int, int>();
            GetNumberOfAppearances(testSequence, numberOfAppearances);
            PrintNumberOfAppearances(numberOfAppearances);
        }

        private static void GetNumberOfAppearances(int[] testSequence, Dictionary<int, int> numberOfAppearances)
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

        private static void PrintNumberOfAppearances(Dictionary<int, int> appearances)
        {
            foreach (var keyValuePair in appearances)
            {
                Console.WriteLine("{0}: appears {1} times", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
