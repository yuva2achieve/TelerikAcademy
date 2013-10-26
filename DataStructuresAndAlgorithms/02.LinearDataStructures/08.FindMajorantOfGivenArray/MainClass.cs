using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.FindMajorantOfGivenArray
{
    class MainClass
    {
        static void Main(string[] args)
        {
            int[] testSequence = new int[]
            {
                2, 2, 3, 3, 2, 3, 4, 3, 3
            };

            // No majorant test
            //int[] testSequence = new int[]
            //{
            //    3, 4, 4, 2, 3, 3, 4, 3, 2
            //};
            
            Dictionary<int, int> numberOfAppearances = new Dictionary<int, int>();
            GetNumberOfAppearances(testSequence, numberOfAppearances);

            int? majorant = FindMajorant(testSequence, numberOfAppearances);
            if (majorant != null)
            {
                Console.WriteLine("Majorant is: {0}", majorant);
            }
            else
            {
                Console.WriteLine("There is no majorant!");
            }
        }

        private static int? FindMajorant(int[] testSequence, Dictionary<int, int> numberOfAppearances)
        {
            int majorantMinimalAppearanceCount = (testSequence.Length / 2) + 1;
            int? majorant = null;
            foreach (var keyValuePair in numberOfAppearances)
            {
                if (keyValuePair.Value >= majorantMinimalAppearanceCount)
                {
                    majorant = keyValuePair.Key;
                    break;
                }
            }

            return majorant;
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
    }
}
