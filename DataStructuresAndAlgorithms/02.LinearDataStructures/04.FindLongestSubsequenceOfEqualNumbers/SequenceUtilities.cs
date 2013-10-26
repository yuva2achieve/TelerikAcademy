using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindLongestSubsequenceOfEqualNumbers
{
    public static class SequenceUtilities
    {
        public static void Main()
        {
        }

        public static List<int> GetLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            List<int> result = new List<int>();
            int bestCount = 1;
            int currentValue = 0;
            for (int i = 0; i < sequence.Count; i++)
            {
                int currentItem = sequence[i];
                int currentCount = 1;
                for (int j = i + 1; j < sequence.Count; j++)
                {
                    if (sequence[j] == currentItem)
                    {
                        currentCount++;
                        if (currentCount > bestCount)
                        {
                            bestCount = currentCount;
                            currentValue = currentItem;
                        }
                    }
                    else
                    {
                        break;
                    }                   
                }
            }         

            for (int i = 0; i < bestCount; i++)
            {
                result.Add(currentValue);
            }

            return result;
        }
    }
}
