using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.FindOddStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, int> occurrencesCount = new Dictionary<string, int>();
            
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
                if (keyValuePair.Value % 2 == 1)
                {
                    Console.WriteLine(keyValuePair);
                }
            }
        }
    }
}
