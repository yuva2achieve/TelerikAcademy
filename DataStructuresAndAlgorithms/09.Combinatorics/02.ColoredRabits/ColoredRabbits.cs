using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ColoredRabits
{
    class ColoredRabbits
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> rabbitsCount = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int count = int.Parse(Console.ReadLine());
                if (rabbitsCount.ContainsKey(count + 1))
                {
                    rabbitsCount[count + 1]++;
                }
                else
                {
                    rabbitsCount.Add(count + 1, 1);
                }
            }

            long result = 0;

            foreach (var keyValuePair in rabbitsCount)
            {
                result += (long)Math.Ceiling((decimal)keyValuePair.Value / keyValuePair.Key) * keyValuePair.Key;
            }

            Console.WriteLine(result);
        }
    }
}
